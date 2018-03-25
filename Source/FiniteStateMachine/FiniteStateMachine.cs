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

      // The paddle image depicting the location and size of the image.
      private Rectangle mPaddle;

      // The ball image depicting the location and size of the image.
      private Rectangle mBall;

      // List of active bricks in the level.
      private List<Brick> mBricks;

      // Tracks the number of lives the player has left.
      int mNumberOfLives;

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

         // Start the paddle at the center of the screen and with a padding from the bottom of the screen.
         mPaddle = new Rectangle((mForm.Size.Width / BreakoutConstants.HALF) - (BreakoutConstants.PADDLE_WIDTH / BreakoutConstants.HALF),
                                 BreakoutConstants.SCREEN_PLAY_AREA_HEIGHT - BreakoutConstants.PADDLE_BOUNDARY_PADDING,
                                 BreakoutConstants.PADDLE_WIDTH,
                                 BreakoutConstants.PADDLE_HEIGHT);

         // Start the ball center of where the paddle starts, but directly above the paddle.
         mBall = new Rectangle((mForm.Size.Width / BreakoutConstants.HALF) - (BreakoutConstants.BALL_WIDTH_AND_HEIGHT / BreakoutConstants.HALF),
                               BreakoutConstants.SCREEN_PLAY_AREA_HEIGHT - BreakoutConstants.PADDLE_BOUNDARY_PADDING - BreakoutConstants.BALL_WIDTH_AND_HEIGHT,
                               BreakoutConstants.BALL_WIDTH_AND_HEIGHT,
                               BreakoutConstants.BALL_WIDTH_AND_HEIGHT);

         // Create the new list of bricks for the game.
         mBricks = new List<Brick>();

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
      public Rectangle GetPaddle()
      {
         return mPaddle;
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: SetPaddleCoordinateX
      //
      // Description:
      //  TODO: Add description.
      //
      // Arguments:
      //  theCoordinateX - TODO: Add description.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public void SetPaddleCoordinateX(int theCoordinateX)
      {
         mPaddle.X = theCoordinateX;
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: SetPaddleCoordinateY
      //
      // Description:
      //  TODO: Add description.
      //
      // Arguments:
      //  theCoordinateY - TODO: Add description.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public void SetPaddleCoordinateY(int theCoordinateY)
      {
         mPaddle.Y = theCoordinateY;
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
      public Rectangle GetBall()
      {
         return mBall;
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: SetBallCoordinateX
      //
      // Description:
      //  TODO: Add description.
      //
      // Arguments:
      //  theCoordinateX - TODO: Add description.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public void SetBallCoordinateX(int theCoordinateX)
      {
         mBall.X = theCoordinateX;
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: SetBallCoordinateY
      //
      // Description:
      //  TODO: Add description.
      //
      // Arguments:
      //  theCoordinateY - TODO: Add description.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public void SetBallCoordinateY(int theCoordinateY)
      {
         mBall.Y = theCoordinateY;
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
