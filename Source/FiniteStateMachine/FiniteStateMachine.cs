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
      public Form Form
      {
         get {return mForm;}
         set {mForm = value;}
      }

      // The paddle object used in the game. Includes information about location, size, and movement direction.
      private Paddle mPaddle;
      public Paddle Paddle
      {
         get {return mPaddle;}
         set {mPaddle = value;}
      }

      // The ball object used in the game. Includes information about location, size, velocity, if it has been launched, and damage.
      private Ball mBall;
      public Ball Ball
      {
         get {return mBall;}
         set {mBall = value;}
      }

      // List of active mini balls in the level.
      private List<MiniBall> mMiniBalls;
      public List<MiniBall> MiniBalls
      {
         get {return mMiniBalls;}
         set {mMiniBalls = value;}
      }

      // List of active mini balls to remove.
      private List<MiniBall> mMiniBallRemoveList;
      public List<MiniBall> MiniBallRemoveList
      {
         get {return mMiniBallRemoveList;}
         set {mMiniBallRemoveList = value;}
      }

      // List of active bricks in the level.
      private List<Brick> mBricks;
      public List<Brick> Bricks
      {
         get {return mBricks;}
         set {mBricks = value;}
      }

      // The factory used to create power ups when a brick is destroyed.
      PowerUpFactory mPowerUpFactory;

      // List of power ups currently on the screen.
      private List<PowerUp> mPowerUps;
      public List<PowerUp> PowerUps
      {
         get {return mPowerUps;}
         set {mPowerUps = value;}
      }

      // Tracks the number of lives the player has left.
      private int mNumberOfLives;
      public int NumberOfLives
      {
         get {return mNumberOfLives;}
         set {mNumberOfLives = value;}
      }

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

         // Create the new list of mini balls for the game.
         mMiniBalls = new List<MiniBall>();

         // Create new list of mini balls to be removed.
         mMiniBallRemoveList = new List<MiniBall>();

         // Create the new list of bricks for the game.
         mBricks = new List<Brick>();

         // Create a new power up factory class.
         mPowerUpFactory = new PowerUpFactoryConcrete();

         // Create a new list of power ups for the game.
         mPowerUps = new List<PowerUp>();

         // Initialize the number of lives the players will have left.
         mNumberOfLives = BreakoutConstants.INITIAL_LIVES_REMAINING;
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: GetPowerUpFactory
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
      public PowerUpFactory GetPowerUpFactory()
      {
         return mPowerUpFactory;
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
      // Method Name: ProcessMiniBallRemoveList
      //
      // Description:
      //  TODO: Add description.
      //
      // Arguments:
      //  theFiniteStateMachine - TODO: Add description.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public void ProcessMiniBallRemoveList()
      {
         mMiniBalls.RemoveAll(element => mMiniBallRemoveList.Contains(element));
         mMiniBallRemoveList.Clear();
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
      //  theGraphics - TODO: Add description.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public void Draw(Graphics theGraphics)
      {
         mCurrentState.Peek().Draw(theGraphics);
      }
   }
}
