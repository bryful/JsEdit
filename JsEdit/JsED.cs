using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms.Integration;
using ICSharpCode.AvalonEdit;
using Microsoft.ClearScript;
using Microsoft.ClearScript.V8;
using Microsoft.ClearScript.JavaScript;

namespace JsEdit
{
	public partial class JsED : Control
	{
		// *********************************************************************
		private TextBox? m_TextBox = null;
		[Category("Editor"), ScriptUsage(ScriptAccess.None)]
		public TextBox? TextBox
		{
			get { return m_TextBox; }
			set { m_TextBox = value; }
		}
		private Button? m_ExecButton = null;
		[Category("Editor"),ScriptUsage(ScriptAccess.None)]
		public Button? ExecButton
		{
			get { return m_ExecButton; }
			set 
			{
				m_ExecButton = value; 
				if(m_ExecButton!=null)
				{
					m_ExecButton.Click += (sender, e) =>
					{
						Execute();
					};
				}
			}
		}
		[ScriptUsage(ScriptAccess.None),Browsable(false)]
		private OutputConsole? Output { get; set; } = null;
		[ScriptUsage(ScriptAccess.None)]
		public V8ScriptEngine? engine = null;
		[ScriptUsage(ScriptAccess.None)]
		private ElementHost Element = new ElementHost();
		public TextEditor Editor = new TextEditor();
		// *********************************************************************
		private Font m_ConsoleFont = new Font("System",12);
		[Category("Editor"), ScriptUsage(ScriptAccess.None)]
		public Font ConsoleFont
		{
			get { return m_ConsoleFont; }
			set { m_ConsoleFont = value; }
		}
		// *********************************************************************
		[Category("Editor"), ScriptUsage(ScriptAccess.None)]
		public new Font Font
		{
			get
			{
				Font f = new Font(
					new FontFamily(Editor.FontFamily.Source),
					(float)Editor.FontSize
					);
				return f;
			}
			set
			{
				base.Font = value;
				Element.Font = value;
				Editor.FontFamily = new System.Windows.Media.FontFamily(value.Name);
				Editor.FontSize = (double)value.Size;
			}
		}
		[Category("Editor")]
		public bool ShowLineNumbers
		{
			get { return Editor.ShowLineNumbers; }
			set { Editor.ShowLineNumbers = value; }
		}
		[Category("Editor")]
		public new System.Windows.Thickness Margin
		{
			get { return Editor.Margin; }
			set { Editor.Margin = value; }
		}

