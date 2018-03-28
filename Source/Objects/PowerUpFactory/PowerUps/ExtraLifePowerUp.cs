//***************************************************************************************************************************************************
//
// File Name: ExtraLifePowerUp.cs
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
   public class ExtraLifePowerUp : PowerUp
   {
      //*********************************************************************************************************************************************
      //
      // Method Name: ExtraLifePowerUp
      //
      // Description:
      //  Constructor that creates the extra life power up at the specified starting location.
      //
      // Arguments:
      //  theCoordianteX - The initial X-Coordinate the object is at.
      //  theCoordinateY - The initial Y-Coordinate the object is at.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public ExtraLifePowerUp(int theCoordinateX, int theCoordinateY) :
      base(Image.FromFile("../../Images/ExtraLifePowerUp.png"), theCoordinateX, theCoordinateY)
      {
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: ExecutePowerUp
      //
      // Description:
      //  Adds an additional life to the players pool of remaining lives.
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
         theBreakoutGame.NumberOfLives +=  1;
      }
   }
}
