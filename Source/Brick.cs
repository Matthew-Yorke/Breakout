
using System.Drawing;

namespace Breakout
{
   public class Brick
   {
      // The rectangle elements of the brick including the coordinates, width, and height.
      public Rectangle mBrickImage;

      // The level of the brick.
      public int mBrickLevel;

      public Brick(Rectangle theBrickImage, int theBrickLevel)
      {
         mBrickImage = theBrickImage;
         mBrickLevel = theBrickLevel;
      }
   }
}
