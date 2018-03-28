//***************************************************************************************************************************************************
//
// File Name: MiniBall.cs
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
using System.Collections.Generic;

namespace Breakout
{
   public class MiniBall : BallObject
   {
      //*********************************************************************************************************************************************
      //
      // Method Name: MiniBall
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
      public MiniBall(FiniteStateMachine theFiniteStateMachine)
      {
         // Start the ball center of where the paddle is, but directly above the paddle.
         mBallRectangle = new Rectangle(theFiniteStateMachine.Paddle.PaddleRectangle.X + (BreakoutConstants.PADDLE_WIDTH / BreakoutConstants.HALF) - (BreakoutConstants.MINI_BALL_WIDTH_AND_HEIGHT / BreakoutConstants.HALF),
                                        BreakoutConstants.SCREEN_PLAY_AREA_HEIGHT - BreakoutConstants.PADDLE_BOUNDARY_PADDING - BreakoutConstants.BALL_WIDTH_AND_HEIGHT,
                                        BreakoutConstants.MINI_BALL_WIDTH_AND_HEIGHT,
                                        BreakoutConstants.MINI_BALL_WIDTH_AND_HEIGHT);

         // A new ball has no velocity as it is not launched yet.
         BallVelocityX = 1;
         BallVelocityY = -1;
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: CheckBallCollisionOnBottomBorder
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
      protected override void CheckBallCollisionOnBottomBorder(FiniteStateMachine theFiniteStateMachine)
      {
         // Check if the ball hits the bottom border and remove the mini ball from the list of active mini balls.
         if (mBallRectangle.Y > BreakoutConstants.SCREEN_PLAY_AREA_HEIGHT)
         {
            theFiniteStateMachine.MiniBallRemoveList.Add(this);
         }
      }
   }
}
