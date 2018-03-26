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
   public class Brick
   {
      // The rectangle elements of the brick including the coordinates, width, and height.
      private Rectangle mBrickRecatangle;

      // The level of the brick.
      private int mBrickLevel;

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
      public Brick(Rectangle theBrickRectangle, int theBrickLevel)
      {
         mBrickRecatangle = theBrickRectangle;
         mBrickLevel = theBrickLevel;
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: GetBrickRectangle
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
      public Rectangle GetBrickRectangle()
      {
         return mBrickRecatangle;
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: SetBrickLevel
      //
      // Description:
      //  TODO: Add description.
      //
      // Arguments:
      //  theBrickLevel - TODO: Add description.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public void SetBrickLevel(int theBrickLevel)
      {
         mBrickLevel = theBrickLevel;
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: GetBrickLevel
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
      public int GetBrickLevel()
      {
         return mBrickLevel;
      }


   }
}
