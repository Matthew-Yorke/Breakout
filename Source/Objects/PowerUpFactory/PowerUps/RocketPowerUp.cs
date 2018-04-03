//***************************************************************************************************************************************************
//
// File Name: RocketPowerUp.cs
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
   class RocketPowerUp : PowerUp
   {
      //*********************************************************************************************************************************************
      //
      // Method Name: RocketPowerUp
      //
      // Description:
      //  Constructor that creates the rocket power up at the specified starting location.
      //
      // Arguments:
      //  theCoordianteX - The initial X-Coordinate the object is at.
      //  theCoordinateY - The initial Y-Coordinate the object is at.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public RocketPowerUp(float theCoordinateX, float theCoordinateY) :
      base(Image.FromFile("../../../Images/RocketPowerUp.png"), theCoordinateX, theCoordinateY)
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
         if (theBreakoutGame.RocketAmmunition < 5)
         {
            theBreakoutGame.RocketAmmunition += 1;
         }
      }
   }
}
