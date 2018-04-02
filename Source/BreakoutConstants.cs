//***************************************************************************************************************************************************
//
// File Name: BreakoutConstants.cs
//
// Description:
//  Constants used throughout the breakout game.
//
// Change History:
//  Author               Date           Description
//  Matthew D. Yorke     MM/DD/2018     TODO: Add description.
//
//***************************************************************************************************************************************************

namespace Breakout
{
   public static class BreakoutConstants
   {
      // The width the screen play area is for the game.
      public const int SCREEN_PLAY_AREA_WIDTH = 750;

      // The height the screen play area is for the game.
      public const int SCREEN_PLAY_AREA_HEIGHT = 450;

      // The width the HUD (Heads Up Display) area is for the game.
      public const int SCREEN_HUD_AREA_WIDTH = 750;

      // The height the HUD (Heads Up Display) area is for the game.
      public const int SCREEN_HUD_AREA_HEIGHT = 100;

      // The x-coordinate of the left edge of the screen.
      public const int SCREEN_X_COORDINATE_LEFT = 0;

      // The number of start screen option the user can cycle through.
      public const int NUMBER_OPTIONS_ON_START_SCREEN = 2;

      // The integer value of the first enumeration value in the list.
      public const int ENUM_FIRST_INTEGER = 0;

      // The offset needed for enums that start at 0 for enumeration calculations.
      public const int ENUM_OFFSET = 1;

      // The file location of the paddle image.
      public const string PADDLE_IMAGE_FILE = "../../../Images/Paddle.png";

      // The padding in pixels between a end-zone and any paddle in the game.
      public const int PADDLE_BOUNDARY_PADDING = 20;

      // Determine the amount of padding from the edge of the paddle to the gun placement
      public const int PADDLE_PADDING_TO_GUN = 3;

      // The speed the paddle increases by while moving in the same direction.
      public const int PADDLE_SPEED_INCREASE = 2;

      // The maximum speed the paddle can move.
      public const int PADDLE_MAX_SPEED = 10;

      // The width of the paddle in pixels.
      public const int PADDLE_WIDTH = 200;

      // The percentage (represented between 0.0-1.0) of the amount of vector force to transfer to the ball on collision.
      public const float PADDLE_VECTOR_TRANSFER_PERCENTAGE = 0.1F;

      // The width and height in pixels the ball in the game is.
      public const float BALL_WIDTH_AND_HEIGHT = 14.0F;

      // The padding used to where to start the inner hit detection rectangle within the ball hit detection to use as improved detection against
      // which side of a rectangle the ball collided on.
      public const float BALL_INNER_DETECTION_PADDING = 3;

      // The width and height used for the inner hit detection rectangle within the ball hit detection to use as improved detection against which
      // side of a rectangle the ball collided on.
      public const float BALL_INNER_DETECTION_WIDTH_AND_HEIGHT = 9;

      // The initial horizontal speed of a ball when a new match begins (after the ball is launched by the player).
      public const float BALL_INITIAL_SPEED_X = 0.0F;

      // The initial vertical speed of a ball when a new match begins (after the ball is launched by the player).
      public const float BALL_INITIAL_SPEED_Y = -2.0F;

      // The width and height in pixels a mini ball in the game is.
      public const float MINI_BALL_WIDTH_AND_HEIGHT = 10.0F;

      // The initial horizontal speed of a mini ball when created.
      public const float MINI_BALL_INITIAL_SPEED_X = 0.0F;

      // The initial vertical speed of a mini ball when created.
      public const float MINI_BALL_INITIAL_SPEED_Y = -2.0F;

      // The padding used to where to start the inner hit detection rectangle within the mini ball hit detection to use as improved detection against
      // which side of a rectangle the ball collided on.
      public const float MINI_BALL_INNER_DETECTION_PADDING = 3;

      // The width and height used for the inner hit detection rectangle within the mini ball hit detection to use as improved detection against
      // which side of a rectangle the ball collided on.
      public const float MINI_BALL_INNER_DETECTION_WIDTH_AND_HEIGHT = 5;

      // The initial damage ball does to a brick.
      public const int BALL_INITIAL_DAMAGE = 1;

      // The width of a bullet.
      public const int BULLET_WIDTH = 3;

      // The width of a single brick.
      public const int BRICK_WIDTH = 50;

      // The height of a single brick.
      public const int BRICK_HEIGHT = 15;

      // The level a brick must be to be destroyed.
      public const int BRICK_DESTRUCTION_LEVEL = 0;

      // The width and length of the brick explosion particle.
      public const int BRICK_EXPLOSION_WIDTH_AND_LENGTH = 4;

      // The minimum angle the explosion particle will go when a brick is destroyed.
      public const int BRICK_EXPLOSION_MINIMUM_ANGLE = 0;

