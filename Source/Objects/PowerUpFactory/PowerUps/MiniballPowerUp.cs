//***************************************************************************************************************************************************
//
// File Name: MiniballPowerUp.cs
//
// Description:
//  TODO: Add description.
//
// Change History:
//  Author               Date           Description
//  Matthew D. Yorke     MM/DD/2018     TODO: Add description.
//
//***************************************************************************************************************************************************

using System.Drawing;

namespace Breakout
{
   public class MiniballPowerUp : PowerUp
   {
      //*********************************************************************************************************************************************
      //
      // Method Name: MiniballPowerUp
      //
      // Description:
      //  TODO: Add description.
      //
      // Arguments:
      //  theCoordinateX - TODO: Add description.
      //  theCoordinateY - TODO: Add description.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public MiniballPowerUp(int theCoordinateX, int theCoordinateY) :
      base(Image.FromFile("../../Images/MiniballPowerUp.png"), theCoordinateX, theCoordinateY)
      {
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: ExecutePowerUp
      //
      // Description:
      //  TODO: Add description.
      //
      // Arguments:
      //  theFiniteStateMachine - TODO: Add description.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public override void ExecutePowerUp(FiniteStateMachine theFiniteStateMachine)
      {
         theFiniteStateMachine.MiniBalls.Add(new MiniBall(theFiniteStateMachine));
      }
   }
}
