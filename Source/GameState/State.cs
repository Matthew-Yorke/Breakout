//***************************************************************************************************************************************************
//
// File Name: State.cs
//
// Description:
//  The abstract state class that determines what methods concrete states must inherit as well as handling processing that multiple states may use.
//
// Change History:
//  Author               Date           Description
//  Matthew D. Yorke     MM/DD/2018     TODO: Add description.
//
//***************************************************************************************************************************************************

using System.Windows.Forms;
using System.Drawing;

namespace Breakout
{
   public abstract class State
   {
      protected BreakoutGame mBreakoutGame;

      //*********************************************************************************************************************************************
      //
      // Method Name: BreakoutKeyDown
      //
      // Description:
      //  Process the user input for when a key is pressed down. This is an abstract method that all concrete classes must implement.
      //
      // Arguments:
      //  theEventArguments - The events that occurred by the sender.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public abstract void BreakoutKeyDown(KeyEventArgs theEventArguments);

      //*********************************************************************************************************************************************
      //
      // Method Name: BreakoutKeyUp
      //
      // Description:
      //  Process the user input for when a key is released. This is an abstract method that all concrete classes must implement.
      //
      // Arguments:
      //  theEventArguments - The events that occurred by the sender.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public abstract void BreakoutKeyUp(KeyEventArgs theEventArguments);

      //*********************************************************************************************************************************************
      //
      // Method Name: Update
      //
      // Description:
      //  Call to update objects in the current state. This is an abstract method that all concrete classes must implement.
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
      //  Draw objects in the current state. This is an abstract method that all concrete classes must implement.
      //
      // Arguments:
      //  theGraphics - TODO: Add description.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public abstract void Draw(Graphics theGraphics);

      //*********************************************************************************************************************************************
      //
      // Method Name: Draw
      //
      // Description:
      //  TODOL Add description.
      //
      // Arguments:
      //  theGraphics - TODO: Add description.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      protected void DrawPaddle(Graphics theGraphics)
      {
         mBreakoutGame.Paddle.Draw(theGraphics);
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: DrawBall
      //
      // Description:
      //  TODOL Add description.
      //
      // Arguments:
      //  theGraphics - TODO: Add description.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      protected void DrawBall(Graphics theGraphics)
      {
         mBreakoutGame.Ball.Draw(theGraphics);
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: DrawMiniBalls
      //
      // Description:
      //  TODOL Add description.
      //
      // Arguments:
      //  theGraphics - TODO: Add description.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      protected void DrawMiniBalls(Graphics theGraphics)
      {
         foreach (MiniBall currentMiniBall in mBreakoutGame.MiniBalls)
         {
            currentMiniBall.Draw(theGraphics);
         }
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: DrawBullets
      //
      // Description:
      //  TODOL Add description.
      //
      // Arguments:
      //  theGraphics - TODO: Add description.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      protected void DrawBullets(Graphics theGraphics)
      {
         foreach (Bullet currentBullet in mBreakoutGame.Bullets)
         {
            currentBullet.Draw(theGraphics);
         }
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: DrawBricks
      //
      // Description:
      //  TODOL Add description.
      //
      // Arguments:
      //  theGraphics - TODO: Add description.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      protected void DrawBricks(Graphics theGraphics)
      {
         // Draw the array of bricks currently in the game.
         foreach (Brick currentBrick in mBreakoutGame.Bricks)
         {
            currentBrick.Draw(theGraphics);
         }
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: DrawPowerUps
      //
      // Description:
      //  TODO: Add description.
      //
      // Arguments:
      //  theGraphics - TODO: Add description.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public void DrawPowerUps(Graphics theGraphics)
      {
         foreach (PowerUp currentPowerUp in mBreakoutGame.GetPowerUpList())
         {
            currentPowerUp.Draw(theGraphics);
         }
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: DrawParticles
      //
      // Description:
      //  TODO: Add description.
      //
      // Arguments:
      //  theGraphics - TODO: Add description.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public void DrawParticles(Graphics theGraphics)
      {
         foreach (Particle currentParticle in mBreakoutGame.Particles)
         {
            currentParticle.Draw(theGraphics);
         }
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: DrawHud
      //
      // Description:
      //  TODOL Add description.
      //
      // Arguments:
      //  theGraphics - TODO: Add description.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      protected void DrawHud(Graphics theGraphics)
      {
         Image ballImage = Image.FromFile("../../../Images/Ball.png");
         Image ammunitionImage = Image.FromFile("../../../Images/BulletWithCasing.png");

         // Draw the HUD Area
         theGraphics.DrawImage(Image.FromFile("../../../Images/HUD.png"),
                               new RectangleF(0,
                                              BreakoutConstants.SCREEN_PLAY_AREA_HEIGHT,
                                              BreakoutConstants.SCREEN_HUD_AREA_WIDTH,
                                              BreakoutConstants.SCREEN_HUD_AREA_HEIGHT));

         // Draw the number of ball images equal to lives within the "Lives Remaining" box.
        for (int count = 0; count < mBreakoutGame.NumberOfLives; count++)
        {
           theGraphics.DrawImage(ballImage,
                                 new PointF(18 + ((1 + BreakoutConstants.BALL_WIDTH_AND_HEIGHT) * count),
                                            BreakoutConstants.SCREEN_PLAY_AREA_HEIGHT + 57));
        }

         // Draw the number of bullet images equal to ammunition count within the "Ammunition" box.
         for (int count = 0; count < mBreakoutGame.GunAmmunition; count++)
         {
            theGraphics.DrawImage(ammunitionImage,
                                  new PointF(151 + (3 * count),
                                            BreakoutConstants.SCREEN_PLAY_AREA_HEIGHT + 57));
         }
      }
   }
}
