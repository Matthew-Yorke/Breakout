//***************************************************************************************************************************************************
//
// File Name: MiniBall.cs
//
// Description:
//  This class creates the mini ball and removing the mini ball from the game if it exits the bottom border.
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
      //  Constructor to create the mini ball object including retaining the image and setting the ball at the specified starting location. The
      //  initial mini ball velocity is set here.
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
      //  Check if the ball has collided past the bottom border and remove this mini ball from the game if so.
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
