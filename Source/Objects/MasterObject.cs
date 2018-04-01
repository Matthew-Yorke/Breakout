//***************************************************************************************************************************************************
//
// File Name: MasterObject.cs
//
// Description:
//  This class is an abstract class that all object will inherit from. This class handles the retention of the object image and hit box for collision
//  detection. All objects that inherit this class must implement the update method. The drawing method is called from this class to draw the image
//  at its current location.
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
   public abstract class MasterObject
   {
      // The image of the paddle to be drawn on the screen.
      private Image mObjectImage;
      public Image ObjectImage
      {
         get {return mObjectImage;}
         set {mObjectImage = value;}
      }

      // The hit box of the paddle to allow collision detection.
      protected RectangleF mHitBox;
      public RectangleF HitBox
      {
         get {return mHitBox;}
         set {mHitBox = value;}
      }

      private Vector2D mVector;
      public Vector2D Vector
      {
         get { return mVector; }
         set { mVector = value; }
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: MasterObject
      //
      // Description:
      //  Constructor that holds the image class and creates the hit box at the specified location.
      //
      // Arguments:
      //  theImage - The image to retain for the object.
      //  theCoordianteX - The initial X-Coordinate the object is at.
      //  theCoordinateY - The initial Y-Coordinate the object is at.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public MasterObject(Image theImage, float theCoordianteX, float theCoordinateY, Vector2D theVector)
      {
         mObjectImage = theImage;

         mHitBox = new RectangleF(theCoordianteX,
                                  theCoordinateY,
                                  mObjectImage.Width,
                                  mObjectImage.Height);

         mVector = theVector;
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: Update
      //
      // Description:
      //  Abstract method that all classes must implement for when an object is called to update.
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
      // Method Name: Draw
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
         theGraphics.DrawImage(mObjectImage,
                               mHitBox);
      }
   }
}
