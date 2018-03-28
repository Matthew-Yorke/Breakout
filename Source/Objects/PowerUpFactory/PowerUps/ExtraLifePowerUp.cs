﻿//***************************************************************************************************************************************************
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
      //  TODO: Add description.
      //
      // Arguments:
      //  theCoordinateX - TODO: Add description.
      //  theCoordinateY - TODO: Add description.
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
      //  TODO: Add description.
      //
      // Arguments:
      //  theBreakoutGame - TODO: Add description.
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
