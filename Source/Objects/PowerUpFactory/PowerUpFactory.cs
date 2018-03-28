//***************************************************************************************************************************************************
//
// File Name: PowerUpFactory.cs
//
// Description:
//  The abstract power up factory class that details which methods the concrete class must implement.
//
// Change History:
//  Author               Date           Description
//  Matthew D. Yorke     MM/DD/2018     TODO: Add description.
//
//***************************************************************************************************************************************************

using System.Drawing;

namespace Breakout
{
   public abstract class PowerUpFactory
   {
      //*********************************************************************************************************************************************
      //
      // Method Name: GetPowerUp
      //
      // Description:
      //  The abstract method that must be implemented by the concrete class for creating the power up.
      //
      // Arguments:
      //  theHitBox - The hit box of the brick that was destroyed.
      //  thePowerUp - The random number to determine which power up to create.
      //
      // Return:
      //  Returns the new power up object or null if some failure has occurred. 
      //
      //*********************************************************************************************************************************************
      public abstract PowerUp GetPowerUp(Rectangle theHitBox, int thePowerUp);
   }
}
