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
using System.Drawing;

namespace Breakout
{
   public class FiniteStateMachine
   {
      // Tracks the current state the game is in.
      private Stack<State> mCurrentState;

      // Tracks reference to the form this game is being drawn to.
      private Form mForm;

      // The paddle object used in the game. Includes information about location, size, and movement direction.
      private Paddle mPaddle;

      // The ball object used in the game. Includes information about location, size, velocity, if it has been launched, and damage.
      private Ball mBall;

      // List of active bricks in the level.
      private List<Brick> mBricks;

      // List of power ups currently on the screen.
      private List<PowerUp> mPowerUps;

      // Tracks the number of lives the player has left.
      private int mNumberOfLives;

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

         // Create the paddle for the game
         mPaddle = new Paddle();

         // Create the ball for the game.
         mBall = new Ball();

         // Create the new list of bricks for the game.
         mBricks = new List<Brick>();

         // Create a new list of power ups for the game.
         mPowerUps = new List<PowerUp>();

         // Initialize the number of lives the players will have left.
         mNumberOfLives = BreakoutConstants.INITIAL_LIVES_REMAINING;
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
      // Method Name: GetPaddle
      //
      // Description:
      //  TODO: Add description.
      //
      // Arguments:
      //  N/A
      //
      // Return:
      //  TODO: Add description.
      //
      //*********************************************************************************************************************************************
      public Paddle GetPaddle()
      {
         return mPaddle;
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: GetBall
      //
      // Description:
      //  TODO: Add description.
      //
      // Arguments:
      //  N/A
      //
      // Return:
      //  TODO: Add description.
      //
      //*********************************************************************************************************************************************
      public Ball GetBall()
      {
         return mBall;
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: GetBrickList
      //
      // Description:
      //  TODO: Add description.
      //
      // Arguments:
      //  N/A
      //
      // Return:
      //  TODO: Add description.
      //
      //*********************************************************************************************************************************************
      public List<Brick> GetBrickList()
      {
         return mBricks;
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: GetPowerUpList
      //
      // Description:
      //  TODO: Add description.
      //
      // Arguments:
      //  N/A
      //
      // Return:
      //  TODO: Add description.
      //
      //*********************************************************************************************************************************************
      public List<PowerUp> GetPowerUpList()
      {
         return mPowerUps;
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: AddBrick
      //
      // Description:
      //  TODO: Add description.
      //
      // Arguments:
      //  theBrick - TODO: Add description.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public void AddBrick(Brick theBrick)
      {
         mBricks.Add(theBrick);
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: RemoveBrick
      //
      // Description:
      //  TODO: Add description.
      //
      // Arguments:
      //  theBrick - TODO: Add description.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public void RemoveBrick(int theIndex)
      {
         mBricks.RemoveAt(theIndex);
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: GetNumberOfLives
      //
      // Description:
      //  TODO: Add description.
      //
      // Arguments:
      //  N/A
      //
      // Return:
      //  TODO: Add description.
      //
      //*********************************************************************************************************************************************
      public int GetNumberOfLives()
      {
         return mNumberOfLives;
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: GetNumberOfLives
      //
      // Description:
      //  TODO: Add description.
      //
      // Arguments:
      //  theNumberOfLives = TODO: Add description.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public void SetNumberOfLives(int theNumberOfLives)
      {
         mNumberOfLives = theNumberOfLives;
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
