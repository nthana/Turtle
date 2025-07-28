namespace ThanaNita.Turtles;

partial class Display
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        SuspendLayout();
        // 
        // Display
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        ClientSize = new Size(828, 944);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Location = new Point(700, 0);
        MaximizeBox = false;
        Name = "Display";
        StartPosition = FormStartPosition.CenterScreen;
        FormClosed += Display_FormClosed;
        Load += Display_Load;
        Paint += Form1_Paint;
        KeyDown += Form1_KeyDown;
        ResumeLayout(false);
    }

    #endregion
}
