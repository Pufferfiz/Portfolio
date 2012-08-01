/////////////////////////////////////////////////////////////////////////////////
//
// StarShip
//
// GAM315 - Final Project
// Wayne Sikes
//
// Description
//  Simple starship model flown via keyboard control.
//
/////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace Final_Project
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class StarShipManager : Microsoft.Xna.Framework.GameComponent
    {
        static Vector3 STARSHIP_DEFAULT_POSITION         = new Vector3(0.0f, 5, 0.0f);
        static Vector3 STARSHIP_DEFAULT_DIRECTION_VECTOR = new Vector3(0.0f, 0.0f, -1.0f);
        static float STARSHIP_DEFAULT_SCALE              = 0.05f;
        static float STARSHIP_SPEED_MULTIPLIER           = 100.0f;
        static float STARSHIP_FASTSPEED_MULTIPLIER       = 500.0f;
        static float STARSHIP_ROTATION_SPEED             = 75.0f;
        static float STARSHIP_PITCH_SPEED                = 75.00f;
        static float STARSHIP_MAX_ROLL_WITH_YAW          = 20.0f;
        static float STARSHIP_ROLL_WITH_YAW_RATE         = 125.0f;

        internal Model model;
        Game parentGame;

        public string debugText = "none";
        public Matrix mRotate;
        public Vector3 vPosition;

        Effect effect;
        Matrix mWorldTransform;
        Matrix matRotateModelToWorld;
        Matrix matRollWithYaw;
        float andgle;

        public Vector3 vDirection;

        float fScaleFactor;
        float fRotateXInDegrees;

       public  float fRotateYInDegrees;
        float fRotateZInDegrees;
        float fRollWithYawInDegrees;

        // construction
        public StarShipManager(Game game) : base(game)
        {
            // remember our parent game object
            parentGame = game;
        }

        // Reset starship position - use as separate function for call
        // by game manager to reset ship position and rotation
        public void Reset()
        {
            // set default position and look direction
            vPosition  = STARSHIP_DEFAULT_POSITION;
            vDirection = STARSHIP_DEFAULT_DIRECTION_VECTOR;
            // clear all rotations
            fRotateXInDegrees = 0.0f;
            fRotateYInDegrees = 0.0f;
            fRotateZInDegrees = 0.0f;
            // + deg = roll left, -deg = roll right
            fRollWithYawInDegrees = 0.0f;
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // reset first
            Reset();

            fScaleFactor = STARSHIP_DEFAULT_SCALE;

            // the model needs to be rotated 180 deg on Y-axis - we need it to point
            // in the 0,0,-1 direction
            matRotateModelToWorld = Matrix.CreateRotationY( MathHelper.ToRadians(180) );

            // build start-up world transform
            BuildWorldTransform();

            // clear debug string
            debugText = "None";

            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // set high priority - update starship FIRST since camera and other 
            // things depend on this
            UpdateOrder = 10;
            
            // tick time in seconds since last tick
            float fTickTime = gameTime.ElapsedGameTime.Milliseconds / 1000.0f;
            
            // read keyboard
            KeyboardState currentKBState = Keyboard.GetState();
            
            // move forward?
            if (currentKBState.IsKeyDown(Keys.W))
            {
                float fSpeed = STARSHIP_SPEED_MULTIPLIER;
                if (currentKBState.IsKeyDown(Keys.LeftShift))
                    fSpeed = STARSHIP_FASTSPEED_MULTIPLIER;
                // change position based on speed, time, and direction vector
                vPosition = vPosition - (vDirection * fTickTime * fSpeed);
            }

            // Fill This In //
            // add code to move backward, turn left and right, and 
            // pitch up and down
            // You get brownie points if your left and right turning code
            // provides for a slight roll (on Z-axis) as you turn the ship 
            if (currentKBState.IsKeyDown(Keys.S))
            {
                float fSpeed = STARSHIP_SPEED_MULTIPLIER;
                if (currentKBState.IsKeyDown(Keys.LeftShift))
                    fSpeed = STARSHIP_FASTSPEED_MULTIPLIER;
                // change position based on speed, time, and direction vector
                vPosition = vPosition + (vDirection * fTickTime * fSpeed);
            }

            if (currentKBState.IsKeyDown(Keys.A))
            {
                mRotate = Matrix.CreateRotationY(andgle);
                andgle += 1f;
            }
            if (currentKBState.IsKeyDown(Keys.D))
            {
                mRotate = Matrix.CreateRotationY(andgle);
                andgle -= 1f;
            }
            if (currentKBState.IsKeyDown(Keys.R))
            {
                Reset();
            }
            //vDirection = Vector3.Transform(vDirection, mRotate);
            fRotateYInDegrees = andgle;
            // build start-up world transform
            BuildWorldTransform();

            // debug
//            debugText = "StarShip XYZ Pos: " + vPosition + "  Dir: " + vDirection;

            base.Update(gameTime);
        }

        // load starship
        public void Load(string starShipName)
        {
            model = parentGame.Content.Load<Model>(starShipName);
            // get effect from first mesh
            effect = model.Meshes[0].Effects[0];
            // type cast effect to interface IEffectLights so we can
            // tweak the lights
            IEffectLights iel = effect as IEffectLights;
            iel.EnableDefaultLighting();
            iel.AmbientLightColor = Color.Red.ToVector3();
        }

        // draw the model
        public void DrawModel(Matrix viewMatrix, Matrix projMatrix)
        {
            // remember original states
            RasterizerState oldRS = parentGame.GraphicsDevice.RasterizerState;
            DepthStencilState oldDS = parentGame.GraphicsDevice.DepthStencilState;
            // set rasterizer state and depthstencil
            parentGame.GraphicsDevice.RasterizerState = (parentGame as GameManager).newRasterizerState_Solid;
            parentGame.GraphicsDevice.DepthStencilState = DepthStencilState.Default;

            // apply effect and draw it
            effect.CurrentTechnique.Passes[0].Apply();
            model.Draw(mWorldTransform,
                       viewMatrix,
                       projMatrix);
            // restore last state
            parentGame.GraphicsDevice.RasterizerState = oldRS;
            parentGame.GraphicsDevice.DepthStencilState = oldDS;
        }

        // build the world transform matrix
        public void BuildWorldTransform()
        {
            // Fill This In //
            // create translation, scale, and rotate matrices. Also create a Z rot
            // matrix if using matRollWithYaw as part of the turn left/right code.
            // Upate the direction vector - be sure to normalize it too.
            //// finally, build the mWorldTransform matrix - it's there but commented out.
            //// Uncomment it when you get all the other transforms in place.
           
            // create world translation matrix - puts model in desired place in world
            Matrix mWorldTranslation = Matrix.CreateTranslation(vPosition);
            // create scaling matrix - sets the size of the model
            Matrix mWorldScale = Matrix.CreateScale(fScaleFactor);
            // create world rotation matrix from quats
            float RotateXInRadians = MathHelper.ToRadians(fRotateXInDegrees);
            float RotateYInRadians = MathHelper.ToRadians(fRotateYInDegrees);
            float RotateZInRadians = MathHelper.ToRadians(fRotateZInDegrees);
            Quaternion qRotation =
                Quaternion.CreateFromAxisAngle(Vector3.Right, RotateXInRadians) *
                Quaternion.CreateFromAxisAngle(Vector3.Up, RotateYInRadians) *
                Quaternion.CreateFromAxisAngle(Vector3.Backward, RotateZInRadians);
            qRotation.Normalize();
            Matrix mRotate = Matrix.CreateFromQuaternion(qRotation);
           
            vDirection.Normalize();
 
            vDirection = Vector3.Transform(Vector3.Forward, mRotate);
  
            vDirection.Normalize();
            



            mWorldTransform = mRotate * mWorldScale * mWorldTranslation;
            debugText = qRotation.ToString();
        }












    }
}
