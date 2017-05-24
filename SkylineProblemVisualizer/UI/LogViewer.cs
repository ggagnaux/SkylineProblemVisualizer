using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;
using SkylineProblemVisualizer.Interfaces;
using SkylineProblemVisualizer.UI;
using SkylineProblemVisualizer.Utilities;

namespace SkylineProblemVisualizer
{
    public partial class LogViewer : FormBase
    {
        // Use the ListView instead of a TextBox
        private readonly bool UseListView = false;

        public LogViewer(Form parent, IFormController _controller) : base(_controller)
        {
            InitializeComponent();
            Initialize();
        }

        public async override void Initialize()
        {
            LogHelper.LogInfo("Calling LogViewer.Initialize()");
            string[] lines = await LoadLogLines();

            if (UseListView)
            {
                PopulateListView(CreateListView(this.panelContent), lines);
            }
            else
            {
                PopulateTextBox(CreateTextBox(this.panelContent), lines);
            }

            this.DoubleBuffered = true;
            base.Initialize();
        }

        private async Task<string[]> LoadLogLines()
        {
            return await FileEx.ReadAllLinesAsync(LogHelper.LogFileName);
        }

        private MetroListView CreateListView(Panel container)
        {
            container = null;
            if (container == null)
            {
                string msg = "container cannot be null.";
                LogHelper.LogError(msg);
                throw new ArgumentNullException(msg);
            }

            MetroListView lv = new MetroListView();

            lv.Dock = System.Windows.Forms.DockStyle.Fill;
            lv.Font = new System.Drawing.Font("Segoe UI", 12F);
            lv.FullRowSelect = true;
            lv.Location = new System.Drawing.Point(0, 0);
            lv.Name = "listViewLog";
            lv.OwnerDraw = true;
            lv.Size = new System.Drawing.Size(981, 569);
            lv.TabIndex = 2;
            lv.UseCompatibleStateImageBehavior = false;
            lv.UseSelectable = true;
            lv.View = System.Windows.Forms.View.Details;

            container.Controls.Add(lv);

            return lv;
        }

        private MetroTextBox CreateTextBox(Panel container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container cannot be null.");
            }

            MetroTextBox tb = new MetroTextBox();

            tb.CustomButton.Image = null;
            tb.CustomButton.Location = new System.Drawing.Point(413, 1);
            tb.CustomButton.Name = "";
            tb.CustomButton.Size = new System.Drawing.Size(567, 567);
            tb.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            tb.CustomButton.TabIndex = 1;
            tb.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            tb.CustomButton.UseSelectable = true;
            tb.CustomButton.Visible = false;
            tb.Dock = System.Windows.Forms.DockStyle.Fill;
            tb.Lines = new string[] {"metroTextBox1"};
            tb.Location = new System.Drawing.Point(0, 0);
            tb.MaxLength = 1200000;
            tb.Multiline = true;
            tb.Name = "textBoxLog";
            tb.PasswordChar = '\0';
            tb.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            tb.SelectedText = "";
            tb.SelectionLength = 0;
            tb.SelectionStart = 0;
            tb.ShortcutsEnabled = true;
            tb.Size = new System.Drawing.Size(981, 569);
            tb.TabIndex = 0;
            tb.Text = "metroTextBox1";
            tb.UseSelectable = true;
            tb.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            tb.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);

            container.Controls.Add(tb);

            return tb;
        }

        private void PopulateListView(ListView lv, string[] lines)
        {
            if (lv == null)
                throw new ArgumentNullException();

            int columnCount = LogHelper.HeaderMarker.Length;

            // Clear old data and load new data
            lv.Clear();

            // Create the columns
            var listWidth = lv.Width;
            var colWidth = listWidth / columnCount;
            foreach (var item in LogHelper.LoggerColumns)
            {
                lv.Columns.Add(item.Label, colWidth, HorizontalAlignment.Left);
            }

            foreach (var line in lines)
            {
                if (line.Length > 0 && !IsMarker(line))
                {
                    // Split into parts, trim spaces and add to list
                    string[] parts = line.Split('|');
                    if (parts.Length != LogHelper.LoggerColumns.Count())
                        throw new ArgumentOutOfRangeException();

                    List<string> tempList = new List<string>();
                    foreach (var part in parts)
                    {
                        tempList.Add(part);
                    }
                    lv.Items.Add(new ListViewItem(tempList.ToArray()));
                }
            }
        }

        private void PopulateTextBox(MetroTextBox tb, string[] lines)
        {
            if (tb == null)
                throw new ArgumentNullException();

            var sb = new StringBuilder();
            foreach (var line in lines)
            {
                sb.AppendLine(line);                
            }
            tb.Text = sb.ToString();
        }

        private bool IsMarker(string line)
        {
            if (string.IsNullOrEmpty(line))
                throw new ArgumentNullException();

            return IsHeaderMarker(line) || IsFooterMarker(line);
        }

        private bool IsHeaderMarker(string line)
        {
            if (string.IsNullOrEmpty(line))
                throw new ArgumentNullException();

            return line.Substring(0, LogHelper.HeaderMarker.Length) == LogHelper.HeaderMarker;
        }

        private bool IsFooterMarker(string line)
        {
            if (string.IsNullOrEmpty(line))
                throw new ArgumentNullException();

            return line.Substring(0, LogHelper.FooterMarker.Length) == LogHelper.FooterMarker;
        }
    }
}
