﻿//***************************************************************************************************************************************************
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
      // Determine how much damage the ball does to a brick.
      private int mDamage;
      public int Damage
      {
         get {return mDamage;}
         set {mDamage = value;}
      }

      // Inner hit box used to help determine which side of a brick the ball collided against.
      private RectangleF mInnerHitDetection;
      public RectangleF InnerHitDetection
      {
         get {return mInnerHitDetection;}
         set {mInnerHitDetection = value;}
      }

      // The padding from the normal hit box that the inner hit box starts at.
      private float mInnerHitPadding;

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
      //  theVector - The starting vector of the ball on creation (before it is launched).
      //  theInnerHitPadding - The padding from the normal hit box the inner hit box is located at.
      //  theInnnerHitWidthAndHeight - The width and height of the inner hit box.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public BallObject(Image theImage, float theCoordinateX, float theCoordinateY, Vector2D theVector, float theInnerHitPadding,
                        float theInnnerHitWidthAndHeight) :
      base (theImage,
            theCoordinateX,
            theCoordinateY,
            theVector)
      {
         mInnerHitDetection = new RectangleF(theCoordinateX + theInnerHitPadding,
                                             theCoordinateY + theInnerHitPadding,
                                             theInnnerHitWidthAndHeight,
                                             theInnnerHitWidthAndHeight);

         mInnerHitPadding = theInnerHitPadding;

         // Set damage to the initial ball damage;
         mDamage = BreakoutConstants.BALL_INITIAL_DAMAGE;
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
      public void SetBallCoordinateX(float theBallCoordinateX)
      {
         mHitBox.X = theBallCoordinateX;
         mInnerHitDetection.X = theBallCoordinateX + mInnerHitPadding;
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
      public void SetBallCoordinateY(float theBallCoordinateY)
      {
         mHitBox.Y = theBallCoordinateY;
         mInnerHitDetection.Y = theBallCoordinateY + mInnerHitPadding;
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: UpdateBall
      //
      // Description:
      //  Update the ball X-Coordinate and Y-Coordinate based on the ball velocity vector.
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
         mHitBox.X += Vector.GetNormalizedComponentX();
         mHitBox.Y += Vector.GetNormalizedComponentY();

         mInnerHitDetection.X += Vector.GetNormalizedComponentX();
         mInnerHitDetection.Y += Vector.GetNormalizedComponentY();
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
            Vector.ReverseComponentY();
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
            Vector.ReverseComponentX();
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
            // Keep the ball above the paddle to avoid the ball getting stuck inside the paddle.
            mHitBox.Y = theBreakoutGame.Paddle.HitBox.Y - mHitBox.Height;
            mInnerHitDetection.Y = mHitBox.Y + mInnerHitPadding;

            // The Y (vertical) component is always reversed on a paddle hit.
            Vector.ReverseComponentY();

            // Transfer a percentage of the paddles velocity to the ball. This helps the player to change to angle of the ball with the paddle.
            Vector.SetComponentX(Vector.ComponentX +
                                 (theBreakoutGame.Paddle.Vector.ComponentX * BreakoutConstants.PADDLE_VECTOR_TRANSFER_PERCENTAGE));
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
                  theBreakoutGame.Bricks.RemoveAt(index--);
               }
               // Since the brick is not destroyed, update the brick image.
               else
               {
                  theBreakoutGame.Bricks[index].UpdateBrickImage("../../../Images/BrickLevel" +
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
         if ((mInnerHitDetection.X + mInnerHitDetection.Width) > theBrick.HitBox.X &&
             mInnerHitDetection.X < (theBrick.HitBox.X + theBrick.HitBox.Width))
         {
            Vector.ReverseComponentY();
         }
         // Check if the center of the ball is between the height of the brick. If so, then the ball hit the left or right side of the brick.
         // The ball's X velocity is reversed in this case.
         else if ((mInnerHitDetection.Y + mInnerHitDetection.Height) > theBrick.HitBox.Y &&
                  mInnerHitDetection.Y < (theBrick.HitBox.Y + theBrick.HitBox.Height))
         {
            Vector.ReverseComponentX();
         }
         // Otherwise the ball hit the corner of the brick.
         // The ball's x and y velocity are reversed in this case.
         else
         {
            Vector.ReverseComponentX();
            Vector.ReverseComponentY();
         }
      }
   }
}
