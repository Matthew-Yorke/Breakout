//***************************************************************************************************************************************************
//
// File Name: PowerUpFactoryConcrete.cs
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
   public class PowerUpFactoryConcrete : PowerUpFactory
   {
      //*********************************************************************************************************************************************
      //
      // Method Name: GetPowerUp
      //
      // Description:
      //  TODO: Add description.
      //
      // Arguments:
      //  thePowerUp - TODO: Add description.
      //  theRectangle - TODO: Add description.
      //
      // Return:
      //  TODO: Add description.
      //
      //*********************************************************************************************************************************************
      public override PowerUp GetPowerUp(int thePowerUp, Rectangle theRectangle)
      {
         PowerUp newPowerUp = null;

         int chance = 0;

         if (thePowerUp <= (chance = BreakoutConstants.EXTRA_LIFE_POWER_UP_PERCENT_CHANCE))
         {
            newPowerUp = new ExtraLifePowerUp(theRectangle.X + (theRectangle.Width / BreakoutConstants.HALF),
                                              theRectangle.Y + (theRectangle.Width / BreakoutConstants.HALF));
         }
         else if (thePowerUp > chance &&
                  thePowerUp <= (chance += BreakoutConstants.MINI_BALL_POWER_UP_PERCENT_CHANCE))
         {
            newPowerUp = new MiniballPowerUp(theRectangle.X + (theRectangle.Width / BreakoutConstants.HALF),
                                             theRectangle.Y + (theRectangle.Width / BreakoutConstants.HALF));
         }

         return newPowerUp;
      }
   }
}
