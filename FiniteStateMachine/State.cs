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

namespace Breakout
{
   public abstract class State
   {
      protected FiniteStateMachine mFiniteStateMachine;
      
      protected Form mForm;

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
   }
}
