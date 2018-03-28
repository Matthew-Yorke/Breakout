//***************************************************************************************************************************************************
//
// File Name: Brick.cs
//
// Description:
//  This class handles the functionality of the bricks for the game. The class handles the creation of the bricks and track the level the brick is
//  currently at. When a brick is hit it will lose a level and eventually be destroyed. Upon destruction this class determines if a power up will be
//  created and if so a random power up will be added to the game.
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
   public class Brick : MasterObject
   {
      // The level of the brick.
      private int mBrickLevel;
      public int BrickLevel
      {
         get {return mBrickLevel;}
         set {mBrickLevel = value;}
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: Brick
      //
      // Description:
      //  Constructor that creates the brick object. The brick is placed at the specified location with the image being saved. The brick level is
      //  set here as well.
      //
      // Arguments:
      //  theBrickRectangle - TODO: Add description.
      //  theBrickLevel - TODO: Add description.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public Brick(Image theImage, int theCoordinateX, int theCoordinateY, int theBrickLevel) :
      base(theImage, theCoordinateX, theCoordinateY)
      {
         mBrickLevel = theBrickLevel;
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: Destroyed
      //
      // Description:
      //  When called on destruction of the brick, this method determines if a power up is to be created where the brick was located. If a power up
      //  is to be created the brick generates a random power up.
      //
      // Arguments:
      //  theBreakoutGame - The game object that tracks various game elements.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public void Destroyed(BreakoutGame theBreakoutGame)
      {
         // Use random number generator to potentially create a new power up.
         Random randomNumberGenerator = new Random();

         // Give a specified chance a power up will drop.
         int nextRandomNumber = randomNumberGenerator.Next(BreakoutConstants.ZERO_PERCENT,
                                                           BreakoutConstants.ONE_HUNDRED_PERCENT + BreakoutConstants.RANDOM_NUMBER_INCLUSION);
         if (nextRandomNumber <= BreakoutConstants.POWER_UP_DROP_PERCENT)
         {
            // Create a random power up.
            PowerUp newPowerUp = theBreakoutGame.GetPowerUpFactory().GetPowerUp(randomNumberGenerator.Next(BreakoutConstants.ZERO_PERCENT,
                                                                                                           BreakoutConstants.ONE_HUNDRED_PERCENT + BreakoutConstants.RANDOM_NUMBER_INCLUSION),
                                                                                                           HitBox);

            // Check to see if a new power up was made in the factory, and add it to the power up list if so.
            if (newPowerUp != null)
            {
               theBreakoutGame.GetPowerUpList().Add(newPowerUp);
            }
         }
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: Update
      //
      // Description:
      //  A brick does nothing on an update as they are a static object.
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
      }
   }
}
