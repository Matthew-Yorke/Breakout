//***************************************************************************************************************************************************
//
// File Name: BallObject.cs
//
// Description:
//  The abstract ball object class that handles common ball functionality including ball collision detection against other object and, setting of the
//  ball location, and updating the ball. Each ball type must implement their own functionality upon the bottom border collision.
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
      //  Constructor to create the ball object including retaining the image and setting the ball at the specified starting location. The initial
      //  ball damage is set here.
      //
      // Arguments:
      //  theImage - The image to retain for the object.
      //  theCoordianteX - The initial X-Coordinate the object is at.
      //  theCoordinateY - The initial Y-Coordinate the object is at.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public BallObject(Image theImage, int theCoordinateX, int theCoordinateY) :
      base (theImage, theCoordinateX, theCoordinateY)
      {
         // Set damage to the initial ball damage;
         mDamage = BreakoutConstants.BALL_INITIAL_DAMAGE;
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: NewMatch
      //
      // Description:
      //  Resets the ball position to be center of the paddle (directly above the paddle) and the velocity.
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
         
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: SetBallCoordinateX
      //
      // Description:
      //  Set the X-Coordinate of the ball to the specified location.
      //
      // Arguments:
      //  theBallCoordinateX - The X-Coordinate location the ball will be set to.
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
      //  Set the Y-Coordinate of the ball to the specified location.
      //
      // Arguments:
      //  theBallCoordinateY - The Y-Coordinate location the ball will be set to.
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
      //  Update the ball X-Coordinate and Y-Coordinate based on the ball velocity.
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
      //  Reverse the X-Velocity to set the ball's motion in the opposite horizontal direction.
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
      //  Reverse the Y-Velocity to set the ball's motion in the opposite vertical direction.
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
      //  Call to determine any collision from the ball against other game objects or play area borders.
      //
      // Arguments:
      //  theBreakoutGame - The game object that tracks various game elements.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public void CheckBallCollisionOnBorders(BreakoutGame theBreakoutGame)
      {
         CheckBallCollisionOnTopBorder();
         CheckBallCollisionOnSideBorders();
         CheckBallCollisionOnBottomBorder(theBreakoutGame);
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: CheckBallCollisionOnTopBorder
      //
      // Description:
      //  Check if the call collides with the top side of the border and reverse the Y velocity if so.
      //
      // Arguments:
      //  N/A
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      private void CheckBallCollisionOnTopBorder()
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
      //  Check if the call collides with the left or right side of the borders and reverse the X velocity if so.
      //
      // Arguments:
      //  N/A
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      private void CheckBallCollisionOnSideBorders()
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
      //  Abstract class all ball objects must implement for when they reach collision with the bottom border.
      //
      // Arguments:
      //  N/A
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
      //  Determines if the ball has collided with the paddle. If the center of the ball is within the width of the paddle then ball will reverse
      //  in its Y velocity. Otherwise the ball hit the side or corner of the paddle and the X and Y velocity are reversed.
      //
      // Arguments:
      //  theBreakoutGame - The game object that tracks various game elements.
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
            // Check if the center of the ball is between the width of the paddle. If so, then the ball hit the bottom or top side of the brick.
            // The ball's Y velocity is reversed in this case.
            if (mHitBox.X + (mHitBox.Width / BreakoutConstants.HALF) > theBreakoutGame.Paddle.HitBox.X &
                mHitBox.X + (mHitBox.Width / BreakoutConstants.HALF) < (theBreakoutGame.Paddle.HitBox.X + theBreakoutGame.Paddle.HitBox.Width))
            {
               ReverseBallVelocityY();
            }
            // Otherwise the ball hit the side or corner of the paddle.
            // The ball's X and Y velocity is reversed in this case.
            else
            {
               ReverseBallVelocityX();
               ReverseBallVelocityY();
            }
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
      //  theBreakoutGame - The game object that tracks various game elements.
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
               // Since the brick is not destroyed, update the brick image.
               else
               {
                  theBreakoutGame.Bricks[index].UpdateBrickImage("../../Images/BrickLevel" +
                                                                 theBreakoutGame.Bricks[index].BrickLevel.ToString() +
                                                                 ".png");
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
      //  Determines which edge the ball collided with against the brick. Collision with the top or bottom will reverse the balls y velocity,
      //  collision with the left or right edge will reverse the balls x velocity, and a corner collision will reverse both the balls x and y
      //  velocity.
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
