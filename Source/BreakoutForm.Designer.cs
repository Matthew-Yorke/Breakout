namespace Breakout
{
   partial class BreakoutForm
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
         // BreakoutForm
         // 
         this.ClientSize = new System.Drawing.Size(BreakoutConstants.SCREEN_PLAY_AREA_WIDTH,
                                                   BreakoutConstants.SCREEN_PLAY_AREA_HEIGHT + BreakoutConstants.SCREEN_HUD_AREA_HEIGHT);
         this.DoubleBuffered = true;
         this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
         this.Name = "BreakoutForm";
         this.Text = "Breakout";
         this.Load += new System.EventHandler(this.BreakoutFormLoad);
         this.ResumeLayout(false);

      }

      #endregion
   }
}

