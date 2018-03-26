//***************************************************************************************************************************************************
//
// File Name: Paddle.cs
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
   public class Paddle
   {
      // The paddle image depicting the location and size of the image.
      private Rectangle mPaddleRectangle;

      // Determines during an update if the player is pressing the key to move the paddle left.
      bool mMovePaddleLeft;

      // Determines during an update if the player is pressing the key to move the paddle right.
      bool mMovePaddleRight;

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
      public Paddle()
      {
         // Start the paddle at the center of the screen and with a padding from the bottom of the screen.
         mPaddleRectangle = new Rectangle((BreakoutConstants.SCREEN_PLAY_AREA_WIDTH / BreakoutConstants.HALF) - (BreakoutConstants.PADDLE_WIDTH / BreakoutConstants.HALF),
                                          BreakoutConstants.SCREEN_PLAY_AREA_HEIGHT - BreakoutConstants.PADDLE_BOUNDARY_PADDING,
                                          BreakoutConstants.PADDLE_WIDTH,
                                          BreakoutConstants.PADDLE_HEIGHT);

         // The paddle starts with no movement.
         mMovePaddleLeft = false;
         mMovePaddleRight = false;
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
         mPaddleRectangle.X = (BreakoutConstants.SCREEN_PLAY_AREA_WIDTH / BreakoutConstants.HALF) -
                              (BreakoutConstants.PADDLE_WIDTH / BreakoutConstants.HALF);

         // The paddle starts with no movement.
         mMovePaddleLeft = false;
         mMovePaddleRight = false;
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: GetPaddleRectangle
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
      public Rectangle GetPaddleRectangle()
      {
         return mPaddleRectangle;
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: SetPaddleCoordinateX
      //
      // Description:
      //  TODO: Add description.
      //
      // Arguments:
      //  thePaddleCoordinateX - TODO: Add description.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public void SetPaddleCoordinateX(int thePaddleCoordinateX)
      {
         mPaddleRectangle.X = thePaddleCoordinateX;
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: SetPaddleCoordinateY
      //
      // Description:
      //  TODO: Add description.
      //
      // Arguments:
      //  thePaddleCoordinateY - TODO: Add description.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public void SetPaddleCoordinateY(int thePaddleCoordinateY)
      {
         mPaddleRectangle.Y = thePaddleCoordinateY;
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: SetLeftMovement
      //
      // Description:
      //  TODO: Add description.
      //
      // Arguments:
      //  theMovePaddleLeft - TODO: Add description.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public void SetLeftMovement(bool theMovePaddleLeft)
      {
         mMovePaddleLeft = theMovePaddleLeft;
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: GetLeftMovement
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
      public bool GetLeftMovement()
      {
         return mMovePaddleLeft;
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: SetRightMovement
      //
      // Description:
      //  TODO: Add description.
      //
      // Arguments:
      //  theMovePaddleRight - TODO: Add description.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public void SetRightMovement(bool theMovePaddleRight)
      {
         mMovePaddleRight = theMovePaddleRight;
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: GetRightMovement
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
      public bool GetRightMovement()
      {
         return mMovePaddleRight;
      }
   }
}
