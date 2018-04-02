//***************************************************************************************************************************************************
//
// File Name: Particle.cs
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
   public class Particle
   {
      private TimeSpan mLiveTime;
      private DateTime? mBirthTime;
      private PointF mLocation;
      private Vector2D mVelocity;
      private Color mColor;
      private int mParticleSize;
      private int mFadeStride;
      private int mCurrentAlpha;

      //*********************************************************************************************************************************************
      //
      // Method Name: Particle
      //
      // Description:
      //  TODO: Add description.
      //
      // Arguments:
      //  theCoordinateX - The X-Coordinate to start the bullet at.
      //  theCoordinateY - The Y-Coordinate to start the bullet at.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public Particle(float theCoordinateX, float theCoordinateY, int theWidthAndLength, int theMinimumAngle, int theMaximumAngle,
                      int theMilliseconds, Color theColor, BreakoutGame theBreakoutGame)
      {
         // Set the particle starting location based on the passed in parameters.
         mLocation = new PointF(theCoordinateX,
                                theCoordinateY);

         // Set the how long the particle will live before being destroyed.
         mLiveTime = new TimeSpan(0,
                                  0,
                                  0,
                                  0,
                                  theMilliseconds);

         // Create a velocity vector within the cone (between min and max angle).
         int angleDegrees = theBreakoutGame.RandomNumberGenerator.Next(theMinimumAngle, theMaximumAngle);
         mVelocity = new Vector2D((float)Math.Cos(angleDegrees),
                                  (float)Math.Sin(angleDegrees));

         // TODO: Add particle size as parameter.
         mParticleSize = theWidthAndLength;

         // Hold the color information
         mColor = theColor;
         mCurrentAlpha = mColor.A;

         // The fade step is set by determining how many times an update will be called before the particle is destroyed and then dividing that
         // number by the starting alpha (transparency) to get the amount of fade to add per update.
         mFadeStride = mColor.A / (theMilliseconds / BreakoutConstants.TIMER_INTERVAL);
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: Update
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
      public bool Update()
      {
         // If this is the first update then set the time this particle started.
         if (mBirthTime == null)
         {
            mBirthTime = DateTime.Now;
         }

         // Change the particle location by its velocity vector.
         mLocation.X += mVelocity.ComponentX;
         mLocation.Y += mVelocity.ComponentY;

         // Return if the time has exceeded the particles life time (true) or not (false).
         return DateTime.Now - mBirthTime > mLiveTime;
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: Draw
      //
      // Description:
      //  TODO: Add description.
      //
      // Arguments:
      //  theGraphics
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public void Draw(Graphics theGraphics)
      {
         // Update the particle fade amount.
         mCurrentAlpha -= mFadeStride;
         if (mCurrentAlpha < 0)
         {
            mCurrentAlpha = 0;
         }

         // Create a new brush using the new particle fade amount the particle color.
         SolidBrush particleColor = new SolidBrush(Color.FromArgb(mCurrentAlpha, mColor.R, mColor.G, mColor.B));

         // Draw the particle at the location (center of the particle) using the faded particle brush.
         theGraphics.FillRectangle(particleColor,
                                   mLocation.X - (mParticleSize / BreakoutConstants.HALF),
                                   mLocation.Y - (mParticleSize / BreakoutConstants.HALF),
                                   mParticleSize,
                                   mParticleSize);

         // Clean up used memory.
         particleColor.Dispose();
      }
   }
}
