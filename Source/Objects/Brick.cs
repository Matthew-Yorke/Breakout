//***************************************************************************************************************************************************
//
// File Name: Ball.cs
//
// Description:
//  TODO: Add description.
//
// Change History:
//  Author               Date           Description
//  Matthew D. Yorke     MM/DD/2018     TODO: Add description.
//
//***************************************************************************************************************************************************

using System;
using System.Drawing;

namespace Breakout
{
   public class Brick
   {
      // The rectangle elements of the brick including the coordinates, width, and height.
      private Rectangle mBrickRecatangle;

      // The level of the brick.
      private int mBrickLevel;

      //*********************************************************************************************************************************************
      //
      // Method Name: Ball
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
      public Brick(Rectangle theBrickRectangle, int theBrickLevel)
      {
         mBrickRecatangle = theBrickRectangle;
         mBrickLevel = theBrickLevel;
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: Destroyed
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
      public void Destroyed(FiniteStateMachine theFiniteStateMachine)
      {
         // Use random number generator to potentially create a new power up.
         Random randomNumberGenerator = new Random();

         // Give a specified chance a power up will drop.
         int nextRandomNumber = randomNumberGenerator.Next(BreakoutConstants.ZERO_PERCENT,
                                                           BreakoutConstants.ONE_HUNDRED_PERCENT + BreakoutConstants.RANDOM_NUMBER_INCLUSION);
         if (nextRandomNumber <= BreakoutConstants.POWER_UP_DROP_PERCENT)
         {
            // Create a random power up.
            PowerUp newPowerUp = theFiniteStateMachine.GetPowerUpFactory().GetPowerUp(randomNumberGenerator.Next(BreakoutConstants.ZERO_PERCENT,
                                                                                                                 BreakoutConstants.ONE_HUNDRED_PERCENT + BreakoutConstants.RANDOM_NUMBER_INCLUSION),
                                                                                      mBrickRecatangle);

            // Check to see if a new power up was made in the factory, and add it to the power up list if so.
            if (newPowerUp != null)
            {
               theFiniteStateMachine.GetPowerUpList().Add(newPowerUp);
            }
         }
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: GetBrickRectangle
      //
      // Description:
      //  TODO: Add description.
      //
      // Arguments:
      //  N/A
      //
      // Return:
      //  TODO: Add description.
      //
      //*********************************************************************************************************************************************
      public Rectangle GetBrickRectangle()
      {
         return mBrickRecatangle;
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: SetBrickLevel
      //
      // Description:
      //  TODO: Add description.
      //
      // Arguments:
      //  theBrickLevel - TODO: Add description.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public void SetBrickLevel(int theBrickLevel)
      {
         mBrickLevel = theBrickLevel;
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: GetBrickLevel
      //
      // Description:
      //  TODO: Add description.
      //
      // Arguments:
      //  N/A
      //
      // Return:
      //  TODO: Add description.
      //
      //*********************************************************************************************************************************************
      public int GetBrickLevel()
      {
         return mBrickLevel;
      }


   }
}
