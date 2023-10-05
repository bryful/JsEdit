using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JsEdit
{
	public partial class OutputConsole : Form
	{
		public JsED? jsED = null;
		public OutputConsole(JsED? c)
		{
			jsED = c;
			InitializeComponent();

			clearMenu.Click += (sender, e) => { Cls(); };
			fontMenu.Click += (sender, e) => { FontSetting(); };
		}
		public void AppendText(string s)
		{
			textBox1.AppendText(s);
		}
		public void Cls()
		{
			textBox1.Text = "";
		}
		public void SetText(string s)
		{
			textBox1.Text = s;
		}
		public Font ConsoleFont
		{
			get { return textBox1.Font; }
			set { textBox1.Font = value; }
		}
		public void FontSetting()
		{
			using (FontDialog dlg = new FontDialog())
			{
				dlg.Font = ConsoleFont;
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					ConsoleFont = dlg.Font;
					if (jsED != null)
					{
						jsED.ConsoleFont = this.ConsoleFont;
					}
				}
			}
		}
	}
}
