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
      private PointF mVelocity;
      private int mParticleSize;

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
      public Particle(float theCoordinateX, float theCoordinateY)
      {
         mLocation = new PointF(theCoordinateX,
                                theCoordinateY);

         mLiveTime = new TimeSpan(0,
                                  0,
                                  0,
                                  0,
                                  200);

         Random random = new Random();
         float randomAngle = (float)(random.NextDouble() * Math.PI);

         mVelocity = new PointF((float)Math.Cos(randomAngle),
                                (float)Math.Sin(randomAngle));

         mParticleSize = 4;
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
         if (mBirthTime == null)
         {
            mBirthTime = DateTime.Now;
         }

         mLocation.X += mVelocity.X;
         mLocation.Y += mVelocity.Y;

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
         SolidBrush particleColor = new SolidBrush(Color.DarkGray);

         theGraphics.FillRectangle(particleColor,
                                   mLocation.X - (mParticleSize / BreakoutConstants.HALF),
                                   mLocation.Y - (mParticleSize / BreakoutConstants.HALF),
                                   mParticleSize,
                                   mParticleSize);

         particleColor.Dispose();
      }
   }
}
