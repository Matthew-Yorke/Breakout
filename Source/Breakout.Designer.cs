﻿namespace Breakout
{
   partial class Breakout
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.SuspendLayout();
         // 
         // Breakout
         // 
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
         this.ClientSize = new System.Drawing.Size(BreakoutConstants.SCREEN_PLAY_AREA_WIDTH,
                                                   BreakoutConstants.SCREEN_PLAY_AREA_HEIGHT + BreakoutConstants.SCREEN_HUD_AREA_HEIGHT);
         this.DoubleBuffered = true;
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
         this.Name = "Breakout";
         this.Text = "Breakout";
         this.Load += new System.EventHandler(this.BreakoutLoad);
         this.ResumeLayout(false);

      }

      #endregion
   }
}
