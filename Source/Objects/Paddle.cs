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

using System.Drawing;

namespace Breakout
{
   public class Paddle
   {
      // The image of the paddle to be drawn on the screen.
      private Image mPaddleImage;

      // The hit box of the paddle to allow collision detection.
      private Rectangle mHitBox;
      public Rectangle HitBox
      {
         get {return mHitBox; }
         set { mHitBox = value;}
      }

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

      //*********************************************************************************************************************************************
      //
      // Method Name: Paddle
      //
      // Description:
      //  Constructor for the paddle object. The paddle is created at the center of the screen with a slight padding away from the bottom border.
      //  The paddle starts with no horizontal movement.
      //
      // Arguments:
      //  N/A
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public Paddle()
      {
         mPaddleImage = Image.FromFile(BreakoutConstants.PADDLE_IMAGE_FILE);

         // Start the paddle at the center of the screen and with a padding from the bottom of the screen.
         mHitBox = new Rectangle((BreakoutConstants.SCREEN_PLAY_AREA_WIDTH / BreakoutConstants.HALF) -
                                    (mPaddleImage.Width / BreakoutConstants.HALF),
                                 BreakoutConstants.SCREEN_PLAY_AREA_HEIGHT - BreakoutConstants.PADDLE_BOUNDARY_PADDING,
                                 mPaddleImage.Width,
                                 mPaddleImage.Height);

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

         // The paddle starts with no movement.
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
      //  theBallObject - The ball object in the game.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public void Update(Ball theBallObject)
      {
         // Check if the left button for the paddle is currently being pressed down.
         // If true: draw the paddle further left by the paddle speed. The ball will follow the paddle if the ball has not been launched yet.
         if (mMovePaddleLeft == true)
         {
            // Move the paddle left.
            mHitBox.X = mHitBox.X - BreakoutConstants.PADDLE_SPEED;

            // The ball follows the paddle's left movement if the ball has not been launched yet.
            if (theBallObject.BallLaunched == false)
            {
               theBallObject.SetBallCoordinateX(theBallObject.BallRectangle.X - BreakoutConstants.PADDLE_SPEED);
            }

            // Prevent the paddle and unlaunched ball from moving further left if the paddle reaches the left border by setting their positions
            // X-Coordinate positions to be furthest left before exiting the screen.
            if (mHitBox.X < BreakoutConstants.SCREEN_X_COORDINATE_LEFT)
            {
               mHitBox.X = BreakoutConstants.SCREEN_X_COORDINATE_LEFT;

               if (theBallObject.BallLaunched == false)
               {
                  // The ball i placed center horizontally from the paddle.
                  theBallObject.SetBallCoordinateX(mHitBox.X + (mHitBox.Width / BreakoutConstants.HALF) -
                                                      (theBallObject.BallRectangle.Width / BreakoutConstants.HALF));
               }
            }
         }
         // Check if the right button for the paddle is currently being pressed down.
         // If true: draw the paddle further right by the paddle speed. The ball will follow the paddle if the ball has not been launched yet.
         else if (mMovePaddleRight == true)
         {
            // Move the paddle right.
            mHitBox.X = mHitBox.X + BreakoutConstants.PADDLE_SPEED;

            // The ball follows the paddle's right movement if the ball has not been launched yet.
            if (theBallObject.BallLaunched == false)
            {
               theBallObject.SetBallCoordinateX(theBallObject.BallRectangle.X + BreakoutConstants.PADDLE_SPEED);
            }

            // Prevent the paddle and unlaunched ball from moving further right if the paddle reaches the right border by setting their positions
            // X-Coordinate positions to be furthest right before exiting the screen.
            if (mHitBox.X > (BreakoutConstants.SCREEN_PLAY_AREA_WIDTH - mHitBox.Width))
            {
               mHitBox.X = BreakoutConstants.SCREEN_PLAY_AREA_WIDTH - mHitBox.Width;

               if (theBallObject.BallLaunched == false)
               {
                  // The ball i placed center horizontally from the paddle.
                  theBallObject.SetBallCoordinateX(mHitBox.X + (mHitBox.Width / BreakoutConstants.HALF) -
                                                      (theBallObject.BallRectangle.Width / BreakoutConstants.HALF));
               }
            }
         }
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: Update
      //
      // Description:
      //  Draw the image of the paddle to the screen.
      //
      // Arguments:
      //  theGraphics - The drawing surface.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public void Draw(Graphics theGraphics)
      {
         theGraphics.DrawImage(mPaddleImage, mHitBox);
      }
   }
}
