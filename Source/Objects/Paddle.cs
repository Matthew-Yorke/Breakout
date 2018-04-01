//***************************************************************************************************************************************************
//
// File Name: Paddle.cs
//
// Description:
//  This class handles the functionality of the paddle for the game. The paddle is created at a slight padding away from the bottom border. The
//  paddle is centered horizontally on creation and during a new match. This class also handles the updating of the paddle based on if the left/right
//  movement buttons are pressed down or not.
//
// Change History:
//  Author               Date           Description
//  Matthew D. Yorke     MM/DD/2018     TODO: Add description.
//
//***************************************************************************************************************************************************

using System;
using System.Drawing;

namespace Breakout
{
   public class Paddle : MasterObject
   {
      // Determines during an update if the player is pressing the key to move the paddle left (true) or not (false).
      bool mMovePaddleLeft;
      public bool MovePaddleLeft
      {
         get {return mMovePaddleLeft;}
         set {mMovePaddleLeft = value;}
      }

      // Determines during an update if the player is pressing the key to move the paddle right (true) or not (false).
      bool mMovePaddleRight;
      public bool MovePaddleRight
      {
         get {return mMovePaddleRight;}
         set {mMovePaddleRight = value;}
      }

      // Holds the game object. Used to access the ball object for updating before the ball is launched.
      BreakoutGame mBreakoutGame;

      //*********************************************************************************************************************************************
      //
      // Method Name: Paddle
      //
      // Description:
      //  Constructor for the paddle object. The paddle is created at the center of the screen with a slight padding away from the bottom border.
      //  The paddle starts with no horizontal movement.
      //
      // Arguments:
      //  theBreakoutGame - Reference to the game object.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public Paddle(BreakoutGame theBreakoutGame) :
      base(Image.FromFile(BreakoutConstants.PADDLE_IMAGE_FILE),
           (BreakoutConstants.SCREEN_PLAY_AREA_WIDTH / BreakoutConstants.HALF) - (BreakoutConstants.PADDLE_WIDTH / BreakoutConstants.HALF),
           BreakoutConstants.SCREEN_PLAY_AREA_HEIGHT - BreakoutConstants.PADDLE_BOUNDARY_PADDING,
           new Vector2D(0.0F, 0.0F))
      {
         mBreakoutGame = theBreakoutGame;

         // The paddle starts with no movement.
         mMovePaddleLeft = false;
         mMovePaddleRight = false;
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: NewMatch
      //
      // Description:
      //  Resets the paddle object back to the center of the screen with no horizontal movement.
      //
      // Arguments:
      //  N/A
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public void NewMatch()
      {
         // Reset the paddle to be in the centered horizontally.
         mHitBox.X = (BreakoutConstants.SCREEN_PLAY_AREA_WIDTH / BreakoutConstants.HALF) - (mHitBox.Width / BreakoutConstants.HALF);

         // The paddle starts with no movement on a new match.
         mMovePaddleLeft = false;
         mMovePaddleRight = false;
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: Update
      //
      // Description:
      //  Update the paddle based on if the left/right movement buttons are pressed. The left movement takes precedence over the right movement. The
      //  paddle is restricted within the bounds of the left and right borders. If the ball has not been launched yet, the ball will follow the
      //  paddle movement.
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
         // Check if the left button for the paddle is currently being pressed down.
         // If true: draw the paddle further left by the paddle speed. The ball will follow the paddle if the ball has not been launched yet.
         if (mMovePaddleLeft == true)
         {
            // Increase the paddles horizontal speed.
            Vector.SetComponentX(Vector.ComponentX - BreakoutConstants.PADDLE_SPEED_INCREASE);

            // Limit the horizontal speed to its maximum.
            if(Vector.ComponentX < -BreakoutConstants.PADDLE_MAX_SPEED)      
            {
               Vector.SetComponentX(-BreakoutConstants.PADDLE_MAX_SPEED);
            }   

            // Move the paddle left.
            mHitBox.X += (int)Math.Round(Vector.ComponentX);
         
            // The ball follows the paddle's left movement if the ball has not been launched yet.
            if (mBreakoutGame.Ball.BallLaunched == false)
            {
               mBreakoutGame.Ball.SetBallCoordinateX(mBreakoutGame.Ball.HitBox.X + (int)Math.Round(Vector.ComponentX));
            }
         
            // Prevent the paddle and unlaunched ball from moving further left if the paddle reaches the left border by setting their positions
            // X-Coordinate positions to be furthest left before exiting the screen.
            if (mHitBox.X < BreakoutConstants.SCREEN_X_COORDINATE_LEFT)
            {
               mHitBox.X = BreakoutConstants.SCREEN_X_COORDINATE_LEFT;
         
               if (mBreakoutGame.Ball.BallLaunched == false)
               {
                  // The ball i placed center horizontally from the paddle.
                  mBreakoutGame.Ball.SetBallCoordinateX(mHitBox.X + (mHitBox.Width / BreakoutConstants.HALF) -
                                                        (mBreakoutGame.Ball.HitBox.Width / BreakoutConstants.HALF));
               }
            }
         }
         // Check if the right button for the paddle is currently being pressed down.
         // If true: draw the paddle further right by the paddle speed. The ball will follow the paddle if the ball has not been launched yet.
         else if (mMovePaddleRight == true)
         {
            // Increase the paddles horizontal speed.
            Vector.SetComponentX(Vector.ComponentX + BreakoutConstants.PADDLE_SPEED_INCREASE);

            // Limit the horizontal speed to its maximum.
            if (Vector.ComponentX > BreakoutConstants.PADDLE_MAX_SPEED)
            {
               Vector.SetComponentX(BreakoutConstants.PADDLE_MAX_SPEED);
            }

            // Move the paddle right.
            mHitBox.X += (int)Math.Round(Vector.ComponentX);

            // The ball follows the paddle's right movement if the ball has not been launched yet.
            if (mBreakoutGame.Ball.BallLaunched == false)
            {
               mBreakoutGame.Ball.SetBallCoordinateX(mBreakoutGame.Ball.HitBox.X + (int)Math.Round(Vector.ComponentX));
            }
         
            // Prevent the paddle and unlaunched ball from moving further right if the paddle reaches the right border by setting their positions
            // X-Coordinate positions to be furthest right before exiting the screen.
            if (mHitBox.X > (BreakoutConstants.SCREEN_PLAY_AREA_WIDTH - mHitBox.Width))
            {
               mHitBox.X = BreakoutConstants.SCREEN_PLAY_AREA_WIDTH - mHitBox.Width;
         
               if (mBreakoutGame.Ball.BallLaunched == false)
               {
                  // The ball i placed center horizontally from the paddle.
                  mBreakoutGame.Ball.SetBallCoordinateX(mHitBox.X + (mHitBox.Width / BreakoutConstants.HALF) -
                                                        (mBreakoutGame.Ball.HitBox.Width / BreakoutConstants.HALF));
               }
            }
         }
         else
         {
            Vector.SetComponentX(0.0F);
         }
      }
   }
}
