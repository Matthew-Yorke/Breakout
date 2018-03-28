//***************************************************************************************************************************************************
//
// File Name: BallObject.cs
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
   public abstract class BallObject : MasterObject
   {
      // The X velocity of the ball.
      private float mBallVelocityX;
      public float BallVelocityX
      {
         get {return mBallVelocityX;}
         set {mBallVelocityX = value;}
      }

      // The Y velocity of the ball.
      private float mBallVelocityY;
      public float BallVelocityY
      {
         get {return mBallVelocityY;}
         set {mBallVelocityY = value;}
      }

      // Determine how much damage the ball does to a brick.
      private int mDamage;
      public int Damage
      {
         get {return mDamage;}
         set {mDamage = value;}
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: BallObject
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
      public BallObject(Image theImage, int theCoordinateX, int theCoordinateY) :
      base (theImage, theCoordinateX, theCoordinateY)
      {
         // A new ball has no velocity as it is not launched yet.
         mBallVelocityX = BreakoutConstants.BALL_INITIAL_SPEED;
         mBallVelocityY = BreakoutConstants.BALL_INITIAL_SPEED;

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
      public virtual void NewMatch()
      {
         // Reset the paddle to be in the centered horizontally.
         mHitBox.X = (BreakoutConstants.SCREEN_PLAY_AREA_WIDTH / BreakoutConstants.HALF) -
                     (mHitBox.Width / BreakoutConstants.HALF);
         mHitBox.Y = BreakoutConstants.SCREEN_PLAY_AREA_HEIGHT - BreakoutConstants.PADDLE_BOUNDARY_PADDING -
                     mHitBox.Height;

         // On the start of a new match the ball has no velocity since it has not been launched.
         mBallVelocityX = BreakoutConstants.BALL_INITIAL_SPEED;
         mBallVelocityY = BreakoutConstants.BALL_INITIAL_SPEED;
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
         mHitBox.X = theBallCoordinateX;
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
         mHitBox.Y = theBallCoordinateY;
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
      public override void Update()
      {
         mHitBox.X += (int)mBallVelocityX;
         mHitBox.Y += (int)mBallVelocityY;
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
      // Method Name: CheckBallCollisionOnBorders
      //
      // Description:
      //  Determines if the ball has collided with the top, left, right or bottom edge. Ball collision with the top, left, or right edges will result
      //  in the ball reversing its velocity. Collision with the bottom edge will result in a loss in lives for the player and start of a new match
      //  or new game in the case all lives are depleted.
      //
      // Arguments:
      //  theBreakoutGame - TODO: Add description.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public void CheckBallCollisionOnBorders(BreakoutGame theBreakoutGame)
      {
         CheckBallCollisionOnTopBorder(theBreakoutGame);
         CheckBallCollisionOnSideBorders(theBreakoutGame);
         CheckBallCollisionOnBottomBorder(theBreakoutGame);
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: CheckBallCollisionOnTopBorder
      //
      // Description:
      //  TODO: Add description.
      //
      // Arguments:
      //  theBreakoutGame - TODO: Add description.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      private void CheckBallCollisionOnTopBorder(BreakoutGame theBreakoutGame)
      {
         // Reverse the ball Y velocity if the top border is hit by the ball.
         if (mHitBox.Y < 0)
         {
            ReverseBallVelocityY();
         }
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: CheckBallCollisionOnSideBorders
      //
      // Description:
      //  TODO: Add description.
      //
      // Arguments:
      //  theBreakoutGame - TODO: Add description.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      private void CheckBallCollisionOnSideBorders(BreakoutGame theBreakoutGame)
      {
         // Reverse the ball x velocity if the left or right border is hit.
         if (mHitBox.X < 0 ||
             mHitBox.X > (BreakoutConstants.SCREEN_PLAY_AREA_WIDTH - mHitBox.Width))
         {
            ReverseBallVelocityX();
         }
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: CheckBallCollisionOnBottomBorder
      //
      // Description:
      //  TODO: Add description.
      //
      // Arguments:
      //  theBreakoutGame - TODO: Add description.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      protected abstract void CheckBallCollisionOnBottomBorder(BreakoutGame theBreakoutGame);

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
      //  theBreakoutGame - TODO: Add description.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public void CheckBallCollisionOnPaddle(BreakoutGame theBreakoutGame)
      {
         // Check if the ball hits the paddle.
         if (mHitBox.IntersectsWith(theBreakoutGame.Paddle.HitBox))
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
      //  theBreakoutGame - TODO: Add description.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public void CheckBallCollisionOnBricks(BreakoutGame theBreakoutGame)
      {
         // Check if the ball hits a brick
         for (var index = 0; index < theBreakoutGame.Bricks.Count; index++)
         {
            if (mHitBox.IntersectsWith(theBreakoutGame.Bricks[index].HitBox))
            {
               // Since the ball hit the brick, lower that bricks level.
               theBreakoutGame.Bricks[index].BrickLevel = theBreakoutGame.Bricks[index].BrickLevel - mDamage;

               // Check which side of the brick the ball collided and update the balls velocity.
               CheckRectangleEdgeCollision(theBreakoutGame.Bricks[index]);

               // Check if the brick level has hit the destroy level and remove the brick form the array list since it is destroyed.
               if (theBreakoutGame.Bricks[index].BrickLevel <= BreakoutConstants.BRICK_DESTRUCTION_LEVEL)
               {
                  theBreakoutGame.Bricks[index].Destroyed(theBreakoutGame);
                  // Remove the brick from the brick list since it is now destroyed.
                  theBreakoutGame.RemoveBrick(index--);
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
         // Check if the center of the ball is between the width of the brick. If so, then the ball hit the bottom or top side of the brick.
         // The ball's Y velocity is reversed in this case.
         if (mHitBox.X + (mHitBox.Width / BreakoutConstants.HALF) > theBrick.HitBox.X &
             mHitBox.X + (mHitBox.Width / BreakoutConstants.HALF) < (theBrick.HitBox.X + theBrick.HitBox.Width))
         {
            ReverseBallVelocityY();
         }
         // Check if the center of the ball is between the height of the brick. If so, then the ball hit the left or right side of the brick.
         // The ball's X velocity is reversed in this case.
         else if (mHitBox.Y + (mHitBox.Height / BreakoutConstants.HALF) > theBrick.HitBox.Y &
                  mHitBox.Y + (mHitBox.Height / BreakoutConstants.HALF) < (theBrick.HitBox.Y + theBrick.HitBox.Height))
         {
            ReverseBallVelocityX();
         }
         // Otherwise the ball hit the corner of the brick.
         // The ball's x and y velocity are reversed in this case.
         else
         {
            ReverseBallVelocityX();
            ReverseBallVelocityY();
         }
      }
   }
}
