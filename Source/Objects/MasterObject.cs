//***************************************************************************************************************************************************
//
// File Name: Object.cs
//
// Description:
//  TODO: Add description.

// Change History:
//  Author               Date           Description
//  Matthew D. Yorke     MM/DD/2018     TODO: Add description.
//
//***************************************************************************************************************************************************

using System.Drawing;

namespace Breakout
{
   public abstract class MasterObject
   {
      // The image of the paddle to be drawn on the screen.
      private Image mImage;

      // The hit box of the paddle to allow collision detection.
      protected Rectangle mHitBox;
      public Rectangle HitBox
      {
         get {return mHitBox;}
         set {mHitBox = value;}
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: Paddle
      //
      // Description:
      //  TODO: Add description.
      //
      // Arguments:
      //  theImageLocation - TODO: Add description.
      //  theCoordianteX - TODO: Add description.
      //  theCoordinateY - TODO: Add description.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public MasterObject(Image theImage, int theCoordianteX, int theCoordinateY)
      {
         mImage = theImage;

         mHitBox = new Rectangle(theCoordianteX,
                                 theCoordinateY,
                                 mImage.Width,
                                 mImage.Height);
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
      //  N/A
      //
      //*********************************************************************************************************************************************
      public abstract void Update();

      //*********************************************************************************************************************************************
      //
      // Method Name: Update
      //
      // Description:
      //  Draw the image to the screen.
      //
      // Arguments:
      //  theGraphics - The drawing surface.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public void Draw(Graphics theGraphics)
      {
         theGraphics.DrawImage(mImage, mHitBox);
      }
   }
}
