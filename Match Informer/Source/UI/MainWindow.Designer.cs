
namespace MatchInformer.Source.UI
{
    partial class MainWindow
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.footer = new MetroFramework.Controls.MetroTile();
            this.LoadingScreen = new MetroFramework.Controls.MetroPanel();
            this.progressOutput = new MetroFramework.Controls.MetroTile();
            this.progressBar = new MetroFramework.Controls.MetroProgressBar();
            this.MainScreen = new MetroFramework.Controls.MetroPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.toggleRevealRanks = new MetroFramework.Controls.MetroToggle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.playerFilter = new MetroFramework.Controls.MetroTile();
            this.playerFilterForward = new MetroFramework.Controls.MetroTile();
            this.playerFilterBackward = new MetroFramework.Controls.MetroTile();
            this.buttonFetch = new MetroFramework.Controls.MetroTile();
            this.buttonCopy = new MetroFramework.Controls.MetroTile();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.toggleIncludeSteamInfo = new MetroFramework.Controls.MetroToggle();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.toggleIgnoreBots = new MetroFramework.Controls.MetroToggle();
            this.generalOutput = new System.Windows.Forms.TextBox();
            this.LoadingScreen.SuspendLayout();
            this.MainScreen.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // footer
            // 
            resources.ApplyResources(this.footer, "footer");
            this.footer.Name = "footer";
            // 
            // LoadingScreen
            // 
            this.LoadingScreen.BackColor = System.Drawing.Color.Transparent;
            this.LoadingScreen.Controls.Add(this.progressOutput);
            this.LoadingScreen.Controls.Add(this.progressBar);
            this.LoadingScreen.ForeColor = System.Drawing.Color.Transparent;
            this.LoadingScreen.HorizontalScrollbarBarColor = true;
            this.LoadingScreen.HorizontalScrollbarHighlightOnWheel = false;
            this.LoadingScreen.HorizontalScrollbarSize = 11;
            resources.ApplyResources(this.LoadingScreen, "LoadingScreen");
            this.LoadingScreen.Name = "LoadingScreen";
            this.LoadingScreen.VerticalScrollbarBarColor = true;
            this.LoadingScreen.VerticalScrollbarHighlightOnWheel = false;
            this.LoadingScreen.VerticalScrollbarSize = 13;
            // 
            // progressOutput
            // 
            resources.ApplyResources(this.progressOutput, "progressOutput");
            this.progressOutput.Name = "progressOutput";
            this.progressOutput.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBar
            // 
            resources.ApplyResources(this.progressBar, "progressBar");
            this.progressBar.Name = "progressBar";
            this.progressBar.Style = MetroFramework.MetroColorStyle.Red;
            // 
            // MainScreen
            // 
            this.MainScreen.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.MainScreen, "MainScreen");
            this.MainScreen.Controls.Add(this.groupBox2);
            this.MainScreen.Controls.Add(this.groupBox1);
            this.MainScreen.Controls.Add(this.generalOutput);
            this.MainScreen.CustomBackground = true;
            this.MainScreen.ForeColor = System.Drawing.Color.Transparent;
            this.MainScreen.HorizontalScrollbarBarColor = true;
            this.MainScreen.HorizontalScrollbarHighlightOnWheel = false;
            this.MainScreen.HorizontalScrollbarSize = 11;
            this.MainScreen.Name = "MainScreen";
            this.MainScreen.VerticalScrollbarBarColor = true;
            this.MainScreen.VerticalScrollbarHighlightOnWheel = false;
            this.MainScreen.VerticalScrollbarSize = 13;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.metroLabel3);
            this.groupBox2.Controls.Add(this.toggleRevealRanks);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.ForeColor = System.Drawing.Color.DimGray;
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // metroLabel3
            // 
            resources.ApplyResources(this.metroLabel3, "metroLabel3");
            this.metroLabel3.Name = "metroLabel3";
            // 
            // toggleRevealRanks
            // 
            resources.ApplyResources(this.toggleRevealRanks, "toggleRevealRanks");
            this.toggleRevealRanks.Name = "toggleRevealRanks";
            this.toggleRevealRanks.UseVisualStyleBackColor = true;
            this.toggleRevealRanks.CheckedChanged += new System.EventHandler(this.toggleRevealRanks_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.playerFilter);
            this.groupBox1.Controls.Add(this.playerFilterForward);
            this.groupBox1.Controls.Add(this.playerFilterBackward);
            this.groupBox1.Controls.Add(this.buttonFetch);
            this.groupBox1.Controls.Add(this.buttonCopy);
            this.groupBox1.Controls.Add(this.metroLabel2);
            this.groupBox1.Controls.Add(this.toggleIncludeSteamInfo);
            this.groupBox1.Controls.Add(this.metroLabel1);
            this.groupBox1.Controls.Add(this.toggleIgnoreBots);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.ForeColor = System.Drawing.Color.Gray;
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // playerFilter
            // 
            resources.ApplyResources(this.playerFilter, "playerFilter");
            this.playerFilter.Name = "playerFilter";
            this.playerFilter.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            // 
            // playerFilterForward
            // 
            this.playerFilterForward.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.playerFilterForward.CustomBackground = true;
            resources.ApplyResources(this.playerFilterForward, "playerFilterForward");
            this.playerFilterForward.Name = "playerFilterForward";
            this.playerFilterForward.MouseClick += new System.Windows.Forms.MouseEventHandler(this.playerFilterForward_MouseClick);
            // 
            // playerFilterBackward
            // 
            this.playerFilterBackward.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.playerFilterBackward.CustomBackground = true;
            resources.ApplyResources(this.playerFilterBackward, "playerFilterBackward");
            this.playerFilterBackward.Name = "playerFilterBackward";
            this.playerFilterBackward.MouseClick += new System.Windows.Forms.MouseEventHandler(this.playerFilterBackward_MouseClick);
            // 
            // buttonFetch
            // 
            this.buttonFetch.BackColor = System.Drawing.Color.White;
            this.buttonFetch.CustomBackground = true;
            this.buttonFetch.CustomForeColor = true;
            this.buttonFetch.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.buttonFetch, "buttonFetch");
            this.buttonFetch.Name = "buttonFetch";
            this.buttonFetch.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonFetch.UseTileImage = true;
            this.buttonFetch.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonFetch_MouseClick);
            // 
            // buttonCopy
            // 
            this.buttonCopy.BackColor = System.Drawing.Color.White;
            this.buttonCopy.CustomBackground = true;
            this.buttonCopy.CustomForeColor = true;
            this.buttonCopy.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.buttonCopy, "buttonCopy");
            this.buttonCopy.Name = "buttonCopy";
            this.buttonCopy.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttonCopy.UseTileImage = true;
            this.buttonCopy.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonCopy_MouseClick);
            // 
            // metroLabel2
            // 
            resources.ApplyResources(this.metroLabel2, "metroLabel2");
            this.metroLabel2.Name = "metroLabel2";
            // 
            // toggleIncludeSteamInfo
            // 
            resources.ApplyResources(this.toggleIncludeSteamInfo, "toggleIncludeSteamInfo");
            this.toggleIncludeSteamInfo.Checked = true;
            this.toggleIncludeSteamInfo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toggleIncludeSteamInfo.Name = "toggleIncludeSteamInfo";
            this.toggleIncludeSteamInfo.UseVisualStyleBackColor = true;
            // 
            // metroLabel1
            // 
            resources.ApplyResources(this.metroLabel1, "metroLabel1");
            this.metroLabel1.Name = "metroLabel1";
            // 
            // toggleIgnoreBots
            // 
            resources.ApplyResources(this.toggleIgnoreBots, "toggleIgnoreBots");
            this.toggleIgnoreBots.Checked = true;
            this.toggleIgnoreBots.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toggleIgnoreBots.Name = "toggleIgnoreBots";
            this.toggleIgnoreBots.UseVisualStyleBackColor = true;
            // 
            // generalOutput
            // 
            this.generalOutput.BackColor = System.Drawing.Color.White;
            this.generalOutput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.generalOutput, "generalOutput");
            this.generalOutput.Name = "generalOutput";
            this.generalOutput.ReadOnly = true;
            // 
            // MainWindow
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.Controls.Add(this.footer);
            this.Controls.Add(this.LoadingScreen);
            this.Controls.Add(this.MainScreen);
            this.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.Name = "MainWindow";
            this.Resizable = false;
            this.TextAlign = System.Windows.Forms.VisualStyles.HorizontalAlign.Center;
            this.TransparencyKey = System.Drawing.Color.Peru;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainWindow_FormClosed);
            this.Shown += new System.EventHandler(this.MainWindow_Shown);
            this.LoadingScreen.ResumeLayout(false);
            this.MainScreen.ResumeLayout(false);
            this.MainScreen.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroTile footer;
        private MetroFramework.Controls.MetroPanel LoadingScreen;
        private MetroFramework.Controls.MetroPanel MainScreen;
        public MetroFramework.Controls.MetroTile progressOutput;
        public MetroFramework.Controls.MetroProgressBar progressBar;
        private System.Windows.Forms.TextBox generalOutput;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroToggle toggleRevealRanks;
        private MetroFramework.Controls.MetroTile buttonCopy;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroToggle toggleIncludeSteamInfo;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroToggle toggleIgnoreBots;
        private MetroFramework.Controls.MetroTile buttonFetch;
        private MetroFramework.Controls.MetroTile playerFilter;
        private MetroFramework.Controls.MetroTile playerFilterForward;
        private MetroFramework.Controls.MetroTile playerFilterBackward;
    }
}

