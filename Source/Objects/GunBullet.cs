using System.Drawing;

namespace Breakout
{
   public class Bullet : MasterObject
   {
      private int mDamage;
      public int Damage
      {
         get{return mDamage;}
         set{mDamage = value;}
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: Bullet
      //
      // Description:
      //  TODO: Add description.
      //
      // Arguments:
      //  theCoordinateX - 
      //  theCoordinateY - 
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public Bullet(int theCoordinateX, int theCoordinateY) :
      base(Image.FromFile("../../../Images/Bullet.png"),
           theCoordinateX,
           theCoordinateY)
      {
         mDamage = 1;
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
         mHitBox.Y -= 2;
      }
   }
}
