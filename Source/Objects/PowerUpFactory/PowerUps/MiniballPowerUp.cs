using System.Drawing;

namespace Breakout
{
   public class MiniballPowerUp : PowerUp
   {
      public MiniballPowerUp(int theCoordinateX, int theCoordinateY) :
      base(Image.FromFile("../../Images/MiniballPowerUp.png"), theCoordinateX, theCoordinateY)
      {
      }

      public override void ExecutePowerUp(FiniteStateMachine theFiniteStateMachine)
      {
         
      }
   }
}