      // The maximum angle the explosion particle will go when a brick is destroyed.
      public const int BRICK_EXPLOSION_MAXIMUM_ANGLE = 360;

      // The number of milliseconds for the explosion particles to exist when a brick explodes.
      public const int BRICK_EXPLOSION_TIME_MILLISECONDS = 1000;

      // The file location of the bullet image.
      public const string BULLET_IMAGE_LOCATION = "../../../Images/Bullet.png";

      // The velocity of the bullet when fired in the x direction.
      public const float BULLET_VELOCITY_X = 0.0F;

      // The damage a bullet does to a brick.
      public const int BULLET_DAMAGE = 1;

      // The velocity of the bullet when fired in the x direction.
      public const float BULLET_VELOCITY_Y = -5.0F;

      // The width and length of the bullet smoke particle.
      public const int BULLET_SMOKE_TRAIL_WIDTH_AND_LENGTH = 4;

      // The minimum angle the explosion particle will go when a brick is destroyed.
      public const int BULLET_SMOKE_TRAIL_MINIMUM_ANGLE = 135;

      // The maximum angle the explosion particle will go when a brick is destroyed.
      public const int BULLET_SMOKE_TRAIL_MAXIMUM_ANGLE = 225;

      // The number of milliseconds for the explosion particles to exist when a brick explodes.
      public const int BULLET_SMOKE_TRAIL_TIME_MILLISECONDS = 400;

      // The level when a new game starts.
      public const int NEW_GAME_LEVEL = 2;

      // String for the level folders when loading a level.
      public const string LEVELS_FOLDER = "../../../Levels/Level";

      // String for the text file format when loading a level.
      public const string TEXT_FILE = ".txt";

      // Delimiter used when reading a line in the level text file.
      public const string LEVEL_DELIMITER = ",";

      // String to indicate no brick to be placed when loading a level.
      public const string NO_BRICK_STRING = "0";

      // String to indicate a level one brick to be placed when loading a level.
      public const string LEVEL_ONE_BRICK_STRING = "1";

      // String to indicate a level two brick to be placed when loading a level.
      public const string LEVEL_TWO_BRICK_STRING = "2";

      // String to indicate a level three  brick to be placed when loading a level.
      public const string LEVEL_THREE_BRICK_STRING = "3";

      // Integer to indicate a level one brick to be placed when drawing.
      public const int LEVEL_ONE_BRICK_INTEGER = 1;

      // Integer to indicate a level two brick to be placed when drawing.
      public const int LEVEL_TWO_BRICK_INTEGER = 2;

      // Integer to indicate a level three  brick to be placed when drawing.
      public const int LEVEL_THREE_BRICK_INTEGER = 3;

      // The number of bricks to indicate level is complete.
      public const int BRICKS_LEFT_TO_COMPLETE_LEVEL = 0;

      // The lowest number in a percentage.
      public const int ZERO_PERCENT = 0;

      // The highest number in a percentage.
      public const int ONE_HUNDRED_PERCENT = 100;

      // Added to the random number generator range to be inclusive.
      public const int RANDOM_NUMBER_INCLUSION = 1;

      // The percent chance a power up will drop upon a brick being destroyed.
      public const int POWER_UP_DROP_PERCENT = 5;

      // Chance the Extra Life power up will drop when a power up drops.
      public const int EXTRA_LIFE_POWER_UP_PERCENT_CHANCE = 45;

      // Chance the Extra Life power up will drop when a power up drops.
      public const int MINI_BALL_POWER_UP_PERCENT_CHANCE = 35;

      // Chance the Extra Life power up will drop when a power up drops.
      public const int GUN_POWER_UP_PERCENT_CHANCE = 20;

      // The final level of the game.
      public const int FINAL_LEVEL = 3;

      // The initial amount of lives the player has at the beginning of a new game.
      public const int INITIAL_LIVES_REMAINING = 5;

      // The number of lives lost when the ball goes out of play.
      public const int LIFE_LOST = 1;

      // The number of milliseconds for a clock tick to occur.
      public const int TIMER_INTERVAL = 16;

      // The family name for the score and timer text.
      public const string TEXT_FAMILY_NAME = "Arial";

      // The font size for the start screen option text.
      public const int START_SCREEN_TEXT_SIZE = 32;

      // The font size for the pause screen text.
      public const int PAUSE_SCREEN_TEXT_SIZE = 32;

      // The font size for the score and timer text.
      public const int HUD_TEXT_SIZE = 12;

      // The text to be displayed when the game is paused.
      public const string PAUSE_STRING = "PAUSE";

      // Used for dividing a value in half.
      public const int HALF = 2;
   }
}
