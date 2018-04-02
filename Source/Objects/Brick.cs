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

      private PowerUp mPowerUp;

      //*********************************************************************************************************************************************
      //
      // Method Name: Brick
      //
      // Description:
      //  Constructor that creates the brick object. The brick is placed at the specified location with the image being saved. The brick level is
      //  set here.
      //
      // Arguments:
      //  theImage - The image to retain for the object.
      //  theCoordianteX - The initial X-Coordinate the object is at.
      //  theCoordinateY - The initial Y-Coordinate the object is at.
      //  theBrickLevel - The level the brick is at upon creation.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public Brick(Image theImage, float theCoordinateX, float theCoordinateY, int theBrickLevel, BreakoutGame theBreakoutGame) :
      base(theImage,
           theCoordinateX,
           theCoordinateY,
           new Vector2D(0.0F, 0.0F))
      {
         mBrickLevel = theBrickLevel;

         // Start the power up as null in case a power up is not hidden in this brick.
         mPowerUp = null;
         
         // Determine if this brick has a hidden power up and store the power up if so.
         DetermineHiddenPowerUp(theBreakoutGame);
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: DetermineHiddenPowerUp
      //
      // Description:
      //  This method determines if a power up is to be hidden where the brick is until the bricks destruction. If a power up is to be created the
      //  brick generates a random power up.
      //
      // Arguments:
      //  theBreakoutGame - The game object that tracks various game elements.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public void DetermineHiddenPowerUp(BreakoutGame theBreakoutGame)
      {
         // Use random number generator to potentially create a new power up.
         Random randomNumberGenerator = new Random();

         // Give a specified chance a power up will drop.
         int nextRandomNumber = theBreakoutGame.RandomNumberGenerator.Next(BreakoutConstants.ZERO_PERCENT,
                                                                           BreakoutConstants.ONE_HUNDRED_PERCENT +
                                                                              BreakoutConstants.RANDOM_NUMBER_INCLUSION);
         if (nextRandomNumber <= BreakoutConstants.POWER_UP_DROP_PERCENT)
         {
            // Create a random power up.
            mPowerUp = theBreakoutGame.GetPowerUpFactory().GetPowerUp(HitBox,
                                                                      randomNumberGenerator.Next(BreakoutConstants.ZERO_PERCENT,
                                                                                                 BreakoutConstants.ONE_HUNDRED_PERCENT +
                                                                                                 BreakoutConstants.RANDOM_NUMBER_INCLUSION));
         }
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: Destroyed
      //
      // Description:
      //  When called on destruction of the brick, this method adds the hidden power up to the game power up list if the hidden power up exists.
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
         // Check to see if a power up was hidden in this brick, and add it to the power up list if so.
         if (mPowerUp != null)
         {
            theBreakoutGame.GetPowerUpList().Add(mPowerUp);
         }

         for (int count = 0; count < 30; count++)
         {
            // Determine a random location within the bricks.
            int theRandomXPosition = theBreakoutGame.RandomNumberGenerator.Next((int)HitBox.X,
                                                                                (int)(HitBox.X + HitBox.Width));
            int theRandomYPosition = theBreakoutGame.RandomNumberGenerator.Next((int)HitBox.Y,
                                                                                (int)(HitBox.Y + HitBox.Height));
            
            // Add a new particle for the brick explosion at the new random location that travels at a random velocity in any direction.
            theBreakoutGame.Particles.Add(new Particle(theRandomXPosition,
                                                       theRandomYPosition,
                                                       BreakoutConstants.BRICK_EXPLOSION_WIDTH_AND_LENGTH,
                                                       BreakoutConstants.BRICK_EXPLOSION_MINIMUM_ANGLE,
                                                       BreakoutConstants.BRICK_EXPLOSION_MAXIMUM_ANGLE,
                                                       BreakoutConstants.BRICK_EXPLOSION_TIME_MILLISECONDS,
                                                       Color.FromArgb(255, 34, 177, 76),
                                                       theBreakoutGame));
         }
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: UpdateBrickImage
      //
      // Description:
      //  Update the brick image with the based in image.
      //
      // Arguments:
      //  theImage - The image the brick image will update to.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public void UpdateBrickImage(string theImage)
      {
         ObjectImage = Image.FromFile(theImage);
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
