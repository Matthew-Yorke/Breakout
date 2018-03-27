//***************************************************************************************************************************************************
//
// File Name: PowerUp.cs
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
using System.Windows.Forms;

namespace Breakout
{
   public abstract class PowerUp
   {
      Image mPowerUpImage;
      Point mPowerUpLocation;
      Rectangle mHitBox;

      //*********************************************************************************************************************************************
      //
      // Method Name: PowerUp
      //
      // Description:
      //  TODO: Add description.
      //
      // Arguments:
      //  theImage - TODO: Add description.
      //  theCoordinateX - TODO: Add description.
      //  theCoordinateY - TODO: Add description.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public PowerUp(Image theImage, int theCoordinateX, int theCoordinateY)
      {
         mPowerUpImage = theImage;
         mPowerUpLocation = new Point(theCoordinateX, theCoordinateY);
         mHitBox = new Rectangle(mPowerUpLocation, mPowerUpImage.Size);
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: ExecutePowerUp
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
      public abstract void ExecutePowerUp(FiniteStateMachine theFiniteStateMachine);

      //*********************************************************************************************************************************************
      //
      // Method Name: Fall
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
      public void Fall()
      {
         mPowerUpLocation.Y += 1;
         mHitBox.Y = mPowerUpLocation.Y;
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: GetLocation
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
      public Point GetLocation()
      {
         return mPowerUpLocation;
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: GetHitBox
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
      public Rectangle GetHitBox()
      {
         return mHitBox;
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: Draw
      //
      // Description:
      //  TODO: Add description.
      //
      // Arguments:
      //  theEventArguments - TODO: Add description.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public void Draw(PaintEventArgs theEventArguments)
      {
         theEventArguments.Graphics.DrawImage(mPowerUpImage, mPowerUpLocation);
      }
   }
}
