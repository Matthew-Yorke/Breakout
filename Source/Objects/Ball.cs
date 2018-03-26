//***************************************************************************************************************************************************
//
// File Name: Ball.cs
//
// Description:
//  TODO: Add description.
//
// Change History:
//  Author               Date           Description
//  Matthew D. Yorke     MM/DD/2018     TODO: Add description.
//
//***************************************************************************************************************************************************

using System.Drawing;

namespace Breakout
{
   public class Ball
   {
      // The ball image depicting the location and size of the image.
      private Rectangle mBallRectangle;

      // The X velocity of the ball.
      float mBallVelocityX;

      // The Y velocity of the ball.
      float mBallVelocityY;

      // Determines if the ball has been launched yet.
      bool mBallLaunched;

      // Determine how much damage the ball does to a brick.
      int mDamage;

      //*********************************************************************************************************************************************
      //
      // Method Name: Ball
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
      public Ball()
      {
         // Start the ball center of where the paddle starts, but directly above the paddle.
         mBallRectangle = new Rectangle((BreakoutConstants.SCREEN_PLAY_AREA_WIDTH / BreakoutConstants.HALF) - (BreakoutConstants.BALL_WIDTH_AND_HEIGHT / BreakoutConstants.HALF),
                                        BreakoutConstants.SCREEN_PLAY_AREA_HEIGHT - BreakoutConstants.PADDLE_BOUNDARY_PADDING - BreakoutConstants.BALL_WIDTH_AND_HEIGHT,
                                        BreakoutConstants.BALL_WIDTH_AND_HEIGHT,
                                        BreakoutConstants.BALL_WIDTH_AND_HEIGHT);

         // A new ball has no velocity as it is not launched yet.
         mBallVelocityX = BreakoutConstants.BALL_INITIAL_SPEED;
         mBallVelocityY = BreakoutConstants.BALL_INITIAL_SPEED;

         // A new ball has not been launched yet.
         mBallLaunched = false;

         // Set damage to the initial ball damage;
         mDamage = BreakoutConstants.BALL_INITIAL_DAMAGE;
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
      public void NewMatch()
      {
         // Reset the paddle to be in the centered horizontally.
         mBallRectangle.X = (BreakoutConstants.SCREEN_PLAY_AREA_WIDTH / BreakoutConstants.HALF) -
                            (BreakoutConstants.BALL_WIDTH_AND_HEIGHT / BreakoutConstants.HALF);
         mBallRectangle.Y = BreakoutConstants.SCREEN_PLAY_AREA_HEIGHT - BreakoutConstants.PADDLE_BOUNDARY_PADDING -
                            BreakoutConstants.BALL_WIDTH_AND_HEIGHT;

         // On the start of a new match the ball has no velocity since it has not been launched.
         mBallVelocityX = BreakoutConstants.BALL_INITIAL_SPEED;
         mBallVelocityY = BreakoutConstants.BALL_INITIAL_SPEED;

         // On the start of a new match the ball has not been launched yet.
         mBallLaunched = false;
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: SetBallCoordinateX
      //
      // Description:
      //  TODO: Add description.
      //
      // Arguments:
      //  theBallCoordinateX - TODO: Add description.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public void SetBallCoordinateX(int theBallCoordinateX)
      {
         mBallRectangle.X = theBallCoordinateX;
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: SetBallCoordinateY
      //
      // Description:
      //  TODO: Add description.
      //
      // Arguments:
      //  theBallCoordinateY - TODO: Add description.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public void SetBallCoordinateY(int theBallCoordinateY)
      {
         mBallRectangle.Y = theBallCoordinateY;
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: SetBallVelocityX
      //
      // Description:
      //  TODO: Add description.
      //
      // Arguments:
      //  theBallVelocityX- TODO: Add description.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public void SetBallVelocityX(float theBallVelocityX)
      {
         mBallVelocityX = theBallVelocityX;
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: SetBallVelocityY
      //
      // Description:
      //  TODO: Add description.
      //
      // Arguments:
      //  theBallVelocityY - TODO: Add description.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public void SetBallVelocityY(float theBallVelocityY)
      {
         mBallVelocityY = theBallVelocityY;
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: GetBallRectangle
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
      public Rectangle GetBallRectangle()
      {
         return mBallRectangle;
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: SetBallLaunched
      //
      // Description:
      //  TODO: Add description.
      //
      // Arguments:
      //  theBallLaunched - TODO: Add description.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public void SetBallLaunched(bool theBallLaunched)
      {
         mBallLaunched = theBallLaunched;
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: GetBallLaunched
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
      public bool GetBallLaunched()
      {
         return mBallLaunched;
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
      public void UpdateBall()
      {
         mBallRectangle.X += (int)mBallVelocityX;
         mBallRectangle.Y += (int)mBallVelocityY;
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: ReverseBallVelocityX
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
      public void ReverseBallVelocityX()
      {
         mBallVelocityX = -mBallVelocityX;
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: ReverseBallVelocityY
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
      public void ReverseBallVelocityY()
      {
         mBallVelocityY = -mBallVelocityY;
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: SetDamage
      //
      // Description:
      //  TODO: Add description.
      //
      // Arguments:
      //  theDamage - TODO: Add description.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public void SetDamage(int theDamage)
      {
         mDamage = theDamage;
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: GetDamage
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
      public int GetDamage()
      {
         return mDamage;
      }
   }
}
