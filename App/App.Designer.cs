namespace App
{
	partial class App
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
			ResizeButton = new Button();
			SuspendLayout();
			// 
			// ResizeButton
			// 
			ResizeButton.Anchor = AnchorStyles.None;
			ResizeButton.Location = new Point(366, 255);
			ResizeButton.Name = "ResizeButton";
			ResizeButton.Size = new Size(94, 29);
			ResizeButton.TabIndex = 0;
			ResizeButton.Text = "Resize me";
			ResizeButton.UseVisualStyleBackColor = true;
			// 
			// App
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.FromArgb(51, 51, 51);
			ClientSize = new Size(800, 550);
			Controls.Add(ResizeButton);
			Name = "App";
			Text = "Form1";
			ResumeLayout(false);
		}

		#endregion

		private Button ResizeButton;
	}
}