namespace EldenBingo.UI
{
    partial class LobbyControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            splitContainer1 = new SplitContainer();
            _autoCheckerButton = new Button();
            _lobbyStatusPanel = new Panel();
            _scoreboardControl = new ScoreboardControl();
            _logBoxBorderPanel = new Panel();
            _logTextBox = new RichTextBoxCustom();
            _chatTextBox = new TextBox();
            _timerLabel = new Label();
            _matchStatusLabel = new Label();
            _bingoBoardPanel = new Panel();
            _bingoControl = new BingoControl();
            adminControl1 = new AdminControl();
            _clientList = new ClientListControl();
            _adminInfoLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            _lobbyStatusPanel.SuspendLayout();
            _logBoxBorderPanel.SuspendLayout();
            _bingoBoardPanel.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.FixedPanel = FixedPanel.Panel2;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Margin = new Padding(4);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(_autoCheckerButton);
            splitContainer1.Panel1.Controls.Add(_lobbyStatusPanel);
            splitContainer1.Panel1.Controls.Add(_bingoBoardPanel);
            splitContainer1.Panel1.Controls.Add(adminControl1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(_clientList);
            splitContainer1.Panel2.Controls.Add(_adminInfoLabel);
            splitContainer1.Panel2MinSize = 80;
            splitContainer1.Size = new Size(1319, 709);
            splitContainer1.SplitterDistance = 1110;
            splitContainer1.SplitterWidth = 5;
            splitContainer1.TabIndex = 0;
            // 
            // _autoCheckerButton
            // 
            _autoCheckerButton.Location = new Point(151, 534);
            _autoCheckerButton.Name = "_autoCheckerButton";
            _autoCheckerButton.Size = new Size(156, 38);
            _autoCheckerButton.TabIndex = 0;
            _autoCheckerButton.Text = "Start AutoCheck";
            _autoCheckerButton.UseVisualStyleBackColor = true;
            // 
            // _lobbyStatusPanel
            // 
            _lobbyStatusPanel.Controls.Add(_scoreboardControl);
            _lobbyStatusPanel.Controls.Add(_logBoxBorderPanel);
            _lobbyStatusPanel.Controls.Add(_timerLabel);
            _lobbyStatusPanel.Controls.Add(_matchStatusLabel);
            _lobbyStatusPanel.Dock = DockStyle.Fill;
            _lobbyStatusPanel.Location = new Point(726, 0);
            _lobbyStatusPanel.Margin = new Padding(4);
            _lobbyStatusPanel.Name = "_lobbyStatusPanel";
            _lobbyStatusPanel.Size = new Size(384, 527);
            _lobbyStatusPanel.TabIndex = 2;
            // 
            // _scoreboardControl
            // 
            _scoreboardControl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _scoreboardControl.Client = null;
            _scoreboardControl.Location = new Point(21, 122);
            _scoreboardControl.Margin = new Padding(4);
            _scoreboardControl.Name = "_scoreboardControl";
            _scoreboardControl.Size = new Size(318, 0);
            _scoreboardControl.TabIndex = 10;
            _scoreboardControl.SizeChanged += _scoreboardControl_SizeChanged;
            // 
            // _logBoxBorderPanel
            // 
            _logBoxBorderPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            _logBoxBorderPanel.BackColor = Color.FromArgb(118, 110, 97);
            _logBoxBorderPanel.BorderStyle = BorderStyle.FixedSingle;
            _logBoxBorderPanel.Controls.Add(_logTextBox);
            _logBoxBorderPanel.Controls.Add(_chatTextBox);
            _logBoxBorderPanel.Location = new Point(6, 130);
            _logBoxBorderPanel.Margin = new Padding(4);
            _logBoxBorderPanel.Name = "_logBoxBorderPanel";
            _logBoxBorderPanel.Padding = new Padding(1);
            _logBoxBorderPanel.Size = new Size(323, 395);
            _logBoxBorderPanel.TabIndex = 9;
            // 
            // _logTextBox
            // 
            _logTextBox.BackColor = Color.FromArgb(20, 20, 20);
            _logTextBox.BorderColor = SystemColors.WindowFrame;
            _logTextBox.BorderStyle = BorderStyle.None;
            _logTextBox.Dock = DockStyle.Fill;
            _logTextBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            _logTextBox.ForeColor = Color.White;
            _logTextBox.Location = new Point(1, 1);
            _logTextBox.Margin = new Padding(4);
            _logTextBox.MustHideCaret = true;
            _logTextBox.Name = "_logTextBox";
            _logTextBox.ReadOnly = true;
            _logTextBox.ScrollBars = RichTextBoxScrollBars.Vertical;
            _logTextBox.Size = new Size(319, 371);
            _logTextBox.TabIndex = 8;
            _logTextBox.TabStop = false;
            _logTextBox.Text = "";
            _logTextBox.LinkClicked += _logTextBox_LinkClicked;
            // 
            // _chatTextBox
            // 
            _chatTextBox.BackColor = Color.FromArgb(35, 35, 35);
            _chatTextBox.BorderStyle = BorderStyle.None;
            _chatTextBox.Dock = DockStyle.Bottom;
            _chatTextBox.ForeColor = Color.White;
            _chatTextBox.Location = new Point(1, 372);
            _chatTextBox.Margin = new Padding(0);
            _chatTextBox.MaxLength = 327670;
            _chatTextBox.Name = "_chatTextBox";
            _chatTextBox.PlaceholderText = "Send a message";
            _chatTextBox.Size = new Size(319, 20);
            _chatTextBox.TabIndex = 9;
            _chatTextBox.KeyPress += _chatTextBox_KeyPress;
            // 
            // _timerLabel
            // 
            _timerLabel.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point);
            _timerLabel.ForeColor = Color.White;
            _timerLabel.Location = new Point(8, 38);
            _timerLabel.Margin = new Padding(4, 0, 4, 0);
            _timerLabel.Name = "_timerLabel";
            _timerLabel.Size = new Size(304, 66);
            _timerLabel.TabIndex = 6;
            _timerLabel.Text = "00:00:00";
            _timerLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // _matchStatusLabel
            // 
            _matchStatusLabel.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            _matchStatusLabel.ForeColor = Color.White;
            _matchStatusLabel.Location = new Point(4, 5);
            _matchStatusLabel.Margin = new Padding(4, 0, 4, 0);
            _matchStatusLabel.Name = "_matchStatusLabel";
            _matchStatusLabel.Size = new Size(330, 29);
            _matchStatusLabel.TabIndex = 7;
            _matchStatusLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // _bingoBoardPanel
            // 
            _bingoBoardPanel.Controls.Add(_bingoControl);
            _bingoBoardPanel.Dock = DockStyle.Left;
            _bingoBoardPanel.Location = new Point(0, 0);
            _bingoBoardPanel.Margin = new Padding(4);
            _bingoBoardPanel.Name = "_bingoBoardPanel";
            _bingoBoardPanel.Size = new Size(726, 527);
            _bingoBoardPanel.TabIndex = 1;
            // 
            // _bingoControl
            // 
            _bingoControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _bingoControl.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            _bingoControl.Client = null;
            _bingoControl.Location = new Point(6, 6);
            _bingoControl.Margin = new Padding(5);
            _bingoControl.Name = "_bingoControl";
            _bingoControl.Size = new Size(241, 191);
            _bingoControl.TabIndex = 0;
            // 
            // adminControl1
            // 
            adminControl1.Client = null;
            adminControl1.Dock = DockStyle.Bottom;
            adminControl1.Location = new Point(0, 527);
            adminControl1.Margin = new Padding(5);
            adminControl1.Name = "adminControl1";
            adminControl1.Size = new Size(1110, 182);
            adminControl1.TabIndex = 4;
            // 
            // _clientList
            // 
            _clientList.BorderStyle = BorderStyle.FixedSingle;
            _clientList.Client = null;
            _clientList.Dock = DockStyle.Fill;
            _clientList.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            _clientList.Location = new Point(0, 0);
            _clientList.Margin = new Padding(5);
            _clientList.Name = "_clientList";
            _clientList.Size = new Size(204, 628);
            _clientList.TabIndex = 3;
            // 
            // _adminInfoLabel
            // 
            _adminInfoLabel.BackColor = SystemColors.Info;
            _adminInfoLabel.Dock = DockStyle.Bottom;
            _adminInfoLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            _adminInfoLabel.Location = new Point(0, 628);
            _adminInfoLabel.Margin = new Padding(4, 0, 4, 0);
            _adminInfoLabel.Name = "_adminInfoLabel";
            _adminInfoLabel.Size = new Size(204, 81);
            _adminInfoLabel.TabIndex = 4;
            _adminInfoLabel.Text = "AdminSpectator Info: Check/count actions are made on behalf of selection's team";
            _adminInfoLabel.Visible = false;
            // 
            // LobbyControl
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            Controls.Add(splitContainer1);
            Margin = new Padding(4);
            Name = "LobbyControl";
            Size = new Size(1319, 709);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            _lobbyStatusPanel.ResumeLayout(false);
            _logBoxBorderPanel.ResumeLayout(false);
            _logBoxBorderPanel.PerformLayout();
            _bingoBoardPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private ClientListControl _clientList;
        private Panel _lobbyStatusPanel;
        private Panel _bingoBoardPanel;
        private Label _timerLabel;
        private Label _matchStatusLabel;
        private AdminControl adminControl1;
        private BingoControl _bingoControl;
        private RichTextBoxCustom _logTextBox;
        private Panel _logBoxBorderPanel;
        private Label _adminInfoLabel;
        private ScoreboardControl _scoreboardControl;
        private TextBox _chatTextBox;
        private System.Windows.Forms.Button _autoCheckerButton;
    }
}
