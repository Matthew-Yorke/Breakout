//************************************************************************************************************************************************
//
// File Name: StartScreenState.cs
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
   public class StartScreenState : State
   {
      enum Selection { NEW_GAME, EXIT }
      Selection mSelection;

      //*********************************************************************************************************************************************
      //
      // Method Name: StartScreenState
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
      public StartScreenState(FiniteStateMachine theFiniteStateMachine)
      {
         // Holds reference to the state machine.
         mFiniteStateMachine = theFiniteStateMachine;

         // Start the selection as the top enumeration (same as the top of list of selections on the screen).
         mSelection = Selection.NEW_GAME;
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
            // The down arrow was pressed, go to the next option down on the list.
            case Keys.Down:
            {
               mSelection = (Selection)(((int)mSelection + BreakoutConstants.ENUM_OFFSET) % BreakoutConstants.NUMBER_OPTIONS_ON_START_SCREEN);
               break;
            }
            // The up arrow was pressed, go to the next option up on the list.
            case Keys.Up:
            {
               mSelection = (Selection)(((int)mSelection - BreakoutConstants.ENUM_OFFSET) % BreakoutConstants.NUMBER_OPTIONS_ON_START_SCREEN);
               if (mSelection < BreakoutConstants.ENUM_FIRST_INTEGER)
               {
                  mSelection = (Selection)(BreakoutConstants.NUMBER_OPTIONS_ON_START_SCREEN - BreakoutConstants.ENUM_OFFSET);
               }
               break;
            }
            // The Enter key is pressed and determines which selection was made on the menu.
            case Keys.Enter:
            {
               // Check if the new game option was selected and push a new play state onto the stack if so.
               if(mSelection == Selection.NEW_GAME)
               {
                  mFiniteStateMachine.PushState(new PlayState(mFiniteStateMachine));
               }
               // Check if the exit option was selected and exit the application if so.
               else if (mSelection == Selection.EXIT)
               {
                  Application.Exit();
               }
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
         // Setup the color of the ball the indicates the selector .
         SolidBrush ballColor = new SolidBrush(Color.Blue);

         // Setup the text for the scores and timers.
         Font textFont = new System.Drawing.Font(BreakoutConstants.TEXT_FAMILY_NAME,
                                                 BreakoutConstants.START_SCREEN_TEXT_SIZE);
         SolidBrush textColor = new SolidBrush(Color.Black);
         StringFormat textFormat = new StringFormat();
         textFormat.Alignment = StringAlignment.Center;
         textFormat.LineAlignment = StringAlignment.Center;

         // Draw the ball, which indicates the selector.
         theGraphics.FillEllipse(ballColor,
                                 new Rectangle((mFiniteStateMachine.Form.Size.Width / BreakoutConstants.HALF) - 150,
                                               240 + ((int)mSelection * (int)((float)BreakoutConstants.START_SCREEN_TEXT_SIZE * 1.5F)),
                                               BreakoutConstants.BALL_WIDTH_AND_HEIGHT,
                                               BreakoutConstants.BALL_WIDTH_AND_HEIGHT));


         // Draw the right player score to be centered on the right half (third quarter horizontal, half vertical) of the screen.
         theGraphics.DrawString("New Game\nExit",
                                textFont,
                                textColor,
                                mFiniteStateMachine.Form.Size.Width / BreakoutConstants.HALF,
                                mFiniteStateMachine.Form.Size.Height / BreakoutConstants.HALF,
                                textFormat);

         // Clean up allocated memory.
         ballColor.Dispose();
         textFont.Dispose();
         textColor.Dispose();
         textFormat.Dispose();
      }
   }
}
