//***************************************************************************************************************************************************
//
// File Name: PowerUp.cs
//
// Description:
//  The abstract power up class implements basic power up functionality of a power up. The execute method must be implemented by all concrete power
//  up classes to handle what the power up does upon the player retrieving the power up.
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
      //  Constructor that creates the hit box and holds the image at the specified starting location on the screen.
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
      public PowerUp(Image theImage, int theCoordinateX, int theCoordinateY) :
      base (theImage, theCoordinateX, theCoordinateY)
      {
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: ExecutePowerUp
      //
      // Description:
      //  Abstract method that all concrete classes must implement to handle what the power up does upon the player collecting the power up.
      //
      // Arguments:
      //  theBreakoutGame - Reference to the breakout game.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public abstract void ExecutePowerUp(BreakoutGame theBreakoutGame);

      //*********************************************************************************************************************************************
      //
      // Method Name: Update
      //
      // Description:
      //  Override that parent update method to have the power up continue to fall towards the bottom border.
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
