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
   public abstract class PowerUp : MasterObject
   {
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
      public PowerUp(Image theImage, int theCoordinateX, int theCoordinateY) :
      base (theImage, theCoordinateX, theCoordinateY)
      {
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
      public abstract void ExecutePowerUp(BreakoutGame theBreakoutGame);

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
      public override void Update()
      {
         mHitBox.Y += 1;
      }
   }
}
