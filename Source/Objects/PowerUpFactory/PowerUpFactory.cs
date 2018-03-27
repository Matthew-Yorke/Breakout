//***************************************************************************************************************************************************
//
// File Name: PowerUpFactory.cs
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
   public abstract class PowerUpFactory
   {
      public abstract PowerUp GetPowerUp(int thePowerUp, Rectangle theRectangle);
   }
}
