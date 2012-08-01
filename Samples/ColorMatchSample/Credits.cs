using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Surface;
using Microsoft.Surface.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;

namespace ColorMatch.Game.States
{
    class Credits : Engine.GameState
    {
        #region Members
        private Texture2D _BackGround;
        private float timeLastClicked;
        private float timeNow = 0.00f;
        public bool didClick;
        #endregion Members

        public Credits()
        { }

        public override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// Load content
        /// </summary>
        /// <param name="theGraphics">GraphicsDevice to Use</param>
        /// <param name="content"> ContentManager</param>
        public override void LoadContent(GraphicsDevice theGraphics, ContentManager content)
        {
            _BackGround = Program.TextureFromFile(theGraphics, "Resources\\Credits.jpg");
            base.LoadContent(theGraphics, content);
        }

        /// <summary>
        /// Update All logic
        /// </summary>
        /// <param name="gameTime">Application Time</param>
        public override void Update(GameTime gameTime)
        {
            if (didClick == true)
            {
                timeLastClicked = gameTime.TotalGameTime.Seconds;
                didClick = false;
            }

            timeNow = gameTime.TotalGameTime.Milliseconds;
            base.Update(gameTime);
        }

        /// <summary>
        /// Draw Items to screen
        /// </summary>
        /// <param name="gameTime"> Application Time</param>
        /// <param name="inSpriteBatch">SpriteBatch To draw Sprites</param>
        public override void Draw(GameTime gameTime, SpriteBatch inSpriteBatch)
        {
            //start spriteBatch
            inSpriteBatch.Begin();
            inSpriteBatch.Draw(_BackGround, Program.ScreenRectangle, Color.White);
            //end spriteBatch
            inSpriteBatch.End();

            base.Draw(gameTime, inSpriteBatch);
        }


        /// <summary>
        /// Delete Everything
        /// </summary>
        public override void Dispose()
        {
            _BackGround.Dispose();
            this.ison = false;
            base.Dispose();
        }
        /// <summary>
        /// Check to see if I can get out
        /// </summary>
        /// <returns>Whether the game can get out of credits</returns>
        public bool canProgress()
        {
            if ((timeLastClicked + 10> timeNow) == false)
            {
                timeNow = 0f;
                return true;
            }
            else
                return false;
        }


    }
}
