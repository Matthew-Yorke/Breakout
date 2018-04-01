//***************************************************************************************************************************************************
//
// File Name: Vector2D.cs
//
// Description:
//  TODO: Add description.
//
// Change History:
//  Author               Date           Description
//  Matthew D. Yorke     MM/DD/2018     TODO: Add description.
//
//***************************************************************************************************************************************************

using System;

namespace Breakout
{
   public class Vector2D
   {
      // Stores the X component of the vector
      private float mComponentX;
      public float ComponentX
      {
         get {return mComponentX;}
      }

      // Store the Y component of the vector.
      private float mComponentY;
      public float ComponentY
      {
         get {return mComponentY;}
      }

      // Stores the length of the vector.
      private float mLength;
      public float Length
      {
         get {return mLength;}
      }


      //*********************************************************************************************************************************************
      //
      // Method Name: Vector2D
      //
      // Description:
      //  Store the X and Y component of the new vector and then calculate the vector length.
      //
      // Arguments:
      //  theComponentX - The X component of the vector.
      //  theComponentY - The Y component of the vector.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public Vector2D(float theComponentX, float theComponentY)
      {
         mComponentX = theComponentX;
         mComponentY = theComponentY;

         CalculateLength();
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: CalculateLength
      //
      // Description:
      //  Calculate the length of the vector based on the X and Y components of the vector.
      //
      // Arguments:
      //  N/A
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      private void CalculateLength()
      {
         mLength = (float)Math.Sqrt(Math.Pow(Math.Abs(mComponentX), 2.0F) + Math.Pow(Math.Abs(mComponentY), 2.0F));
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: SetComponentX
      //
      // Description:
      //  Set a new X component of the vector and update the vector length.
      //
      // Arguments:
      //  theComponentX - The new X component of the vector.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public void SetComponentX(float theComponentX)
      {
         mComponentX = theComponentX;
         CalculateLength();
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: SetComponentY
      //
      // Description:
      //  Set a new Y component of the vector and update the vector length.
      //
      // Arguments:
      //  theComponentY - The new Y component of the vector.
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public void SetComponentY(float theComponentY)
      {
         mComponentY = theComponentY;
         CalculateLength();
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: ReverseComponentX
      //
      // Description:
      //  Reverse the X component of the vector making the object travel in the opposite horizontal direction.
      //
      // Arguments:
      //  N/A
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public void ReverseComponentX()
      {
         mComponentX = -mComponentX;
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: ReverseComponentY
      //
      // Description:
      //  Reverse the Y component of the vector making the object travel in the opposite vertical direction.
      //
      // Arguments:
      //  N/A
      //
      // Return:
      //  N/A
      //
      //*********************************************************************************************************************************************
      public void ReverseComponentY()
      {
         mComponentY = -mComponentY;
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: GetNormalizedComponentX
      //
      // Description:
      //  Returns the normalized value of the X component of the vector.
      //
      // Arguments:
      //  N/A
      //
      // Return:
      //  Return the normalized X component value.
      //
      //*********************************************************************************************************************************************
      public float GetNormalizedComponentX()
      {
         return mComponentX / mLength;
      }

      //*********************************************************************************************************************************************
      //
      // Method Name: GetNormalizedComponentY
      //
      // Description:
      //  Returns the normalized value of the Y component of the vector.
      //
      // Arguments:
      //  N/A
      //
      // Return:
      //  Return the normalized Y component value.
      //
      //*********************************************************************************************************************************************
      public float GetNormalizedComponentY()
      {
         return mComponentY / mLength;
      }
   }
}
