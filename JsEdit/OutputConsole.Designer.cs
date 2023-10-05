namespace JsEdit
{
	partial class OutputConsole
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
			menuStrip1 = new MenuStrip();
			editToolStripMenuItem = new ToolStripMenuItem();
			clearMenu = new ToolStripMenuItem();
			fontMenu = new ToolStripMenuItem();
			textBox1 = new TextBox();
			menuStrip1.SuspendLayout();
			SuspendLayout();
			// 
			// menuStrip1
			// 
			menuStrip1.Items.AddRange(new ToolStripItem[] { editToolStripMenuItem });
			menuStrip1.Location = new Point(0, 0);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.Size = new Size(693, 24);
			menuStrip1.TabIndex = 0;
			menuStrip1.Text = "menuStrip1";
			// 
			// editToolStripMenuItem
			// 
			editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { clearMenu, fontMenu });
			editToolStripMenuItem.Name = "editToolStripMenuItem";
			editToolStripMenuItem.Size = new Size(39, 20);
			editToolStripMenuItem.Text = "Edit";
			// 
			// clearMenu
			// 
			clearMenu.Name = "clearMenu";
			clearMenu.Size = new Size(100, 22);
			clearMenu.Text = "Clear";
			// 
			// fontMenu
			// 
			fontMenu.Name = "fontMenu";
			fontMenu.Size = new Size(100, 22);
			fontMenu.Text = "Font";
			// 
			// textBox1
			// 
			textBox1.Dock = DockStyle.Fill;
			textBox1.Location = new Point(0, 24);
			textBox1.Margin = new Padding(5);
			textBox1.Multiline = true;
			textBox1.Name = "textBox1";
			textBox1.ReadOnly = true;
			textBox1.ScrollBars = ScrollBars.Both;
			textBox1.Size = new Size(693, 259);
			textBox1.TabIndex = 1;
			// 
			// OutputConsole
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(693, 283);
			ControlBox = false;
			Controls.Add(textBox1);
			Controls.Add(menuStrip1);
			FormBorderStyle = FormBorderStyle.SizableToolWindow;
			MainMenuStrip = menuStrip1;
			MaximizeBox = false;
			MdiChildrenMinimizedAnchorBottom = false;
			MinimizeBox = false;
			Name = "OutputConsole";
			ShowIcon = false;
			ShowInTaskbar = false;
			Text = "OutputForm";
			menuStrip1.ResumeLayout(false);
			menuStrip1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private MenuStrip menuStrip1;
		private ToolStripMenuItem editToolStripMenuItem;
		private ToolStripMenuItem clearMenu;
		private ToolStripMenuItem fontMenu;
		private TextBox textBox1;
	}
}