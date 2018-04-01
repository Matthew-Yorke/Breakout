//***************************************************************************************************************************************************
//
// File Name: MiniBallPowerUp.cs
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
   public class MiniBallPowerUp : PowerUp
   {
      //*********************************************************************************************************************************************
      //
      // Method Name: MiniBallPowerUp
      //
      // Description:
      //  Constructor that creates the mini ball power up at the specified starting location.
      //
      // Arguments:
      //  theCoordianteX - The initial X-Coordinate the object is at.
      //  theCoordinateY - The initial Y-Coordinate the object is at.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public MiniBallPowerUp(float theCoordinateX, float theCoordinateY) :
      base(Image.FromFile("../../../Images/MiniballPowerUp.png"), theCoordinateX, theCoordinateY)
      {
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: ExecutePowerUp
      //
      // Description:
      //  Adds a new mini ball to the game centered to the paddle (directly above the paddle).
      //
      // Arguments:
      //  theBreakoutGame - Reference to the breakout game.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public override void ExecutePowerUp(BreakoutGame theBreakoutGame)
      {
         theBreakoutGame.MiniBalls.Add(new MiniBall(Image.FromFile("../../../Images/MiniBall.png"),
                                                    theBreakoutGame.Paddle.HitBox.X + (theBreakoutGame.Paddle.HitBox.X / BreakoutConstants.HALF) -
                                                       BreakoutConstants.MINI_BALL_WIDTH_AND_HEIGHT,
                                                    theBreakoutGame.Paddle.HitBox.Y - BreakoutConstants.MINI_BALL_WIDTH_AND_HEIGHT));
      }
   }
}
