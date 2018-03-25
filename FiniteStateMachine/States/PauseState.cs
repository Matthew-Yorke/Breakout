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
//************************************************************************************************************************************************

using System.Drawing;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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
      public PauseState(Form theForm, FiniteStateMachine theFiniteStateMachine)
      {
         // Hold the form reference passed in.
         mForm = theForm;

         // Holds reference to the state machine.
         mFiniteStateMachine = theFiniteStateMachine;
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
               mFiniteStateMachine.PopState();
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
      //  theEventArguments - TODO: Add description.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public override void Draw(PaintEventArgs theEventArguments)
      {
         // Setup the text for the scores and timers.
         Font textFont = new System.Drawing.Font(BreakoutConstants.TEXT_FAMILY_NAME,
                                                 BreakoutConstants.TEXT_SIZE);
         SolidBrush textColor = new SolidBrush(Color.Black);
         StringFormat textFormat = new StringFormat();
         textFormat.Alignment = StringAlignment.Center;
         textFormat.LineAlignment = StringAlignment.Center;
         
         // Draw the right player score to be centered on the right half (third quarter horizontal, half vertical) of the screen.
         theEventArguments.Graphics.DrawString(BreakoutConstants.PAUSE_STRING,
                                               textFont,
                                               textColor,
                                               mForm.Size.Width / BreakoutConstants.HALF,
                                               mForm.Size.Height / BreakoutConstants.HALF,
                                               textFormat);

         // Clean up allocated memory.
         textFont.Dispose();
      }
   }
}
