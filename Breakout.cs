//************************************************************************************************************************************************
//
// File Name: Pong.cs
//
// Description:
//  TODO: Add description.
//
// Change History:
//  Author               Date           Description
//  Matthew D. Yorke     MM/DD/2018     TODO: Add description.
//************************************************************************************************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Breakout
{
   public partial class Breakout : Form
   {
      // The paddle image depicting the location and size of the image.
      Rectangle mPaddle;

      // Determines during an update if the player is pressing the key to move the paddle left.
      bool mMovePaddleLeft;

      // Determines during an update if the player is pressing the key to move the paddle right.
      bool mMovePaddleRight;

      // The ball image depicting the location and size of the image.
      Rectangle mBall;

      // The X velocity of the ball.
      int mBallVelocityX;

      // The Y velocity of the ball.
      int mBallVelocityY;

      // Determines if the ball has been launched yet.
      bool mBallLaunched;

      // The time object that is used to periodically tick to update the screen.
      Timer mTimer;

      //*********************************************************************************************************************************************
      //
      // Method Name: Breakout
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
      public Breakout()
      {
         InitializeComponent();

         // Start the paddle at the center of the screen and with a padding from the bottom of the screen.
         mPaddle = new Rectangle((this.Size.Width / BreakoutConstants.HALF) - (BreakoutConstants.PADDLE_WIDTH / BreakoutConstants.HALF),
                                 this.Size.Height - BreakoutConstants.PADDLE_BOUNDARY_PADDING,
                                 BreakoutConstants.PADDLE_WIDTH,
                                 BreakoutConstants.PADDLE_HEIGHT);

         // Indicate that on update at the start of the game, the paddles are not moving either left or right.
         mMovePaddleLeft = false;
         mMovePaddleRight = false;

         // Start the ball center of where the paddle starts, but directly above the paddle.
         mBall = new Rectangle((this.Size.Width / BreakoutConstants.HALF) - (BreakoutConstants.BALL_WIDTH_AND_HEIGHT / BreakoutConstants.HALF),
                               this.Size.Height - BreakoutConstants.PADDLE_BOUNDARY_PADDING - BreakoutConstants.BALL_WIDTH_AND_HEIGHT,
                               BreakoutConstants.BALL_WIDTH_AND_HEIGHT,
                               BreakoutConstants.BALL_WIDTH_AND_HEIGHT);

         // Indicate that the ball is not launched at the beginning of the game.
         mBallLaunched = false;

         // Indicate the ball initial velocity before being launched.
         mBallVelocityX = BreakoutConstants.BALL_INITIAL_SPEED;
         mBallVelocityY = BreakoutConstants.BALL_INITIAL_SPEED;

         // Indicate the painting callback method to use when a repaint is called.
         this.Paint += Draw;

         // Indicate that key events will be used in this window.
         this.KeyPreview = true;
         // Indicate the callback method to use when a key is pressed down.
         this.KeyDown += BreakoutKeyDown;
         // Indicate the callback method to use when a key is released.
         this.KeyUp += BreakoutKeyUp;

         // Start up the periodic timer.
         mTimer = new Timer();
         mTimer.Tick += new EventHandler(TimerTick);
         mTimer.Interval = BreakoutConstants.TIMER_INTERVAL;
         mTimer.Enabled = true;
         mTimer.Start();
      }

      private void BreakoutLoad(object theSender, EventArgs theEventArguments)
      {
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: NewMatch
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
      private void NewMatch()
      {
         // Set the paddle to be centered.
         mPaddle.X = (this.Size.Width / BreakoutConstants.HALF) - (BreakoutConstants.PADDLE_WIDTH / BreakoutConstants.HALF);

         // Set the ball to be centered to the paddle, directly above it.
         mBall.X = (this.Size.Width / BreakoutConstants.HALF) - (BreakoutConstants.BALL_WIDTH_AND_HEIGHT / BreakoutConstants.HALF);
         mBall.Y = this.Size.Height - BreakoutConstants.PADDLE_BOUNDARY_PADDING - BreakoutConstants.BALL_WIDTH_AND_HEIGHT;

         // Indicate the ball needs to be launched by the player again.
         mBallLaunched = false;
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: BreakoutKeyDown
      //
      // Description:
      //  Determine which key was pressed down:
      //      Left (Arrow) - Lets the program to know to move the paddle towards the left on the next update.
      //      Right (Arrow) - Lets the program to know to move the paddle towards the right on the next update.
      //
      // Arguments:
      //  theSender - The object that sent the event arguments.
      //  theEventArguments - The events that occurred by the sender.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      private void BreakoutKeyDown(Object theSender, KeyEventArgs theEventArguments)
      {
         switch (theEventArguments.KeyCode)
         {
            // The Left Arrow (<-) key is used for the paddle left movement. Indicate the paddle is now being moved towards the left.
            case Keys.Left:
            {
               mMovePaddleLeft = true;
               break;
            }
            // The Right Arrow (->) key is used for the paddle right movement. Indicate the paddle is now being moved towards the right.
            case Keys.Right:
            {
               mMovePaddleRight = true;
               break;
            }
            // The Space key is used to launch the ball at the beginning of a match. Indicate the ball is now being launched if it has not already been
            // launched.
            case Keys.Space:
            {
               if (mBallLaunched == false)
               {
                  // Note: Launch speed is negative to launch the ball towards the top of the screen.
                  mBallVelocityY = -BreakoutConstants.BALL_LAUNCH_SPEED;
                  // Temp code start.
                  mBallVelocityX = BreakoutConstants.BALL_LAUNCH_SPEED;
                  // Temp code end.
                  mBallLaunched = true;
               }
               break;
            }
            // The Escape key is pressed and ends the application.
            case Keys.Escape:
            {
               Application.Exit();
               break;
            }
            default:
            {
               break;
            }
         }
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: BreakoutKeyUp
      //
      // Description:
      //  Determine which key was release:
      //      Left (Arrow) - Lets the program to know to no longer move the paddle towards the left on the next update.
      //      Right (Arrow) - Lets the program to know to no longer move the paddle towards the right on the next update.
      //
      // Arguments:
      //  theSender - The object that sent the event arguments.
      //  theEventArguments - The events that occurred by the sender.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      private void BreakoutKeyUp(Object theSender, KeyEventArgs theEventArguments)
      {
         // Determine which key is being released.
         switch (theEventArguments.KeyCode)
         {
            // The Left Arrow (<-) is used for the paddle left movement. Indicate the paddle is no longer being moved towards the left.
            case Keys.Left:
            {
               mMovePaddleLeft = false;
               break;
            }
            // The Right Arrow (->) is used for the paddle right movement. Indicate the paddle is no longer being moved towards the right.
            case Keys.Right:
            {
               mMovePaddleRight = false;
               break;
            }
            default:
            {
               break;
            }
         }
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: TimerTick
      //
      // Description:
      //  Call to update the object in the window and then indicate a redraw is needed.
      //
      // Arguments:
      //  theSender - The object that sent the event arguments.
      //  theEventArguments - The events that occurred by the sender.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      private void TimerTick(Object theSender, EventArgs theEventArguments)
      {
         // Update the objects on the window.
         UpdateWindow();
         // Call to redraw the object on the window.
         Invalidate();
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: UpdateWindow
      //
      // Description:
      //  Call to update the objects in the game based on the current game state.
      //
      // Arguments:
      //  N/A
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      private void UpdateWindow()
      {
         // Update the paddles on the window based on the keys pressed down or released.
         UpdatePaddle();
         UpdateBall();
         CheckBallCollision();
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: UpdatePaddle
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
      private void UpdatePaddle()
      {
         // Check if the left button for the paddle is currently being pressed down.
         // Note: If both left AND right buttons are pressed the left button takes precedence.
         if (mMovePaddleLeft == true)
         {
            // Set the paddle x-coordinate to draw further left by the paddle speed.
            mPaddle.X -= BreakoutConstants.PADDLE_SPEED;

            // If the ball has not been launched yet, keep the ball centered directly above the paddle.
            if (mBallLaunched == false)
            {
               mBall.X -= BreakoutConstants.PADDLE_SPEED;
            }

            // Prevent the paddle from going out of bounds at the left edge of the window.
            if (mPaddle.X < BreakoutConstants.SCREEN_X_COORDINATE_LEFT)
            {
               mPaddle.X = BreakoutConstants.SCREEN_X_COORDINATE_LEFT;

               // If the ball has not been launched yet, keep the ball centered directly above the paddle.
               if (mBallLaunched == false)
               {
                  mBall.X = mPaddle.X + (mPaddle.Width / BreakoutConstants.HALF) - (mBall.Width / BreakoutConstants.HALF);
               }
            }
         }
         // Check if the right button for the paddle is currently being pressed down.
         else if (mMovePaddleRight == true)
         {
            // Set the paddle x-coordinate to draw further right by the paddle speed.
            mPaddle.X += BreakoutConstants.PADDLE_SPEED;

            // If the ball has not been launched yet, keep the ball centered directly above the paddle.
            if (mBallLaunched == false)
            {
               mBall.X += BreakoutConstants.PADDLE_SPEED;
            }

            // Prevent the paddle from going out of bounds at the right edge of the window.
            if (mPaddle.X > (this.Size.Width - BreakoutConstants.PADDLE_WIDTH))
            {
               mPaddle.X = this.Size.Width - BreakoutConstants.PADDLE_WIDTH;

               // If the ball has not been launched yet, keep the ball centered directly above the paddle.
               if (mBallLaunched == false)
               {
                  mBall.X = mPaddle.X + (mPaddle.Width / BreakoutConstants.HALF) - (mBall.Width / BreakoutConstants.HALF);
               }
            }
         }
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: UpdateBall
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
      private void UpdateBall()
      {
         // Only update the ball on its own after it has been launched by the player.
         if (mBallLaunched == true)
         {
            mBall.X += mBallVelocityX;
            mBall.Y += mBallVelocityY;
         }
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: CheckBallCollision
      //
      // Description:
      //  Check collision of the ball against the top, bottom, left, and right boundaries as well as the ball against the paddles. The ball will
      //  change in reverse horizontal direction when collision against a paddle and change reverse vertical direction when collision against the
      //  top and bottom boundaries. A ball collision against the
      //
      // Arguments:
      //  N/A
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      private void CheckBallCollision()
      {
         // Check if the ball hits the top border and reverse the y velocity if so.
         if (mBall.Y < 0)
         {
            mBallVelocityY = -mBallVelocityY;
         }
         // Check if the ball hits the left or right border and reverse the y velocity if so.
         else if (mBall.X < 0 ||
                  mBall.X > (this.Size.Width - BreakoutConstants.BALL_WIDTH_AND_HEIGHT))
         {
            mBallVelocityX = -mBallVelocityX;
         }
         // Check if the ball hits the bottom border and start a new match is so.
         else if (mBall.Y > this.Size.Height)
         {
            NewMatch();
         }

         // Check if the ball hits the paddle.
         if (mBall.IntersectsWith(mPaddle))
         {
            mBallVelocityY = -mBallVelocityY;

            //// Check if the ball hit the left side of the paddle.
            if (mBall.X < (mPaddle.X + (mPaddle.Width / BreakoutConstants.HALF)))
            {
               // Check if the ball is not heading towards the left and reverse the x velocity if so.
               if (mBallVelocityX >= 0)
               {
                  mBallVelocityX = -mBallVelocityX;
               }
            }
            // The ball hit the right side of the paddle
            else
            {
               // Check if the ball is not heading towards the right and reverse the x velocity if so.
               if (mBallVelocityX <= 0)
               {
                  mBallVelocityX = -mBallVelocityX;
               }
            }
         }
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: Draw
      //
      // Description:
      //  Draw the game objects onto the window.
      //
      // Arguments:
      //  theSender - The object that sent the event arguments.
      //  theEventArguments - The events that occurred by the sender.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      private void Draw(Object theSender, PaintEventArgs theEventArguments)
      {
         // Create the colors used for the paddle and ball.
         SolidBrush paddleColor = new SolidBrush(Color.Black);
         SolidBrush ballColor = new SolidBrush(Color.Green);

         // Draw the paddle and balls onto the window.
         theEventArguments.Graphics.FillRectangle(paddleColor,
                                                  mPaddle);
         theEventArguments.Graphics.FillRectangle(ballColor,
                                                  mBall);

         // Clean up allocated memory.
         paddleColor.Dispose();
         ballColor.Dispose();
      }
   }
}
