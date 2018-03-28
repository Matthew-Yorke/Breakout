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

         // A new ball has not been launched yet.
         mBallLaunched = false;
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
      public override void NewMatch()
      {
         // Still do the base functionality of the ball.
         base.NewMatch();

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
      //  theBreakoutGame - TODO: Add description.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      protected override void CheckBallCollisionOnBottomBorder(BreakoutGame theBreakoutGame)
      {
         if (mBallRectangle.Y > BreakoutConstants.SCREEN_PLAY_AREA_HEIGHT)
         {
            theBreakoutGame.NumberOfLives = theBreakoutGame.NumberOfLives - BreakoutConstants.LIFE_LOST;

            if (theBreakoutGame.NumberOfLives < 0)
            {
               theBreakoutGame.NumberOfLives = BreakoutConstants.INITIAL_LIVES_REMAINING;
               theBreakoutGame.PopState();
            }
            else
            {
               NewMatch();
               theBreakoutGame.Paddle.NewMatch();
            }
         }
      }
   }
}
