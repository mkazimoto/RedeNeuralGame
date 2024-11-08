namespace RedeNeuralGame
{
  partial class FormMain
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
      this.pictureBoxOutput = new System.Windows.Forms.PictureBox();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOutput)).BeginInit();
      this.SuspendLayout();
      // 
      // pictureBoxOutput
      // 
      this.pictureBoxOutput.BackColor = System.Drawing.Color.Black;
      this.pictureBoxOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.pictureBoxOutput.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pictureBoxOutput.Location = new System.Drawing.Point(10, 10);
      this.pictureBoxOutput.Name = "pictureBoxOutput";
      this.pictureBoxOutput.Size = new System.Drawing.Size(521, 371);
      this.pictureBoxOutput.TabIndex = 0;
      this.pictureBoxOutput.TabStop = false;
      this.pictureBoxOutput.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxOutput_Paint);
      // 
      // FormMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(541, 391);
      this.Controls.Add(this.pictureBoxOutput);
      this.Name = "FormMain";
      this.Padding = new System.Windows.Forms.Padding(10);
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Rede Neural";
      this.Load += new System.EventHandler(this.FormMain_Load);
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyDown);
      this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyUp);
      this.Resize += new System.EventHandler(this.FormMain_Resize);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOutput)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.PictureBox pictureBoxOutput;
  }
}

