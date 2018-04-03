//***************************************************************************************************************************************************
//
// File Name: Rocket.cs
//
// Description:
//  This class handles the functionality of a bullet in the game. This class will create the bullet at the set location and upon an update will move
//  the bullet forward based on the bullet velocity.
//
// Change History:
//  Author               Date           Description
//  Matthew D. Yorke     MM/DD/2018     TODO: Add description.
//
//***************************************************************************************************************************************************

using System.Drawing;
using System.Collections.Generic;

namespace Breakout
{
   public class Rocket : MasterObject
   {
      private int mDamage;
      public int Damage
      {
         get { return mDamage; }
         set { mDamage = value; }
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: Rocket
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
      public Rocket(float theCoordinateX, float theCoordinateY) :
      base(Image.FromFile("../../../Images/Rocket.png"),
           theCoordinateX,
           theCoordinateY,
           new Vector2D(BreakoutConstants.BULLET_VELOCITY_X,
                        BreakoutConstants.BULLET_VELOCITY_Y))
      {
         mDamage = BreakoutConstants.BULLET_DAMAGE;
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: Update
      //
      // Description:
      //  Update the bullet to head towards the top of the screen.
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
         mHitBox.Y += Vector.GetNormalizedComponentY();
      }
   }
}
