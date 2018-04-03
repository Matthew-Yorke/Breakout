//************************************************************************************************************************************************
//
// File Name: PlayState.cs
//
// Description:
//  TODO: Add description.
//
// Change History:
//  Author               Date           Description
//  Matthew D. Yorke     MM/DD/2018     TODO: Add description.
//
//************************************************************************************************************************************************

using System.Drawing;
using System.Windows.Forms;

namespace Breakout
{
   public class PauseState : State
   {

      //*********************************************************************************************************************************************
      //
      // Method Name: PlayState
      //
      // Description:
      //  TODO: Add description.
      //
      // Arguments:
      //  N/A
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public PauseState(BreakoutGame theBreakoutGame)
      {
         // Holds reference to the state machine.
         mBreakoutGame = theBreakoutGame;
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: BreakoutKeyDown
      //
      // Description:
      //  TODO: Add description.
      //
      // Arguments:
      //  theEventArguments - The events that occurred by the sender.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public override void BreakoutKeyDown(KeyEventArgs theEventArguments)
      {
         switch (theEventArguments.KeyCode)
         {
            // The P key is pressed and resumes the game.
            case Keys.P:
            {
               mBreakoutGame.PopState();
               break;
            }
            default:
            {
               break;
            }
         }
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: BreakoutKeyUp
      //
      // Description:
      //  TODO: Add description.
      //
      // Arguments:
      //  theEventArguments - The events that occurred by the sender.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public override void BreakoutKeyUp(KeyEventArgs theEventArguments)
      {
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: Update
      //
      // Description:
      //  TODO: Add description.
      //
      // Arguments:
      //  N/A
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public override void Update()
      {
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: Draw
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
      public override void Draw(Graphics theGraphics)
      {
         DrawPowerUps(theGraphics);
         DrawBullets(theGraphics);
         DrawRockets(theGraphics);
         DrawParticles(theGraphics);
         DrawPaddle(theGraphics);
         DrawMiniBalls(theGraphics);
         DrawBall(theGraphics);
         DrawBricks(theGraphics);
         DrawHud(theGraphics);
         DrawPauseScreen(theGraphics);
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: DrawPauseScreen
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
      private void DrawPauseScreen(Graphics theGraphics)
      {
         // Setup the text for the scores and timers.
         Font textFont = new System.Drawing.Font(BreakoutConstants.TEXT_FAMILY_NAME,
                                                 BreakoutConstants.PAUSE_SCREEN_TEXT_SIZE);
         SolidBrush textColor = new SolidBrush(Color.Black);
         StringFormat textFormat = new StringFormat
         {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center
         };

         // Draw the right player score to be centered on the right half (third quarter horizontal, half vertical) of the screen.
         theGraphics.DrawString(BreakoutConstants.PAUSE_STRING,
                                textFont,
                                textColor,
                                mBreakoutGame.Form.Size.Width / BreakoutConstants.HALF,
                                mBreakoutGame.Form.Size.Height / BreakoutConstants.HALF,
                                textFormat);

         // Clean up allocated memory.
         textFont.Dispose();
      }
   }
}
