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

using System;
using System.Drawing;
using System.Windows.Forms;
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
      public PlayState(BreakoutGame theBreakoutGame)
      {  
          // Holds reference to the state machine.
         mBreakoutGame = theBreakoutGame;

         // Start the paddle and ball in position for a new match to start.
         mBreakoutGame.Paddle.NewMatch();
         mBreakoutGame.Ball.NewMatch();

         // Start the game at the level of a new game.
         mCurrentLevel = BreakoutConstants.NEW_GAME_LEVEL;

         // Remove any possible leftover bricks.
         mBreakoutGame.Bricks.Clear();

         // Remove any possible leftover power ups.
         mBreakoutGame.PowerUps.Clear();
         mBreakoutGame.MiniBalls.Clear();
         mBreakoutGame.MiniBallRemoveList.Clear();
         mBreakoutGame.Bullets.Clear();

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
                     AddBrick(Image.FromFile("../../../Images/BrickLevel1.png"),
                              parsedLineNumber * BreakoutConstants.BRICK_WIDTH,
                              lineNumber * BreakoutConstants.BRICK_HEIGHT,
                              BreakoutConstants.LEVEL_ONE_BRICK_INTEGER);
                     break;
                  }
                  // Level two brick to be placed at this location.
                  case BreakoutConstants.LEVEL_TWO_BRICK_STRING:
                  {
                     AddBrick(Image.FromFile("../../../Images/BrickLevel2.png"),
                              parsedLineNumber * BreakoutConstants.BRICK_WIDTH,
                              lineNumber * BreakoutConstants.BRICK_HEIGHT,
                              BreakoutConstants.LEVEL_TWO_BRICK_INTEGER);
                     break;
                  }
                  // Level three brick to be placed at this location.
                  case BreakoutConstants.LEVEL_THREE_BRICK_STRING:
                  {
                     AddBrick(Image.FromFile("../../../Images/BrickLevel3.png"),
                              parsedLineNumber * BreakoutConstants.BRICK_WIDTH,
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
      private void AddBrick(Image theImage, int theCoordinateX, int theCoordinateY, int theBrickLevel)
      {
         // Create a new brick object.
         Brick newBrick = new Brick(theImage,
                                    theCoordinateX,
                                    theCoordinateY,
                                    theBrickLevel);

         // Add the new brick to the list of bricks in the level.
         mBreakoutGame.AddBrick(newBrick);
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
         mBreakoutGame.Paddle.NewMatch();
         mBreakoutGame.Ball.NewMatch();
         mBreakoutGame.MiniBalls.Clear();
         mBreakoutGame.GetPowerUpList().Clear();
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
               mBreakoutGame.Paddle.MovePaddleLeft = true;
               break;
            }
            // The Right Arrow (->) key is used for the paddle right movement. Indicate the paddle is now being moved towards the right.
            case Keys.Right:
            {
               mBreakoutGame.Paddle.MovePaddleRight = true;
               break;
            }
            // The Space key is used to launch the ball at the beginning of a match. Indicate the ball is now being launched if it has not already been
            // launched. Also set the horizontal vector component based on the paddle vector component at the time of launching.
            case Keys.Space:
            {
               if (mBreakoutGame.Ball.BallLaunched == false)
               {
                  mBreakoutGame.Ball.Vector.SetComponentX(mBreakoutGame.Ball.Vector.ComponentX +
                                                             (mBreakoutGame.Paddle.Vector.ComponentX *
                                                              BreakoutConstants.PADDLE_VECTOR_TRANSFER_PERCENTAGE));
                  mBreakoutGame.Ball.BallLaunched = true;
               }
               break;
            }
            // Thee P key is pressed and changes state to pause.
            case Keys.P:
            {
               mBreakoutGame.PushState(new PauseState(mBreakoutGame));
               break;
            }
            // The Escape key is pressed and ends the application.
            case Keys.Escape:
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
               mBreakoutGame.Paddle.MovePaddleLeft = false;
               break;
            }
            // The Right Arrow (->) is used for the paddle right movement. Indicate the paddle is no longer being moved towards the right.
            case Keys.Right:
            {
               mBreakoutGame.Paddle.MovePaddleRight = false;
               break;
            }
            // The Z key is pressed. Shoot the paddle guns if the player has bullets left.
            case Keys.Z:
            {
               if (mBreakoutGame.GunAmmunition > 0)
               {
                  mBreakoutGame.GunAmmunition--;
                  mBreakoutGame.Bullets.Add(new Bullet(mBreakoutGame.Paddle.HitBox.X + BreakoutConstants.PADDLE_PADDING_TO_GUN,
                                                       mBreakoutGame.Paddle.HitBox.Y));
                  mBreakoutGame.Bullets.Add(new Bullet(mBreakoutGame.Paddle.HitBox.X + mBreakoutGame.Paddle.HitBox.Width -
                                                          BreakoutConstants.PADDLE_PADDING_TO_GUN - BreakoutConstants.BULLET_WIDTH,
                                                       mBreakoutGame.Paddle.HitBox.Y));
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
         if (mBreakoutGame.Bricks.Count <= BreakoutConstants.BRICKS_LEFT_TO_COMPLETE_LEVEL)
         {
            // Increment to the next level.
            mCurrentLevel++;

            // Check if all levels are complete.
            if (mCurrentLevel > BreakoutConstants.FINAL_LEVEL)
            {
               mBreakoutGame.PopState();
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
            UpdateMiniBalls();
            UpdateBullets();
            UpdatePowerUps();
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
         mBreakoutGame.Paddle.Update();
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: UpdateMiniBalls
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
      private void UpdateMiniBalls()
      {
         // Cycle through and update all mini balls.
         foreach (MiniBall currentMiniBall in mBreakoutGame.MiniBalls)
         {
            for (int count = 0; count < Math.Ceiling(currentMiniBall.Vector.Length); count++)
            { 
               currentMiniBall.Update();
               CheckMiniBallCollision(currentMiniBall);
            }
         }

         // Remove any mini balls that went out of bounds.
         mBreakoutGame.ProcessMiniBallRemoveList();
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: UpdateBullets
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
      private void UpdateBullets()
      {
         foreach (Bullet currentBullet in mBreakoutGame.Bullets)
         {
            for (int count = 0; count < Math.Ceiling(currentBullet.Vector.Length); count++)
            {
               currentBullet.Update();
            }

            currentBullet.UpdateParticles();
         }

         CheckBulletCollision();
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
         if (mBreakoutGame.Ball.BallLaunched == true)
         {
            for (int count = 0; count < Math.Ceiling(mBreakoutGame.Ball.Vector.Length); count++)
            { 
               mBreakoutGame.Ball.Update();
               CheckBallCollision();
            }
         }
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: UpdatePowerUps
      //
      // Description:
      //  Cycle through the power up list and make each power up fall further down the screen.
      //
      // Arguments:
      //  N/A
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      private void UpdatePowerUps()
      {
         foreach (PowerUp currentPowerUp in mBreakoutGame.GetPowerUpList())
         {
            for (int count = 0; count < Math.Ceiling(mBreakoutGame.Ball.Vector.Length); count++)
            {
               currentPowerUp.Update();
            }
         }

         CheckPowerUpCollision();
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
         mBreakoutGame.Ball.CheckBallCollisionOnBorders(mBreakoutGame);

         // Check for any ball collisions on the paddle.
         mBreakoutGame.Ball.CheckBallCollisionOnPaddle(mBreakoutGame);

         // Check for any ball collisions on the bricks.
         mBreakoutGame.Ball.CheckBallCollisionOnBricks(mBreakoutGame);
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: CheckMiniBallCollision
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
      private void CheckMiniBallCollision(MiniBall currentMiniBall)
      {
         // Check for any mini ball collisions on the game border.
         currentMiniBall.CheckBallCollisionOnBorders(mBreakoutGame);

         // Check for any mini ball collisions on the paddle.
         currentMiniBall.CheckBallCollisionOnPaddle(mBreakoutGame);

         // Check for any mini ball collisions on the bricks.
         currentMiniBall.CheckBallCollisionOnBricks(mBreakoutGame);
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: CheckBulletCollision
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
      private void CheckBulletCollision()
      {
         for (var bulletIndex = 0; bulletIndex < mBreakoutGame.Bullets.Count; bulletIndex++)
         {
            // Check if the bullet hit the top boundary and remove the bullet from the game if so.
            if (mBreakoutGame.Bullets[bulletIndex].HitBox.Y < 0)
            {
               mBreakoutGame.Bullets.RemoveAt(bulletIndex--);
               continue;
            }

            // Check each brick for collision against the bullet and remove the bullet if there is a collision.
            for (var brickIndex = 0; brickIndex < mBreakoutGame.Bricks.Count; brickIndex++)
            {
               if (mBreakoutGame.Bullets[bulletIndex].HitBox.IntersectsWith(mBreakoutGame.Bricks[brickIndex].HitBox))
               {
                  mBreakoutGame.Bricks[brickIndex].BrickLevel -= mBreakoutGame.Bullets[bulletIndex].Damage;

                  mBreakoutGame.Bullets.RemoveAt(bulletIndex--);

                  // Check if the brick level has hit the destroy level and remove the brick form the array list since it is destroyed.
                  if (mBreakoutGame.Bricks[brickIndex].BrickLevel <= BreakoutConstants.BRICK_DESTRUCTION_LEVEL)
                  {
                     mBreakoutGame.Bricks[brickIndex].Destroyed(mBreakoutGame);
                     // Remove the brick from the brick list since it is now destroyed.
                     mBreakoutGame.Bricks.RemoveAt(brickIndex--);
                  }
                  // Since the brick is not destroyed, update the brick image.
                  else
                  {
                     mBreakoutGame.Bricks[brickIndex].UpdateBrickImage("../../../Images/BrickLevel" +
                                                                       mBreakoutGame.Bricks[brickIndex].BrickLevel.ToString() +
                                                                       ".png");
                  }

                  break;
               }
            }
         }
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: CheckPowerUpCollision
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
      private void CheckPowerUpCollision()
      {

         // Check if the ball hits a brick
         for (var index = 0; index < mBreakoutGame.GetPowerUpList().Count; index++)
         {
            // Check if the power up hits the paddle. Execute the power up ability and remove the power up from the list.
            if (mBreakoutGame.GetPowerUpList()[index].HitBox.IntersectsWith(mBreakoutGame.Paddle.HitBox))
            {
               mBreakoutGame.GetPowerUpList()[index].ExecutePowerUp(mBreakoutGame);
               mBreakoutGame.GetPowerUpList().RemoveAt(index--);
            }
            // Check if the power up hits the bottom border and remove it from the list of power ups if so.
            else if (mBreakoutGame.GetPowerUpList()[index].HitBox.Y > BreakoutConstants.SCREEN_PLAY_AREA_HEIGHT)
            {
               mBreakoutGame.GetPowerUpList().RemoveAt(index--);
            }
         }
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
         DrawPaddle(theGraphics);
         DrawMiniBalls(theGraphics);
         DrawBall(theGraphics);
         DrawBricks(theGraphics);
         DrawHud(theGraphics);
      }
   }
}
