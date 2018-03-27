using System.Drawing;

namespace Breakout
{
   public class ExtraLifePowerUp : PowerUp
   {
      public ExtraLifePowerUp(int theCoordinateX, int theCoordinateY) :
      base(Image.FromFile("../../Images/ExtraLifePowerUp.png"), theCoordinateX, theCoordinateY)
      {
      }

      public override void ExecutePowerUp(FiniteStateMachine theFiniteStateMachine)
      {
         theFiniteStateMachine.SetNumberOfLives(theFiniteStateMachine.GetNumberOfLives() + 1);
      }
   }
}