		[Category("Editor")]
		public System.Windows.FontStretch FontStretch
		{
			get { return Editor.FontStretch; }
			//set { textEditor.FontStretch = value; }
		}
		[Category("Editor")]
		public System.Windows.FontStyle FontStyle
		{
			get { return Editor.FontStyle; }
			set { Editor.FontStyle = value; }
		}
		[Category("Editor")]
		public System.Windows.FontWeight FontWeight
		{
			get { return Editor.FontWeight; }
			set { Editor.FontWeight = value; }
		}
		[Category("EditorOptions"), ScriptUsage(ScriptAccess.None)]
		public new string Text
		{
			get { return Editor.Text; }
			set { Editor.Text = value; }
		}
		[Category("EditorOptions")]
		public bool AllowScrollBelowDocument
		{
			get { return Editor.Options.AllowScrollBelowDocument; }
			set { Editor.Options.AllowScrollBelowDocument = value; }
		}
		//ColumnRulerPosition 
		[Category("EditorOptions")]
		public int ColumnRulerPosition
		{
			get { return Editor.Options.ColumnRulerPosition; }
			set { Editor.Options.ColumnRulerPosition = value; }
		}
		[Category("EditorOptions")]
		public bool HighlightCurrentLine
		{
			get { return Editor.Options.HighlightCurrentLine; }
			set { Editor.Options.HighlightCurrentLine = value; }
		}
		[Category("EditorOptions")]
		public bool ShowColumnRuler
		{
			get { return Editor.Options.ShowColumnRuler; }
			set { Editor.Options.ShowColumnRuler = value; }
		}
		[Category("EditorOptions")]
		public bool ConvertTabsToSpaces
		{
			get { return Editor.Options.ConvertTabsToSpaces; }
			set { Editor.Options.ConvertTabsToSpaces = value; }
		}
		[Category("EditorOptions")]
		public bool ShowEndOfLine
		{
			get { return Editor.Options.ShowEndOfLine; }
			set { Editor.Options.ShowEndOfLine = value; }
		}
		[Category("EditorOptions")]
		public bool ShowSpaces
		{
			get { return Editor.Options.ShowSpaces; }
			set { Editor.Options.ShowSpaces = value; }
		}
		[Category("EditorOptions")]
		public bool ShowTabs
		{
			get { return Editor.Options.ShowTabs; }
			set { Editor.Options.ShowTabs = value; }
		}
		[Category("Editor")]
		public string StartupCode { get; set; } = "";
		// *********************************************************************
		public JsED()
		{
			this.Name = nameof(TextEditor);
			this.Size = new Size(400, 410);
			Element.Name = "ElementHost";
			Element.Size = this.Size;
			Element.Location = new Point(0, 0);
			Element.Child = Editor;
			Element.Dock = DockStyle.Fill;
			this.Controls.Add(Element);
			InitializeComponent();
			InitEngine();
			//textEditor.FontWeight
			Editor.KeyDown += (sender, e) =>
			{
				if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
				{
					if (e.Key == System.Windows.Input.Key.E)
					{
						Execute();
					}else if (e.Key == System.Windows.Input.Key.R)
					{
						Evaluate();
					}
				}
			};
		}
		// *********************************************************************
		[ScriptUsage(ScriptAccess.None)]
		public void InitEngine()
		{
			if (engine != null) engine.Dispose();
			engine = new V8ScriptEngine();
			engine.AddHostObject("App", HostItemFlags.GlobalMembers, this);
			if(StartupCode!="")
			{
				engine.Execute(StartupCode);
			}
		}
		// *********************************************************************
		[ScriptUsage(ScriptAccess.None)]
		public void Execute()
		{
			try
			{
				string code = Editor.Text.Trim();
				if (code != "")
				{
					cls();
					if (engine == null) InitEngine();
					if(engine!=null)
						engine.Execute(Editor.Text);
				}
			}
			catch (Exception e)
			{
				writeln(e.ToString());
			}
		}
		[ScriptUsage(ScriptAccess.None)]
		public void Evaluate()
		{
			try
			{
				string code = Editor.Text.Trim();
				if (code != "")
				{
					if (engine == null) InitEngine();
					if (engine != null)
					{
						var result = engine.Evaluate(Editor.Text);
						string a = HUtils.ToStr(result);
						Editor.AppendText("\r\n/*\r\n" + a + "\r\n*/\r\n");
					}
				}
			}
			catch (Exception e)
			{
				Editor.AppendText ("\r\n/*\r\n" + e.ToString() + "\r\n*/\r\n");
			}
		}
		// *********************************************************************
		[ScriptUsage(ScriptAccess.None)]
		private void InitConsole()
		{
			if (Output != null) return;

			Control? fm = null;
			Control ? ret = this.Parent;
			while (ret != null)
			{
				if (ret.Parent == null)
				{
					fm = ret; 
					break;
				}
				ret = ret.Parent;
			}
			Output = new OutputConsole(this);
			Output.ConsoleFont = ConsoleFont;
			Output.Owner = (Form)fm;
			Output.Show();
		}
		// *********************************************************************
		public void write(object? o)
		{
			if (m_TextBox!= null)
			{
				m_TextBox.AppendText(HUtils.ToStr(o));
			}
			if (Output == null) InitConsole();
			if (Output != null)
			{
				Output.AppendText(HUtils.ToStr(o));
			}
		}
		public void writeln(object? o)
		{
			if (m_TextBox != null)
			{
				m_TextBox.AppendText(HUtils.ToStr(o)+"\r\n");
			}
			if (Output == null) InitConsole();
			if (Output != null)
			{
				Output.AppendText(HUtils.ToStr(o) + "\r\n");
			}
		}
		public void cls()
		{
			if (m_TextBox != null)
			{
				m_TextBox.Text = "";
			}
			if (Output != null)
			{
				Output.Cls();
			}
		}
		// *********************************************************************
		public string intToHex(int v)
		{
			return $"{v:X8}";
		}
		// *********************************************************************
		public int? hexToInt(string h)
		{
			try
			{
				return Convert.ToInt32(h,16);

			}
			catch
			{
				return null; 
			}
		}
		// *********************************************************************
		//
		[ScriptUsage(ScriptAccess.None)]
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			Element.Size = this.Size;
		}

	}
	[Flags]
	public enum ExeMode
	{
		None	= 0b000,
		TextBox = 0b001,
		Echo	= 0b010,
		Console	= 0b100,
		TextBoxAndEcho = 0b011
	}
}
