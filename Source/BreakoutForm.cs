//***************************************************************************************************************************************************
//
// File Name: BreakoutForm.cs
//
// Description:
//  This class creates the form for the breakout game and kicks off the game itself.
//
// Change History:
//  Author               Date           Description
//  Matthew D. Yorke     MM/DD/2018     TODO: Add description.
//
//***************************************************************************************************************************************************

using System;
using System.Windows.Forms;

namespace Breakout
{
   public partial class BreakoutForm : Form
   {
      // The time object that is used to periodically tick to update the screen.
      Timer mTimer;

      // Used to track the current state the game is in.
      BreakoutGame mBreakoutGame;

      //*********************************************************************************************************************************************
      //
      // Method Name: Breakout
      //
      // Description:
      //  Constructor to create the form components, kick off the game, indicate key input callbacks, and start timer call back for updating the
      //  game.
      //
      // Arguments:
      //  N/A
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public BreakoutForm()
      {
         InitializeComponent();

         // Start the breakout game.
         mBreakoutGame = new BreakoutGame(this);

         // Indicate the painting callback method to use when a repaint is called.
         this.Paint += Draw;

         // Indicate that key events will be used in this window.
         this.KeyPreview = true;
         // Indicate the callback method to use when a key is pressed down.
         this.KeyDown += BreakoutKeyDown;
         // Indicate the callback method to use when a key is released.
         this.KeyUp += BreakoutKeyUp;

         // Start up the periodic timer.
         mTimer = new Timer();
         mTimer.Tick += new EventHandler(TimerTick);
         mTimer.Interval = BreakoutConstants.TIMER_INTERVAL;
         mTimer.Enabled = true;
         mTimer.Start();
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: BreakoutFormLoad
      //
      // Description:
      //  As it stands now this is method is needed to run the program, but has no implementation.
      //
      // Arguments:
      //  theSender - The object that sent the event arguments.
      //  theEventArguments - The events that occurred by the sender.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      private void BreakoutFormLoad(object theSender, EventArgs theEventArguments)
      {
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: BreakoutKeyDown
      //
      // Description:
      //  Call to handle operator key down presses. Dependant on the state of the game, key presses will change functionality.
      //
      // Arguments:
      //  theSender - The object that sent the event arguments.
      //  theEventArguments - The events that occurred by the sender.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      private void BreakoutKeyDown(Object theSender, KeyEventArgs theEventArguments)
      {
         mBreakoutGame.BreakoutKeyDown(theEventArguments);
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: BreakoutKeyUp
      //
      // Description:
      //  Call to handle operator key releases. Dependant on the state of the game, key presses will change functionality.
      //
      // Arguments:
      //  theSender - The object that sent the event arguments.
      //  theEventArguments - The events that occurred by the sender.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      private void BreakoutKeyUp(Object theSender, KeyEventArgs theEventArguments)
      {
         mBreakoutGame.BreakoutKeyUp(theEventArguments);
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: TimerTick
      //
      // Description:
      //  Call to update the object in the window and then indicate a redraw is needed.
      //
      // Arguments:
      //  theSender - The object that sent the event arguments.
      //  theEventArguments - The events that occurred by the sender.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      private void TimerTick(Object theSender, EventArgs theEventArguments)
      {
         // Update the objects on the window.
         UpdateWindow();
         // Call to redraw the object on the window.
         Invalidate();
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: UpdateWindow
      //
      // Description:
      //  Call to update the objects in the game based on the current game state.
      //
      // Arguments:
      //  N/A
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      private void UpdateWindow()
      {
         mBreakoutGame.Update();
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: Draw
      //
      // Description:
      //  Draw the game objects onto the window based on the current game state.
      //
      // Arguments:
      //  theSender - The object that sent the event arguments.
      //  theEventArguments - The events that occurred by the sender.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      private void Draw(Object theSender, PaintEventArgs theEventArguments)
      {
         mBreakoutGame.Draw(theEventArguments.Graphics);
      }
   }
}
