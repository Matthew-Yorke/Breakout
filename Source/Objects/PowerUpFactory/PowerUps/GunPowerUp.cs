//***************************************************************************************************************************************************
//
// File Name: GunPowerUp.cs
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
   class GunPowerUp : PowerUp
   {
      //*********************************************************************************************************************************************
      //
      // Method Name: GunPowerUp
      //
      // Description:
      //  Constructor that creates the gun power up at the specified starting location.
      //
      // Arguments:
      //  theCoordianteX - The initial X-Coordinate the object is at.
      //  theCoordinateY - The initial Y-Coordinate the object is at.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public GunPowerUp(float theCoordinateX, float theCoordinateY) :
      base(Image.FromFile("../../../Images/GunPowerUp.png"), theCoordinateX, theCoordinateY)
      {
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: ExecutePowerUp
      //
      // Description:
      //  Adds a additional ammunition for the paddle attachment, but does not exceed the maximum amount of ammunition.
      //
      // Arguments:
      //  theBreakoutGame - Reference to the breakout game.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public override void ExecutePowerUp(BreakoutGame theBreakoutGame)
      {
         if (theBreakoutGame.GunAmmunition < 35)
         {
            theBreakoutGame.GunAmmunition += 1;
         }
      }
   }
}
