//************************************************************************************************************************************************
//
// File Name: BreakoutConstants.cs
//
// Description:
//  Constants used throughout the breakout game.
//
// Change History:
//  Author               Date           Description
//  Matthew D. Yorke     12/22/2017     Initial set of constants before adding to GitHub to keep as a backup.
//
//************************************************************************************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout
{
   public static class BreakoutConstants
   {
      // The x-coordinate of the left edge of the screen.
      public const int SCREEN_X_COORDINATE_LEFT = 0;

      // The width in pixels of any paddle in the game.
      public const int PADDLE_WIDTH = 200;

      // The height in pixels of any paddle in the game
      public const int PADDLE_HEIGHT = 10;

      // The padding in pixels between a end-zone and any paddle in the game.
      public const int PADDLE_BOUNDARY_PADDING = 20;

      // The speed (number of pixel movement) the paddle in the game can move at.
      public const int PADDLE_SPEED = 10;

      // The width and height in pixels the ball in the game is.
      public const int BALL_WIDTH_AND_HEIGHT = 20;

      // The initial speed of a ball when a match begins.
      public const int BALL_INITIAL_SPEED = 0;

      // The speed of a ball when launched.
      public const int BALL_LAUNCH_SPEED = 2;

      // The speed increase when the ball hits a boundary, paddle, or brick.
      public const int BALL_SPEED_INCREASE = 0;

      // The width of a single brick.
      public const int BRICK_WIDTH = 50;

      // The height of a single brick.
      public const int BRICK_HEIGHT = 15;

      // The level when a new game starts.
      public const int NEW_GAME_LEVEL = 1;

      // String for the level folders when loading a level.
      public const string LEVELS_FOLDER = "../../Levels/Level";

      // String for the text file format when loading a level.
      public const string TEXT_FILE = ".txt";

      // Delimiter used when reading a line in the level text file.
      public const string LEVEL_DELIMITER = ",";

      // String to indicate no brick to be placed when loading a level.
      public const string NO_BRICK = "0";

      // String to indicate a level one brick to be placed when loading a level.
      public const string LEVEL_ONE_BRICK = "1";

      // String to indicate a level two brick to be placed when loading a level.
      public const string LEVEL_TWO_BRICK = "2";

      // String to indicate a level three  brick to be placed when loading a level.
      public const string LEVEL_THREE_BRICK = "3";

      // The number of milliseconds for a clock tick to occur.
      public const int TIMER_INTERVAL = 16;

      // Used for dividing a value in half.
      public const int HALF = 2;
   }
}
