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

      // The width in pixels of any paddle in the game.
      public const int PADDLE_WIDTH = 200;

      // The height in pixels of any paddle in the game
      public const int PADDLE_HEIGHT = 10;

      // The padding in pixels between a end-zone and any paddle in the game.
      public const int PADDLE_BOUNDARY_PADDING = 20;

      // The speed (number of pixel movement) the paddle in the game can move at.
      public const int PADDLE_SPEED = 10;

      // The width and height in pixels the ball in the game is.
      public const int BALL_WIDTH_AND_HEIGHT = 14;

      // The initial speed of a ball when a match begins.
      public const float BALL_INITIAL_SPEED = 0.0F;

      // The speed of a ball when launched.
      public const int BALL_LAUNCH_SPEED = 2;

      // The speed increase when the ball hits a boundary, paddle, or brick.
      public const int BALL_SPEED_INCREASE = 0;

      // The initial damage ball does to a brick.
      public const int BALL_INITIAL_DAMAGE = 1;

      // The width of a single brick.
      public const int BRICK_WIDTH = 50;

      // The height of a single brick.
      public const int BRICK_HEIGHT = 15;

      // The level a brick must be to be destroyed.
      public const int BRICK_DESTRUCTION_LEVEL = 0;

      // The level when a new game starts.
      public const int NEW_GAME_LEVEL = 1;

      // String for the level folders when loading a level.
      public const string LEVELS_FOLDER = "../../Levels/Level";

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

      // The final level of the game.
      public const int FINAL_LEVEL = 3;

      // The initial amount of lives the player has at the beginning of a new game.
      public const int INITIAL_LIVES_REMAINING = 3;

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
