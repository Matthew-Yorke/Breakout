//***************************************************************************************************************************************************
//
// File Name: Ball.cs
//
// Description:
//  his class creates the ball and handles reseting the ball and paddle when the ball exits the bottom boundary. This class also handles ending the
//  game if the final life is used when the ball exits the bottom border.
//
// Change History:
//  Author               Date           Description
//  Matthew D. Yorke     MM/DD/2018     TODO: Add description.
//
//***************************************************************************************************************************************************

using System.Drawing;

namespace Breakout
{
   public class Ball : BallObject
   {
      // Determines if the ball has been launched yet.
      private bool mBallLaunched;
      public bool BallLaunched
      {
         get {return mBallLaunched;}
         set {mBallLaunched = value;}
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: Ball
      //
      // Description:
      //  Constructor to create the ball object including retaining the image and setting the ball at the specified starting location. The initial
      //  ball velocity is set here.
      //
      // Arguments:
      //  theImage - The image to retain for the object.
      //  theCoordianteX - The initial X-Coordinate the object is at.
      //  theCoordinateY - The initial Y-Coordinate the object is at.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public Ball(Image theImage, int theCoordinateX, int theCoordinateY) :
      base (theImage, theCoordinateX, theCoordinateY)
      {
         // A new ball has no velocity as it is not launched yet.
         BallVelocityX = BreakoutConstants.BALL_INITIAL_SPEED;
         BallVelocityY = BreakoutConstants.BALL_INITIAL_SPEED;

         // A new ball has not been launched yet.
         mBallLaunched = false;
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: NewMatch
      //
      // Description:
      //  Resets the ball position to be center of the paddle (directly above the paddle) and the velocity. The ball must also be relaunched.
      //
      // Arguments:
      //  N/A
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public override void NewMatch()
      {
         // Reset the paddle to be in the centered horizontally.
         mHitBox.X = (BreakoutConstants.SCREEN_PLAY_AREA_WIDTH / BreakoutConstants.HALF) -
                     (mHitBox.Width / BreakoutConstants.HALF);
         mHitBox.Y = BreakoutConstants.SCREEN_PLAY_AREA_HEIGHT - BreakoutConstants.PADDLE_BOUNDARY_PADDING -
                     mHitBox.Height;

         // On the start of a new match the ball has no velocity since it has not been launched.
         BallVelocityX = BreakoutConstants.BALL_INITIAL_SPEED;
         BallVelocityY = BreakoutConstants.BALL_INITIAL_SPEED;

         // On the start of a new match the ball has not been launched yet.
         mBallLaunched = false;
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: CheckBallCollisionOnBottomBorder
      //
      // Description:
      //  Check if the ball hits the bottom border and decrement the number of lives the player has left. If lives goes below the threshold for game
      //  over, the game reverts back to the start screen. Otherwise a new match begins.
      //
      // Arguments:
      //  theBreakoutGame - The game object that tracks various game elements.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      protected override void CheckBallCollisionOnBottomBorder(BreakoutGame theBreakoutGame)
      {
         if (mHitBox.Y > BreakoutConstants.SCREEN_PLAY_AREA_HEIGHT)
         {
            theBreakoutGame.NumberOfLives = theBreakoutGame.NumberOfLives - BreakoutConstants.LIFE_LOST;

            // Check if the number of lives have been used up and end the game if so.
            if (theBreakoutGame.NumberOfLives < 0)
            {
               theBreakoutGame.NumberOfLives = BreakoutConstants.INITIAL_LIVES_REMAINING;
               theBreakoutGame.PopState();
            }
            // The player still have spare lives to play so a new match is started.
            else
            {
               NewMatch();
               theBreakoutGame.Paddle.NewMatch();
            }
         }
      }
   }
}
