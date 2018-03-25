//***************************************************************************************************************************************************
//
// File Name: FiniteStateMachine.cs
//
// Description:
//  Handles the finite state machine of the breakout game. The states are organized onto a stack and the objects are processed by using the state on
//  the top of the stack. New states can be pushed onto the stack and old states can be removed. The state changes are handled within concrete state
//  classes.
//
// Change History:
//  Author               Date           Description
//  Matthew D. Yorke     MM/DD/2018     TODO: Add description.
//
//***************************************************************************************************************************************************

using System.Windows.Forms;
using System.Collections.Generic;

namespace Breakout
{
   public class FiniteStateMachine
   {
      // Tracks the current state the game is in.
      private Stack<State> mCurrentState;

      // Tracks reference to the form this game is being drawn to.
      private Form mForm;

      //*********************************************************************************************************************************************
      //
      // Method Name: FiniteStateMachine
      //
      // Description:
      //  TODO: Add description.
      //
      // Arguments:
      //  theForm - TODO: Add description.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public FiniteStateMachine(Form theForm)
      {
         // Hold the form reference for the game.
         mForm = theForm;
         // Initialize the state stack.
         mCurrentState = new Stack<State>();
         // The push on the initial play state.
         mCurrentState.Push(new StartScreenState(this));
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: GetForm
      //
      // Description:
      //  Returns the reference of the form being used for the finite state machine.
      //
      // Arguments:
      //  N/A
      //
      // Return:
      //  Returns the form reference.
      //
      //*********************************************************************************************************************************************
      public Form GetForm()
      {
         return mForm;
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: PushState
      //
      // Description:
      //  Pushes a new state onto the stack of states.
      //
      // Arguments:
      //  theState - The state to be pushed onto the stack of states.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public void PushState(State theState)
      {
         mCurrentState.Push(theState);
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: PopState
      //
      // Description:
      //  Pops the top state on the stack of state.
      //
      // Arguments:
      //  N/A
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public void PopState()
      {
         mCurrentState.Pop();
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: BreakoutKeyDown
      //
      // Description:
      //  Process the key pressed down from the state on top of the state stack.
      //
      // Arguments:
      //  N/A
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public void BreakoutKeyDown(KeyEventArgs theEventArguments)
      {
         mCurrentState.Peek().BreakoutKeyDown(theEventArguments);
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: BreakoutKeyUp
      //
      // Description:
      //  Process the key released from the state on top of the state stack.
      //
      // Arguments:
      //  N/A
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public void BreakoutKeyUp(KeyEventArgs theEventArguments)
      {
         mCurrentState.Peek().BreakoutKeyUp(theEventArguments);
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: Update
      //
      // Description:
      //  Call to update the objects on the screen from the top state on the stack of states.
      //
      // Arguments:
      //  N/A
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public void Update()
      {
         mCurrentState.Peek().Update();
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: Draw
      //
      // Description:
      //  Call to draw the objects on the screen from the top state on the stack of states.
      //
      // Arguments:
      //  theEventArguments - The events that occurred by the sender.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public void Draw(PaintEventArgs theEventArguments)
      {
         mCurrentState.Peek().Draw(theEventArguments);
      }
   }
}
