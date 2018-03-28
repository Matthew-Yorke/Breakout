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
      public MiniBall(Image theImage, int theCoordinateX, int theCoordinateY) :
      base (theImage, theCoordinateX, theCoordinateY)
      {
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
      //  theBreakoutGame - TODO: Add description.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      protected override void CheckBallCollisionOnBottomBorder(BreakoutGame theBreakoutGame)
      {
         // Check if the ball hits the bottom border and remove the mini ball from the list of active mini balls.
         if (mHitBox.Y > BreakoutConstants.SCREEN_PLAY_AREA_HEIGHT)
         {
            theBreakoutGame.MiniBallRemoveList.Add(this);
         }
      }
   }
}
