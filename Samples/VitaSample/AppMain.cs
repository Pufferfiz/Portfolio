using System;
using System.Collections.Generic;

using Sce.Pss.Core;
using Sce.Pss.Core.Environment;
using Sce.Pss.Core.Graphics;
using Sce.Pss.Core.Input;
using DemoGame;
using Nonograms.Engine;
using Nonograms.Game;


namespace Nonograms
{
	public class AppMain
	{
		private static GraphicsContext graphics;
		static private Texture2D asd;
		static private TextureRenderer myRenderer;
		
		#region Menues
		/// <summary>
		/// The state of the my game.
		/// </summary>
		private static GameState myGameState;
		
		/// <summary>
		/// The Intro State.
		/// </summary>
		private static Intro _INTRO = new Intro();
		
		/// <summary>
		/// The Credits State.
		/// </summary>
		private static Credits _CREDITS = new Credits();
		#endregion Menues
		
		public static void Main (string[] args)
		{
			Initialize ();

			while (true) {
				SystemEvents.CheckEvents ();
				Update ();
				Render ();
			}
		}

		public static void Initialize ()
		{
			// Set up the graphics system
			graphics = new GraphicsContext ();
			asd = new Texture2D("/Application/Assists/lol.png",false);
			myRenderer = new TextureRenderer();
			myRenderer.BindGraphicsContext(graphics);
			
			myGameState = _INTRO;
			myGameState.Initialize();
			myGameState.LoadContent();
		}

		public static void Update ()
		{
			// Query gamepad for current state
			var gamePadData = GamePad.GetData (0);
			Console.WriteLine(_INTRO.isDone.ToString());
			myGameState.Update();
		}
		
		public static void Render ()
		{
			// Clear the screen
			graphics.SetClearColor (0.0f, 0.0f, 0.0f, 0.0f);
			graphics.Clear ();
			myRenderer.Begin();
			myGameState.Draw(myRenderer);
			//myRenderer.Render(asd,0,0,0,0,920,544);
			myRenderer.End();
			
			// Present the screen
			graphics.SwapBuffers ();
		}
	}
}
