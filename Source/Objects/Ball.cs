//***************************************************************************************************************************************************
//
// File Name: Ball.cs
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
   public class Ball
   {
      // The ball image depicting the location and size of the image.
      private Rectangle mBallRectangle;

      // The X velocity of the ball.
      float mBallVelocityX;

      // The Y velocity of the ball.
      float mBallVelocityY;

      // Determines if the ball has been launched yet.
      bool mBallLaunched;

      // Determine how much damage the ball does to a brick.
      int mDamage;

      //*********************************************************************************************************************************************
      //
      // Method Name: Ball
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
      public Ball()
      {
         // Start the ball center of where the paddle starts, but directly above the paddle.
         mBallRectangle = new Rectangle((BreakoutConstants.SCREEN_PLAY_AREA_WIDTH / BreakoutConstants.HALF) - (BreakoutConstants.BALL_WIDTH_AND_HEIGHT / BreakoutConstants.HALF),
                                        BreakoutConstants.SCREEN_PLAY_AREA_HEIGHT - BreakoutConstants.PADDLE_BOUNDARY_PADDING - BreakoutConstants.BALL_WIDTH_AND_HEIGHT,
                                        BreakoutConstants.BALL_WIDTH_AND_HEIGHT,
                                        BreakoutConstants.BALL_WIDTH_AND_HEIGHT);

         // A new ball has no velocity as it is not launched yet.
         mBallVelocityX = BreakoutConstants.BALL_INITIAL_SPEED;
         mBallVelocityY = BreakoutConstants.BALL_INITIAL_SPEED;

         // A new ball has not been launched yet.
         mBallLaunched = false;

         // Set damage to the initial ball damage;
         mDamage = BreakoutConstants.BALL_INITIAL_DAMAGE;
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
      public void NewMatch()
      {
         // Reset the paddle to be in the centered horizontally.
         mBallRectangle.X = (BreakoutConstants.SCREEN_PLAY_AREA_WIDTH / BreakoutConstants.HALF) -
                            (BreakoutConstants.BALL_WIDTH_AND_HEIGHT / BreakoutConstants.HALF);
         mBallRectangle.Y = BreakoutConstants.SCREEN_PLAY_AREA_HEIGHT - BreakoutConstants.PADDLE_BOUNDARY_PADDING -
                            BreakoutConstants.BALL_WIDTH_AND_HEIGHT;

         // On the start of a new match the ball has no velocity since it has not been launched.
         mBallVelocityX = BreakoutConstants.BALL_INITIAL_SPEED;
         mBallVelocityY = BreakoutConstants.BALL_INITIAL_SPEED;

         // On the start of a new match the ball has not been launched yet.
         mBallLaunched = false;
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: SetBallCoordinateX
      //
      // Description:
      //  TODO: Add description.
      //
      // Arguments:
      //  theBallCoordinateX - TODO: Add description.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public void SetBallCoordinateX(int theBallCoordinateX)
      {
         mBallRectangle.X = theBallCoordinateX;
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: SetBallCoordinateY
      //
      // Description:
      //  TODO: Add description.
      //
      // Arguments:
      //  theBallCoordinateY - TODO: Add description.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public void SetBallCoordinateY(int theBallCoordinateY)
      {
         mBallRectangle.Y = theBallCoordinateY;
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: SetBallVelocityX
      //
      // Description:
      //  TODO: Add description.
      //
      // Arguments:
      //  theBallVelocityX- TODO: Add description.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public void SetBallVelocityX(float theBallVelocityX)
      {
         mBallVelocityX = theBallVelocityX;
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: SetBallVelocityY
      //
      // Description:
      //  TODO: Add description.
      //
      // Arguments:
      //  theBallVelocityY - TODO: Add description.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public void SetBallVelocityY(float theBallVelocityY)
      {
         mBallVelocityY = theBallVelocityY;
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: GetBallRectangle
      //
      // Description:
      //  TODO: Add description.
      //
      // Arguments:
      //  N/A
      //
      // Return:
      //  TODO: Add description.
      //
      //*********************************************************************************************************************************************
      public Rectangle GetBallRectangle()
      {
         return mBallRectangle;
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: SetBallLaunched
      //
      // Description:
      //  TODO: Add description.
      //
      // Arguments:
      //  theBallLaunched - TODO: Add description.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public void SetBallLaunched(bool theBallLaunched)
      {
         mBallLaunched = theBallLaunched;
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: GetBallLaunched
      //
      // Description:
      //  TODO: Add description.
      //
      // Arguments:
      //  N/A
      //
      // Return:
      //  TODO: Add description.
      //
      //*********************************************************************************************************************************************
      public bool GetBallLaunched()
      {
         return mBallLaunched;
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
      public void UpdateBall()
      {
         mBallRectangle.X += (int)mBallVelocityX;
         mBallRectangle.Y += (int)mBallVelocityY;
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: ReverseBallVelocityX
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
      private void ReverseBallVelocityX()
      {
         mBallVelocityX = -mBallVelocityX;
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: ReverseBallVelocityY
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
      private void ReverseBallVelocityY()
      {
         mBallVelocityY = -mBallVelocityY;
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: SetDamage
      //
      // Description:
      //  TODO: Add description.
      //
      // Arguments:
      //  theDamage - TODO: Add description.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public void SetDamage(int theDamage)
      {
         mDamage = theDamage;
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: CheckBallCollisionOnBorders
      //
      // Description:
      //  Determines if the ball has collided with the top, left, right or bottom edge. Ball collision with the top, left, or right edges will result
      //  in the ball reversing its velocity. Collision with the bottom edge will result in a loss in lives for the player and start of a new match
      //  or new game in the case all lives are depleted.
      //
      // Arguments:
      //  N/A
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public void CheckBallCollisionOnBorders(FiniteStateMachine theFiniteStateMachine)
      {
         // Check if the ball hits the top border and reverse the y velocity if so.
         if (mBallRectangle.Y < 0)
         {
            // Reverse the Y velocity.
            ReverseBallVelocityY();
         }
         // Check if the ball hits the left or right border and reverse the y velocity if so.
         else if (mBallRectangle.X < 0 ||
                  mBallRectangle.X > (BreakoutConstants.SCREEN_PLAY_AREA_WIDTH - BreakoutConstants.BALL_WIDTH_AND_HEIGHT))
         {
            // Reverse the X velocity.
            ReverseBallVelocityX();
         }
         // Check if the ball hits the bottom border and decrement the number of lives the player has left.
         // If lives goes below the threshold for game over, the game reverts back to the start screen.  
         // Otherwise a new match begins.
         else if (mBallRectangle.Y > BreakoutConstants.SCREEN_PLAY_AREA_HEIGHT)
         {
            theFiniteStateMachine.SetNumberOfLives(theFiniteStateMachine.GetNumberOfLives() - 1);
            if (theFiniteStateMachine.GetNumberOfLives() < 0)
            {
               theFiniteStateMachine.SetNumberOfLives(BreakoutConstants.INITIAL_LIVES_REMAINING);
               theFiniteStateMachine.PopState();
            }
            else
            {
               NewMatch();
            }
         }
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: CheckBallCollisionOnPaddle
      //
      // Description:
      //  Determines if the ball has collided with the paddle. The check includes to determine which side of the paddle the ball hit. If the ball
      //  hits the left side of the paddle the ball will move towards the left. If the ball hits the right side of the paddle the ball will move
      //  towards the right.
      //
      // Arguments:
      //  N/A
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public void CheckBallCollisionOnPaddle(FiniteStateMachine theFiniteStateMachine)
      {
         // Check if the ball hits the paddle.
         if (mBallRectangle.IntersectsWith(theFiniteStateMachine.GetPaddle().GetPaddleRectangle()))
         {
            ReverseBallVelocityY();
         }
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: CheckBallCollisionOnBricks
      //
      // Description:
      //  Determines if the ball has collided with any bricks. If there is a case the ball will reverse velocity dependent on the edge of the brick
      //  the ball hit. The brick will lose a level and be destroyed when the level drops below the destruction level.
      //
      // Arguments:
      //  N/A
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public void CheckBallCollisionOnBricks(FiniteStateMachine theFiniteStateMachine)
      {
         // Check if the ball hits a brick
         for (var index = 0; index < theFiniteStateMachine.GetBrickList().Count; index++)
         {
            if (mBallRectangle.IntersectsWith(theFiniteStateMachine.GetBrickList()[index].GetBrickRectangle()))
            {
               // Since the ball hit the brick, lower that bricks level.
               theFiniteStateMachine.GetBrickList()[index].SetBrickLevel(theFiniteStateMachine.GetBrickList()[index].GetBrickLevel() -
                                                                         mDamage);

               // Check which side of the brick the ball collided and update the balls velocity.
               CheckRectangleEdgeCollision(theFiniteStateMachine.GetBrickList()[index]);

               // Check if the brick level has hit the destroy level and remove the brick form the array list since it is destroyed.
               if (theFiniteStateMachine.GetBrickList()[index].GetBrickLevel() <= BreakoutConstants.BRICK_DESTRUCTION_LEVEL)
               {
                  theFiniteStateMachine.RemoveBrick(index--);
               }

               break;
            }
         }
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: CheckRectangleEdgeCollision
      //
      // Description:
      //  Determines which edge the ball collided with against the brick. Collision with the left or right edge will reverse the balls x velocity
      //  and collision with the top or bottom will reverse the y velocity.
      //
      // Arguments:
      //  theBrick - The brick the ball collided with.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      private void CheckRectangleEdgeCollision(Brick theBrick)
      {

         // Determines if the ball hit the upper right cross section of the brick (true) or the bottom left section (false).
         bool isAboveTopLeftAndBottomRight = IsOnUpperSideOfLine(theBrick.GetBrickRectangle().X + theBrick.GetBrickRectangle().Width,  // Bottom right brick corner
                                                                 theBrick.GetBrickRectangle().Y + theBrick.GetBrickRectangle().Height, // Bottom right brick corner
                                                                 theBrick.GetBrickRectangle().X,                                       // Top left brick corner.
                                                                 theBrick.GetBrickRectangle().Y);                                      // Top left brick corner.

         // Determines if the ball hit the upper left cross section of the brick (true) or the bottom right section (false).
         bool isAboveTopRightAndBottomLeft = IsOnUpperSideOfLine(theBrick.GetBrickRectangle().X + theBrick.GetBrickRectangle().Width,   // Top right brick corner.
                                                                 theBrick.GetBrickRectangle().Y,                                        // Top right brick corner.
                                                                 theBrick.GetBrickRectangle().X,                                        // Bottom left brick corner
                                                                 theBrick.GetBrickRectangle().Y + theBrick.GetBrickRectangle().Height); // Bottom left brick corner


         // The ball hit the upper right cross section (so either the top or right edge).
         if (isAboveTopLeftAndBottomRight == true)
         {
            // The ball hit the upper left cross section (so either the top or left). Therefore ball hit the top edge of the brick.
            if (isAboveTopRightAndBottomLeft == true)
            {
               ReverseBallVelocityY();
            }
            // The ball hit the lower right cross section (so either the bottom or right). Therefore ball hit the right edge of the brick.
            else
            {
               ReverseBallVelocityX();
            }
         }
         // The ball hit the lower left cross section (so either the left or bottom edge)
         else
         {
            // The ball hit the upper left cross section (so either the top or left). Therefore the ball hit the left edge of the brick.
            if (isAboveTopRightAndBottomLeft == true)
            {
               ReverseBallVelocityX();
            }
            // The ball hit the lower right cross section (so either the bottom or right). Therefore the ball hit the bottom edge of the brick.
            else
            {
               ReverseBallVelocityY();
            }
         }
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: IsOnUpperSideOfLine
      //
      // Description:
      //  Determines if the ball was above the line between by the passed in parameters (true) or below the line (false).
      //
      // Arguments:
      //  theLineStartX - The starting x-coordinate of the line.
      //  theLineStartY - The starting y-coordinate of the line
      //  theLineEndX - The ending x-coordinate of the line.
      //  theLineEndY - The ending y-coordinate of the line.
      //
      // Return:
      //  True - The ball is above the line.
      //  False - The ball is below the line.
      //
      //*********************************************************************************************************************************************
      public bool IsOnUpperSideOfLine(int theLineStartX, int theLineStartY, int theLineEndX, int theLineEndY)
      {
         return ((theLineEndX - theLineStartX) *
                 ((mBallRectangle.Y + mBallRectangle.Width / BreakoutConstants.HALF) - theLineStartY) -
                 (theLineEndY - theLineStartY) *
                 ((mBallRectangle.X + mBallRectangle.Width / BreakoutConstants.HALF) - theLineStartX)) > 0;
      }
   }
}
