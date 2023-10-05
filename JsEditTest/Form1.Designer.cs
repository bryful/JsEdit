namespace JsEditTest
{
	partial class Form1
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
			jsed1 = new JsEdit.JsED();
			button1 = new Button();
			SuspendLayout();
			// 
			// jsed1
			// 
			jsed1.AllowScrollBelowDocument = true;
			jsed1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			jsed1.BackColor = SystemColors.Window;
			jsed1.ColumnRulerPosition = 80;
			jsed1.ConsoleFont = new Font("源ノ角ゴシック JP", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
			jsed1.ConvertTabsToSpaces = false;
			jsed1.ExecButton = button1;
			jsed1.Font = new Font("源ノ角ゴシック Code JP R", 12F, FontStyle.Regular, GraphicsUnit.Point);
			jsed1.FontWeight = System.Windows.FontWeight.FromOpenTypeWeight(400);
			jsed1.HighlightCurrentLine = false;
			jsed1.Location = new Point(12, 12);
			jsed1.Name = "jsed1";
			jsed1.ShowColumnRuler = true;
			jsed1.ShowEndOfLine = true;
			jsed1.ShowLineNumbers = true;
			jsed1.ShowSpaces = true;
			jsed1.ShowTabs = true;
			jsed1.Size = new Size(611, 358);
			jsed1.TabIndex = 0;
			jsed1.TextBox = null;
			// 
			// button1
			// 
			button1.Location = new Point(474, 376);
			button1.Name = "button1";
			button1.Size = new Size(139, 39);
			button1.TabIndex = 2;
			button1.Text = "button1";
			button1.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(635, 427);
			Controls.Add(button1);
			Controls.Add(jsed1);
			Name = "Form1";
			Text = "Form1";
			ResumeLayout(false);
		}

		#endregion

		private JsEdit.JsED jsed1;
		private Button button1;
	}
}