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
      protected FiniteStateMachine mFiniteStateMachine;

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
      //  theEventArguments - The events that occurred by the sender.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public abstract void Draw(PaintEventArgs theEventArguments);

      //*********************************************************************************************************************************************
      //
      // Method Name: Draw
      //
      // Description:
      //  TODOL Add description.
      //
      // Arguments:
      //  theEventArguments - The events that occurred by the sender.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      protected void DrawPaddle(PaintEventArgs theEventArguments)
      {
         // Create the colors used for the paddle.
         SolidBrush paddleColor = new SolidBrush(Color.Black);

         // Draw the paddle onto the window.
         theEventArguments.Graphics.FillRectangle(paddleColor,
                                                  mFiniteStateMachine.GetPaddle().GetPaddleRectangle());

         // Clean up allocated memory.
         paddleColor.Dispose();
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: DrawBall
      //
      // Description:
      //  TODOL Add description.
      //
      // Arguments:
      //  theEventArguments - The events that occurred by the sender.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      protected void DrawBall(PaintEventArgs theEventArguments)
      {
         // Create the colors used for the paddle.
         SolidBrush ballColor = new SolidBrush(Color.Blue);

         // Draw the paddle and balls onto the window.
         theEventArguments.Graphics.FillEllipse(ballColor,
                                                mFiniteStateMachine.GetBall().GetBallRectangle());

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
      //  theEventArguments - The events that occurred by the sender.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      protected void DrawBricks(PaintEventArgs theEventArguments)
      {
         // Create the colors used for the bricks.
         SolidBrush levelOneBrickColor = new SolidBrush(Color.Green);
         SolidBrush levelTwoBrickColor = new SolidBrush(Color.Yellow);
         SolidBrush levelThreeBrickColor = new SolidBrush(Color.Red);
         Pen brickBorderPen = new Pen(Color.Black, 2);

         // Draw the array of bricks currently in the game.
         foreach (Brick currentBrick in mFiniteStateMachine.GetBrickList())
         {
            // Determine the level of the brick.
            switch (currentBrick.GetBrickLevel())
            {
               case BreakoutConstants.LEVEL_ONE_BRICK_INTEGER:
               {
                  theEventArguments.Graphics.FillRectangle(levelOneBrickColor,
                                                           currentBrick.GetBrickRectangle());
                  theEventArguments.Graphics.DrawRectangle(brickBorderPen,
                                                           currentBrick.GetBrickRectangle());
                  break;
               }
               case BreakoutConstants.LEVEL_TWO_BRICK_INTEGER:
               {
                  theEventArguments.Graphics.FillRectangle(levelTwoBrickColor,
                                                           currentBrick.GetBrickRectangle());
                  theEventArguments.Graphics.DrawRectangle(brickBorderPen,
                                                           currentBrick.GetBrickRectangle());
                  break;
               }
               case BreakoutConstants.LEVEL_THREE_BRICK_INTEGER:
               {
                  theEventArguments.Graphics.FillRectangle(levelThreeBrickColor,
                                                           currentBrick.GetBrickRectangle());
                  theEventArguments.Graphics.DrawRectangle(brickBorderPen,
                                                           currentBrick.GetBrickRectangle());
                  break;
               }
               default:
               {
                  break;
               }
            }
         }

         // Clean up allocated memory.
         levelOneBrickColor.Dispose();
         levelTwoBrickColor.Dispose();
         levelThreeBrickColor.Dispose();
         brickBorderPen.Dispose();
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: DrawHud
      //
      // Description:
      //  TODOL Add description.
      //
      // Arguments:
      //  theEventArguments - The events that occurred by the sender.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      protected void DrawHud(PaintEventArgs theEventArguments)
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
         theEventArguments.Graphics.FillRectangle(hudBackground,
                                                  new Rectangle(0,
                                                                BreakoutConstants.SCREEN_PLAY_AREA_HEIGHT,
                                                                BreakoutConstants.SCREEN_HUD_AREA_WIDTH,
                                                                BreakoutConstants.SCREEN_HUD_AREA_HEIGHT));

         // Draw the number of lives the player has remaining
         theEventArguments.Graphics.DrawString("Lives Remaining",
                                               textFont,
                                               textColor,
                                               20,
                                               475,
                                               textFormat);
         for (int count = 0; count < mFiniteStateMachine.GetNumberOfLives(); count++)
         {
            theEventArguments.Graphics.FillEllipse(ballColor,
                                                   new Rectangle(20 + ((10 + BreakoutConstants.BALL_WIDTH_AND_HEIGHT) * count),
                                                                 500,
                                                                 BreakoutConstants.BALL_WIDTH_AND_HEIGHT,
                                                                 BreakoutConstants.BALL_WIDTH_AND_HEIGHT));
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
