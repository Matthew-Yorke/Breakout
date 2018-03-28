//***************************************************************************************************************************************************
//
// File Name: State.cs
//
// Description:
//  The abstract state class that determines what methods concrete states must inherit as well as handling processing that multiple states may use.
//
// Change History:
//  Author               Date           Description
//  Matthew D. Yorke     MM/DD/2018     TODO: Add description.
//
//***************************************************************************************************************************************************

using System.Windows.Forms;
using System.Drawing;

namespace Breakout
{
   public abstract class State
   {
      protected BreakoutGame mBreakoutGame;

      //*********************************************************************************************************************************************
      //
      // Method Name: BreakoutKeyDown
      //
      // Description:
      //  Process the user input for when a key is pressed down. This is an abstract method that all concrete classes must implement.
      //
      // Arguments:
      //  theEventArguments - The events that occurred by the sender.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public abstract void BreakoutKeyDown(KeyEventArgs theEventArguments);

      //*********************************************************************************************************************************************
      //
      // Method Name: BreakoutKeyUp
      //
      // Description:
      //  Process the user input for when a key is released. This is an abstract method that all concrete classes must implement.
      //
      // Arguments:
      //  theEventArguments - The events that occurred by the sender.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public abstract void BreakoutKeyUp(KeyEventArgs theEventArguments);

      //*********************************************************************************************************************************************
      //
      // Method Name: Update
      //
      // Description:
      //  Call to update objects in the current state. This is an abstract method that all concrete classes must implement.
      //
      // Arguments:
      //  N/A
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public abstract void Update();

      //*********************************************************************************************************************************************
      //
      // Method Name: Draw
      //
      // Description:
      //  Draw objects in the current state. This is an abstract method that all concrete classes must implement.
      //
      // Arguments:
      //  theGraphics - TODO: Add description.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public abstract void Draw(Graphics theGraphics);

      //*********************************************************************************************************************************************
      //
      // Method Name: Draw
      //
      // Description:
      //  TODOL Add description.
      //
      // Arguments:
      //  theGraphics - TODO: Add description.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      protected void DrawPaddle(Graphics theGraphics)
      {
         mBreakoutGame.Paddle.Draw(theGraphics);
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: DrawBall
      //
      // Description:
      //  TODOL Add description.
      //
      // Arguments:
      //  theGraphics - TODO: Add description.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      protected void DrawBall(Graphics theGraphics)
      {
         // Create the colors used for the paddle.
         SolidBrush ballColor = new SolidBrush(Color.Blue);

         // Draw the paddle and balls onto the window.
         theGraphics.FillEllipse(ballColor,
                                 mBreakoutGame.Ball.BallRectangle);

         // Clean up allocated memory.
         ballColor.Dispose();
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: DrawMiniBalls
      //
      // Description:
      //  TODOL Add description.
      //
      // Arguments:
      //  theGraphics - TODO: Add description.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      protected void DrawMiniBalls(Graphics theGraphics)
      {
         // Create the colors used for the paddle.
         SolidBrush ballColor = new SolidBrush(Color.DarkGray);

         foreach (MiniBall currentMiniBall in mBreakoutGame.MiniBalls)
         {
            // Draw the paddle and balls onto the window.
            theGraphics.FillEllipse(ballColor,
                                    currentMiniBall.BallRectangle);
         }

         // Clean up allocated memory.
         ballColor.Dispose();
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: DrawBricks
      //
      // Description:
      //  TODOL Add description.
      //
      // Arguments:
      //  theGraphics - TODO: Add description.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      protected void DrawBricks(Graphics theGraphics)
      {
         // Draw the array of bricks currently in the game.
         foreach (Brick currentBrick in mBreakoutGame.Bricks)
         {
            currentBrick.Draw(theGraphics);
         }
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: DrawPowerUps
      //
      // Description:
      //  TODO: Add description.
      //
      // Arguments:
      //  theGraphics - TODO: Add description.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public void DrawPowerUps(Graphics theGraphics)
      {
         foreach (PowerUp currentPowerUp in mBreakoutGame.GetPowerUpList())
         {
            currentPowerUp.Draw(theGraphics);
         }
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: DrawHud
      //
      // Description:
      //  TODOL Add description.
      //
      // Arguments:
      //  theGraphics - TODO: Add description.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      protected void DrawHud(Graphics theGraphics)
      {
         // Create the colors used on the HUD.
         SolidBrush hudBackground = new SolidBrush(Color.YellowGreen);
         SolidBrush ballColor = new SolidBrush(Color.Blue);

         // Setup the text HUD.
         Font textFont = new System.Drawing.Font(BreakoutConstants.TEXT_FAMILY_NAME,
                                                 BreakoutConstants.HUD_TEXT_SIZE);
         SolidBrush textColor = new SolidBrush(Color.Black);
         StringFormat textFormat = new StringFormat
         {
            LineAlignment = StringAlignment.Center
         };

         // Draw the HUD Area
         theGraphics.FillRectangle(hudBackground,
                                   new Rectangle(0,
                                                 BreakoutConstants.SCREEN_PLAY_AREA_HEIGHT,
                                                 BreakoutConstants.SCREEN_HUD_AREA_WIDTH,
                                                 BreakoutConstants.SCREEN_HUD_AREA_HEIGHT));

         // Draw the number of lives the player has remaining
         theGraphics.DrawString("Lives Remaining",
                                textFont,
                                textColor,
                                20,
                                475,
                                textFormat);

         if (mBreakoutGame.NumberOfLives < 5)
         { 
            
            for (int count = 0; count < mBreakoutGame.NumberOfLives; count++)
            {
               theGraphics.FillEllipse(ballColor,
                                       new Rectangle(20 + ((10 + BreakoutConstants.BALL_WIDTH_AND_HEIGHT) * count),
                                                     500,
                                                     BreakoutConstants.BALL_WIDTH_AND_HEIGHT,
                                                     BreakoutConstants.BALL_WIDTH_AND_HEIGHT));
            }
         }
         else
         {
               theGraphics.FillEllipse(ballColor,
                                       new Rectangle(20 + BreakoutConstants.BALL_WIDTH_AND_HEIGHT,
                                                     500,
                                                     BreakoutConstants.BALL_WIDTH_AND_HEIGHT,
                                                     BreakoutConstants.BALL_WIDTH_AND_HEIGHT));

            // Draw the number of lives the player has remaining
            theGraphics.DrawString("x" + mBreakoutGame.NumberOfLives.ToString(),
                                   textFont,
                                   textColor,
                                   40 + BreakoutConstants.BALL_WIDTH_AND_HEIGHT,
                                   501 + (BreakoutConstants.BALL_WIDTH_AND_HEIGHT / BreakoutConstants.HALF),
                                   textFormat);
         }

         // Clean up allocated memory.
         hudBackground.Dispose();
         ballColor.Dispose();
         textFont.Dispose();
         textColor.Dispose();
         textFormat.Dispose();
      }
   }
}
