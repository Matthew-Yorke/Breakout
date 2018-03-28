//***************************************************************************************************************************************************
//
// File Name: PowerUpFactoryConcrete.cs
//
// Description:
//  Implements the power up factory class by implementing the power up creation method.
//
// Change History:
//  Author               Date           Description
//  Matthew D. Yorke     MM/DD/2018     TODO: Add description.
//
//***************************************************************************************************************************************************

using System.Drawing;

namespace Breakout
{
   public class PowerUpFactoryConcrete : PowerUpFactory
   {
      //*********************************************************************************************************************************************
      //
      // Method Name: GetPowerUp
      //
      // Description:
      //  Create the new power up based on the random number generated passed in.
      //
      // Arguments:
      //  theHitBox - The hit box of the brick that was destroyed.
      //  thePowerUp - The random number to determine which power up to create.
      //
      // Return:
      //  Returns the new power up object or null if some failure has occurred. 
      //
      //*********************************************************************************************************************************************
      public override PowerUp GetPowerUp(Rectangle theHitBox, int thePowerUp)
      {
         PowerUp newPowerUp = null;

         int chance = 0;

         // Check the power up chance for each power up. Create the power up that was in the range of the power up chance.
         if (thePowerUp <= (chance = BreakoutConstants.EXTRA_LIFE_POWER_UP_PERCENT_CHANCE))
         {
            newPowerUp = new ExtraLifePowerUp(theHitBox.X + (theHitBox.Width / BreakoutConstants.HALF),
                                              theHitBox.Y + (theHitBox.Width / BreakoutConstants.HALF));
         }
         else if (thePowerUp > chance &&
                  thePowerUp <= (chance += BreakoutConstants.MINI_BALL_POWER_UP_PERCENT_CHANCE))
         {
            newPowerUp = new MiniballPowerUp(theHitBox.X + (theHitBox.Width / BreakoutConstants.HALF),
                                             theHitBox.Y + (theHitBox.Width / BreakoutConstants.HALF));
         }

         return newPowerUp;
      }
   }
}
