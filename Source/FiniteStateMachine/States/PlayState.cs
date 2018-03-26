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
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Breakout
{
   public class PlayState : State
   {
      // The current level the player is on.
      int mCurrentLevel;

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
      public PlayState(FiniteStateMachine theFiniteStateMachine)
      {  
          // Holds reference to the state machine.
         mFiniteStateMachine = theFiniteStateMachine;

         // Start the paddle and ball in position for a new match to start.
         mFiniteStateMachine.GetPaddle().NewMatch();
         mFiniteStateMachine.GetBall().NewMatch();

         // Start the game at the level of a new game.
         mCurrentLevel = BreakoutConstants.NEW_GAME_LEVEL;

         // Remove any possible leftover bricks.
         mFiniteStateMachine.GetBrickList().Clear();

         // Load the starting level of the game.
         LoadLevel(mCurrentLevel);
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: LoadLevel
      //
      // Description:
      //  TODO: Add description.
      //
      // Arguments:
      //  theLevelNumber - TODO: Add description.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      private void LoadLevel(int theLevelNumber)
      {
         // Create the string needed to load the level passed in from the levels folder.
         string levelString = BreakoutConstants.LEVELS_FOLDER + theLevelNumber.ToString() + BreakoutConstants.TEXT_FILE;

         // Open the level file.
         System.IO.StreamReader file = new System.IO.StreamReader(levelString);

         // String that holds information on the next line the level file.
         String line;
         // The current line number (used to determine the y coordinate of a brick).
         int lineNumber = 0;
         // The set of parsed lines (by using a delimiter) from the line being read in the file.
         string[] parsedLines;
         // The current parsed line number (used to determine the x coordinate of a brick).
         int parsedLineNumber = 0;

         // While the next line is not the end of the file build the array of bricks for the level including location and brick life level.
         while ((line = file.ReadLine()) != null)
         {
            // Read the line of by using a delimiter to parse where bricks are placed.
            parsedLines = Regex.Split(line, BreakoutConstants.LEVEL_DELIMITER);

            // Search the array of parsed lines to determine if a brick is to placed at the location in the file.
            foreach (string currentParsedLine in parsedLines)
            {
               // Determine if a brick is to displayed at this coordinate of the file.
               switch (currentParsedLine)
               {
                  // No brick to be placed at this location.
                  case BreakoutConstants.NO_BRICK_STRING:
                  {
                     break;
                  }
                  // Level one brick to be placed at this location.
                  case BreakoutConstants.LEVEL_ONE_BRICK_STRING:
                  {
                     AddBrick(parsedLineNumber * BreakoutConstants.BRICK_WIDTH,
                              lineNumber * BreakoutConstants.BRICK_HEIGHT,
                              BreakoutConstants.LEVEL_ONE_BRICK_INTEGER);
                     break;
                  }
                  // Level two brick to be placed at this location.
                  case BreakoutConstants.LEVEL_TWO_BRICK_STRING:
                  {
                     AddBrick(parsedLineNumber * BreakoutConstants.BRICK_WIDTH,
                              lineNumber * BreakoutConstants.BRICK_HEIGHT,
                              BreakoutConstants.LEVEL_TWO_BRICK_INTEGER);
                     break;
                  }
                  // Level three brick to be placed at this location.
                  case BreakoutConstants.LEVEL_THREE_BRICK_STRING:
                  {
                     AddBrick(parsedLineNumber * BreakoutConstants.BRICK_WIDTH,
                              lineNumber * BreakoutConstants.BRICK_HEIGHT,
                              BreakoutConstants.LEVEL_THREE_BRICK_INTEGER);
                     break;
                  }
                  // Unknown brick information, no brick to be placed at this location.
                  default:
                  {
                     break;
                  }
               }

               // Increment the parsed line number for the next parsed line to be read.
               parsedLineNumber++;
            }

            // Increment line number for the next line to be read.
            lineNumber++;
            // Reset the parsed line number.
            parsedLineNumber = 0;
         }

         // Close the file now that reading is done.
         file.Close();
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: AddBrick
      //
      // Description:
      //  TODO: Add description.
      //
      // Arguments:
      //  theCoordinateX - TODO: Add description.
      //  theCoordinateY - TODO: Add description.
      //  theBrickLevel - TODO: Add description.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      private void AddBrick(int theCoordinateX, int theCoordinateY, int theBrickLevel)
      {
         // Create a new brick object.
         Brick newBrick = new Brick(new Rectangle(theCoordinateX,
                                                  theCoordinateY,
                                                  BreakoutConstants.BRICK_WIDTH,
                                                  BreakoutConstants.BRICK_HEIGHT),
                                     theBrickLevel);

         // Add the new brick to the list of bricks in the level.
         mFiniteStateMachine.AddBrick(newBrick);
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: NewMatch
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
      private void NewMatch()
      {
         // Start the paddle and ball in position for a new match to start.
         mFiniteStateMachine.GetPaddle().NewMatch();
         mFiniteStateMachine.GetBall().NewMatch();
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: BreakoutKeyDown
      //
      // Description:
      //  Determine which key was pressed down:
      //      Left (Arrow) - Lets the program to know to move the paddle towards the left on the next update.
      //      Right (Arrow) - Lets the program to know to move the paddle towards the right on the next update.
      //
      // Arguments:
      //  theSender - The object that sent the event arguments.
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
            // The Left Arrow (<-) key is used for the paddle left movement. Indicate the paddle is now being moved towards the left.
            case Keys.Left:
            {
               mFiniteStateMachine.GetPaddle().SetLeftMovement(true);
               break;
            }
            // The Right Arrow (->) key is used for the paddle right movement. Indicate the paddle is now being moved towards the right.
            case Keys.Right:
            {
               mFiniteStateMachine.GetPaddle().SetRightMovement(true);
               break;
            }
            // The Space key is used to launch the ball at the beginning of a match. Indicate the ball is now being launched if it has not already been
            // launched.
            case Keys.Space:
            {
               if (mFiniteStateMachine.GetBall().GetBallLaunched() == false)
               {
                  // Note: Launch speed is negative to launch the ball towards the top of the screen.
                  mFiniteStateMachine.GetBall().SetBallVelocityY(-BreakoutConstants.BALL_LAUNCH_SPEED);
                  // Temp code start.
                  mFiniteStateMachine.GetBall().SetBallVelocityX(BreakoutConstants.BALL_LAUNCH_SPEED);
                  // Temp code end.
                  mFiniteStateMachine.GetBall().SetBallLaunched(true);
               }
               break;
            }
            // Thee P key is pressed and changes state to pause.
            case Keys.P:
            {
               mFiniteStateMachine.PushState(new PauseState(mFiniteStateMachine));
               break;
            }
            // The Escape key is pressed and ends the application.
            case Keys.Escape:
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
      //  Determine which key was release:
      //      Left (Arrow) - Lets the program to know to no longer move the paddle towards the left on the next update.
      //      Right (Arrow) - Lets the program to know to no longer move the paddle towards the right on the next update.
      //
      // Arguments:
      //  theSender - The object that sent the event arguments.
      //  theEventArguments - The events that occurred by the sender.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public override void BreakoutKeyUp(KeyEventArgs theEventArguments)
      {
         // Determine which key is being released.
         switch (theEventArguments.KeyCode)
         {
            // The Left Arrow (<-) is used for the paddle left movement. Indicate the paddle is no longer being moved towards the left.
            case Keys.Left:
            {
               mFiniteStateMachine.GetPaddle().SetLeftMovement(false);
               break;
            }
            // The Right Arrow (->) is used for the paddle right movement. Indicate the paddle is no longer being moved towards the right.
            case Keys.Right:
            {
               mFiniteStateMachine.GetPaddle().SetRightMovement(false);
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
         // Check if the level is complete.
         if (mFiniteStateMachine.GetBrickList().Count <= BreakoutConstants.BRICKS_LEFT_TO_COMPLETE_LEVEL)
         {
            // Increment to the next level.
            mCurrentLevel++;

            // Check if all levels are complete.
            if (mCurrentLevel > BreakoutConstants.FINAL_LEVEL)
            {
               mFiniteStateMachine.PopState();
            }
            // There are still more levels to complete, load the next level and start a new match.
            else
            {
               LoadLevel(mCurrentLevel);
               NewMatch();
            }
         }
         // The level has not finished.
         else
         {
            // Update the paddles on the window based on the keys pressed down or released.
            UpdatePaddle();
            UpdateBall();
            CheckBallCollision();
         }
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: UpdatePaddle
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
      private void UpdatePaddle()
      {
         // Check if the left button for the paddle is currently being pressed down.
         // Note: If both left AND right buttons are pressed the left button takes precedence.
         if (mFiniteStateMachine.GetPaddle().GetLeftMovement() == true)
         {
            // Set the paddle x-coordinate to draw further left by the paddle speed.
            mFiniteStateMachine.GetPaddle().SetPaddleCoordinateX(mFiniteStateMachine.GetPaddle().GetPaddleRectangle().X -
                                                                 BreakoutConstants.PADDLE_SPEED);

            // If the ball has not been launched yet, keep the ball centered directly above the paddle.
            if (mFiniteStateMachine.GetBall().GetBallLaunched() == false)
            {
               mFiniteStateMachine.GetBall().SetBallCoordinateX(mFiniteStateMachine.GetBall().GetBallRectangle().X - BreakoutConstants.PADDLE_SPEED);
            }

            // Prevent the paddle from going out of bounds at the left edge of the window.
            if (mFiniteStateMachine.GetPaddle().GetPaddleRectangle().X < BreakoutConstants.SCREEN_X_COORDINATE_LEFT)
            {
               mFiniteStateMachine.GetPaddle().SetPaddleCoordinateX(BreakoutConstants.SCREEN_X_COORDINATE_LEFT);

               // If the ball has not been launched yet, keep the ball centered directly above the paddle.
               if (mFiniteStateMachine.GetBall().GetBallLaunched() == false)
               {
                  mFiniteStateMachine.GetBall().SetBallCoordinateX(mFiniteStateMachine.GetPaddle().GetPaddleRectangle().X +
                                                                  (mFiniteStateMachine.GetPaddle().GetPaddleRectangle().Width / BreakoutConstants.HALF) -
                                                                  (mFiniteStateMachine.GetBall().GetBallRectangle().Width / BreakoutConstants.HALF));
               }
            }
         }
         // Check if the right button for the paddle is currently being pressed down.
         else if (mFiniteStateMachine.GetPaddle().GetRightMovement() == true)
         {
            // Set the paddle x-coordinate to draw further right by the paddle speed.
            mFiniteStateMachine.GetPaddle().SetPaddleCoordinateX(mFiniteStateMachine.GetPaddle().GetPaddleRectangle().X +
                                                                 BreakoutConstants.PADDLE_SPEED);

            // If the ball has not been launched yet, keep the ball centered directly above the paddle.
            if (mFiniteStateMachine.GetBall().GetBallLaunched() == false)
            {
               mFiniteStateMachine.GetBall().SetBallCoordinateX(mFiniteStateMachine.GetBall().GetBallRectangle().X + BreakoutConstants.PADDLE_SPEED);
            }

            // Prevent the paddle from going out of bounds at the right edge of the window.
            if (mFiniteStateMachine.GetPaddle().GetPaddleRectangle().X > (mFiniteStateMachine.GetForm().Size.Width - BreakoutConstants.PADDLE_WIDTH))
            {
               mFiniteStateMachine.GetPaddle().SetPaddleCoordinateX(mFiniteStateMachine.GetForm().Size.Width - BreakoutConstants.PADDLE_WIDTH);

               // If the ball has not been launched yet, keep the ball centered directly above the paddle.
               if (mFiniteStateMachine.GetBall().GetBallLaunched() == false)
               {
                  mFiniteStateMachine.GetBall().SetBallCoordinateX(mFiniteStateMachine.GetPaddle().GetPaddleRectangle().X +
                                                                   (mFiniteStateMachine.GetPaddle().GetPaddleRectangle().Width / BreakoutConstants.HALF) -
                                                                   (mFiniteStateMachine.GetBall().GetBallRectangle().Width / BreakoutConstants.HALF));
               }
            }
         }
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: UpdateBall
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
      private void UpdateBall()
      {
         mFiniteStateMachine.GetBall().UpdateBall();
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: CheckBallCollision
      //
      // Description:
      //  Check collision of the ball against the top, bottom, left, and right boundaries as well as the ball against the paddles. The ball will
      //  change in reverse horizontal direction when collision against a paddle and change reverse vertical direction when collision against the
      //  top and bottom boundaries. A ball collision against the
      //
      // Arguments:
      //  N/A
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      private void CheckBallCollision()
      {
         // Check for any ball collisions on the game border.
         mFiniteStateMachine.GetBall().CheckBallCollisionOnBorders(mFiniteStateMachine);

         // Check for any ball collisions on the paddle.
         mFiniteStateMachine.GetBall().CheckBallCollisionOnPaddle(mFiniteStateMachine);

         // Check for any ball collisions on the bricks.
         mFiniteStateMachine.GetBall().CheckBallCollisionOnBricks(mFiniteStateMachine);
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
         DrawPaddle(theEventArguments);
         DrawBall(theEventArguments);
         DrawBricks(theEventArguments);
         DrawHud(theEventArguments);
      }
   }
}
