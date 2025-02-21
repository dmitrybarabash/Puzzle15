namespace Puzzle15.WinForms.Mvp.Views
{
    partial class PuzzleForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PuzzleForm));
            buttonAbout = new System.Windows.Forms.Button();
            buttonExit = new System.Windows.Forms.Button();
            tableLayoutPanelCellButtons = new System.Windows.Forms.TableLayoutPanel();
            buttonCell16 = new System.Windows.Forms.Button();
            buttonCell15 = new System.Windows.Forms.Button();
            buttonCell14 = new System.Windows.Forms.Button();
            buttonCell13 = new System.Windows.Forms.Button();
            buttonCell12 = new System.Windows.Forms.Button();
            buttonCell11 = new System.Windows.Forms.Button();
            buttonCell10 = new System.Windows.Forms.Button();
            buttonCell9 = new System.Windows.Forms.Button();
            buttonCell8 = new System.Windows.Forms.Button();
            buttonCell7 = new System.Windows.Forms.Button();
            buttonCell5 = new System.Windows.Forms.Button();
            buttonCell4 = new System.Windows.Forms.Button();
            buttonCell3 = new System.Windows.Forms.Button();
            buttonCell2 = new System.Windows.Forms.Button();
            buttonCell1 = new System.Windows.Forms.Button();
            buttonCell6 = new System.Windows.Forms.Button();
            groupBoxTime = new System.Windows.Forms.GroupBox();
            labelTimer = new System.Windows.Forms.Label();
            groupBoxMoves = new System.Windows.Forms.GroupBox();
            labelMoves = new System.Windows.Forms.Label();
            buttonNewGame = new System.Windows.Forms.Button();
            timerGame = new System.Windows.Forms.Timer(components);
            mainMenuStrip = new System.Windows.Forms.MenuStrip();
            fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            fileBestScoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            fileSeparatorToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            fileExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            gameNewGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            helpAboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            tableLayoutPanelCellButtons.SuspendLayout();
            groupBoxTime.SuspendLayout();
            groupBoxMoves.SuspendLayout();
            mainMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // buttonAbout
            // 
            buttonAbout.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            buttonAbout.Location = new System.Drawing.Point(408, 303);
            buttonAbout.Name = "buttonAbout";
            buttonAbout.Size = new System.Drawing.Size(119, 38);
            buttonAbout.TabIndex = 17;
            buttonAbout.Text = "О программе...";
            buttonAbout.UseVisualStyleBackColor = true;
            buttonAbout.Click += AboutHandler;
            // 
            // buttonExit
            // 
            buttonExit.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            buttonExit.Location = new System.Drawing.Point(408, 350);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new System.Drawing.Size(119, 38);
            buttonExit.TabIndex = 18;
            buttonExit.Text = "Выход";
            buttonExit.UseVisualStyleBackColor = true;
            buttonExit.Click += ExitHandler;
            // 
            // tableLayoutPanelCellButtons
            // 
            tableLayoutPanelCellButtons.ColumnCount = 4;
            tableLayoutPanelCellButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanelCellButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanelCellButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanelCellButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanelCellButtons.Controls.Add(buttonCell16, 3, 3);
            tableLayoutPanelCellButtons.Controls.Add(buttonCell15, 2, 3);
            tableLayoutPanelCellButtons.Controls.Add(buttonCell14, 1, 3);
            tableLayoutPanelCellButtons.Controls.Add(buttonCell13, 0, 3);
            tableLayoutPanelCellButtons.Controls.Add(buttonCell12, 3, 2);
            tableLayoutPanelCellButtons.Controls.Add(buttonCell11, 2, 2);
            tableLayoutPanelCellButtons.Controls.Add(buttonCell10, 1, 2);
            tableLayoutPanelCellButtons.Controls.Add(buttonCell9, 0, 2);
            tableLayoutPanelCellButtons.Controls.Add(buttonCell8, 3, 1);
            tableLayoutPanelCellButtons.Controls.Add(buttonCell7, 2, 1);
            tableLayoutPanelCellButtons.Controls.Add(buttonCell5, 0, 1);
            tableLayoutPanelCellButtons.Controls.Add(buttonCell4, 3, 0);
            tableLayoutPanelCellButtons.Controls.Add(buttonCell3, 2, 0);
            tableLayoutPanelCellButtons.Controls.Add(buttonCell2, 1, 0);
            tableLayoutPanelCellButtons.Controls.Add(buttonCell1, 0, 0);
            tableLayoutPanelCellButtons.Controls.Add(buttonCell6, 1, 1);
            tableLayoutPanelCellButtons.Location = new System.Drawing.Point(25, 46);
            tableLayoutPanelCellButtons.Name = "tableLayoutPanelCellButtons";
            tableLayoutPanelCellButtons.RowCount = 4;
            tableLayoutPanelCellButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanelCellButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanelCellButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanelCellButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanelCellButtons.Size = new System.Drawing.Size(359, 342);
            tableLayoutPanelCellButtons.TabIndex = 1;
            // 
            // buttonCell16
            // 
            buttonCell16.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            buttonCell16.AutoSize = true;
            buttonCell16.Enabled = false;
            buttonCell16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
            buttonCell16.Location = new System.Drawing.Point(270, 258);
            buttonCell16.Name = "buttonCell16";
            buttonCell16.Size = new System.Drawing.Size(86, 81);
            buttonCell16.TabIndex = 15;
            buttonCell16.TabStop = false;
            buttonCell16.UseVisualStyleBackColor = true;
            buttonCell16.Visible = false;
            buttonCell16.Click += buttonCell_Click;
            // 
            // buttonCell15
            // 
            buttonCell15.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            buttonCell15.AutoSize = true;
            buttonCell15.Enabled = false;
            buttonCell15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
            buttonCell15.Location = new System.Drawing.Point(181, 258);
            buttonCell15.Name = "buttonCell15";
            buttonCell15.Size = new System.Drawing.Size(83, 81);
            buttonCell15.TabIndex = 14;
            buttonCell15.TabStop = false;
            buttonCell15.Text = "15";
            buttonCell15.UseVisualStyleBackColor = true;
            buttonCell15.Click += buttonCell_Click;
            // 
            // buttonCell14
            // 
            buttonCell14.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            buttonCell14.AutoSize = true;
            buttonCell14.Enabled = false;
            buttonCell14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
            buttonCell14.Location = new System.Drawing.Point(92, 258);
            buttonCell14.Name = "buttonCell14";
            buttonCell14.Size = new System.Drawing.Size(83, 81);
            buttonCell14.TabIndex = 13;
            buttonCell14.TabStop = false;
            buttonCell14.Text = "14";
            buttonCell14.UseVisualStyleBackColor = true;
            buttonCell14.Click += buttonCell_Click;
            // 
            // buttonCell13
            // 
            buttonCell13.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            buttonCell13.AutoSize = true;
            buttonCell13.Enabled = false;
            buttonCell13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
            buttonCell13.Location = new System.Drawing.Point(3, 258);
            buttonCell13.Name = "buttonCell13";
            buttonCell13.Size = new System.Drawing.Size(83, 81);
            buttonCell13.TabIndex = 12;
            buttonCell13.TabStop = false;
            buttonCell13.Text = "13";
            buttonCell13.UseVisualStyleBackColor = true;
            buttonCell13.Click += buttonCell_Click;
            // 
            // buttonCell12
            // 
            buttonCell12.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            buttonCell12.AutoSize = true;
            buttonCell12.Enabled = false;
            buttonCell12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
            buttonCell12.Location = new System.Drawing.Point(270, 173);
            buttonCell12.Name = "buttonCell12";
            buttonCell12.Size = new System.Drawing.Size(86, 79);
            buttonCell12.TabIndex = 11;
            buttonCell12.TabStop = false;
            buttonCell12.Text = "12";
            buttonCell12.UseVisualStyleBackColor = true;
            buttonCell12.Click += buttonCell_Click;
            // 
            // buttonCell11
            // 
            buttonCell11.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            buttonCell11.AutoSize = true;
            buttonCell11.Enabled = false;
            buttonCell11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
            buttonCell11.Location = new System.Drawing.Point(181, 173);
            buttonCell11.Name = "buttonCell11";
            buttonCell11.Size = new System.Drawing.Size(83, 79);
            buttonCell11.TabIndex = 10;
            buttonCell11.TabStop = false;
            buttonCell11.Text = "11";
            buttonCell11.UseVisualStyleBackColor = true;
            buttonCell11.Click += buttonCell_Click;
            // 
            // buttonCell10
            // 
            buttonCell10.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            buttonCell10.AutoSize = true;
            buttonCell10.Enabled = false;
            buttonCell10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
            buttonCell10.Location = new System.Drawing.Point(92, 173);
            buttonCell10.Name = "buttonCell10";
            buttonCell10.Size = new System.Drawing.Size(83, 79);
            buttonCell10.TabIndex = 9;
            buttonCell10.TabStop = false;
            buttonCell10.Text = "10";
            buttonCell10.UseVisualStyleBackColor = true;
            buttonCell10.Click += buttonCell_Click;
            // 
            // buttonCell9
            // 
            buttonCell9.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            buttonCell9.AutoSize = true;
            buttonCell9.Enabled = false;
            buttonCell9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
            buttonCell9.Location = new System.Drawing.Point(3, 173);
            buttonCell9.Name = "buttonCell9";
            buttonCell9.Size = new System.Drawing.Size(83, 79);
            buttonCell9.TabIndex = 8;
            buttonCell9.TabStop = false;
            buttonCell9.Text = "9";
            buttonCell9.UseVisualStyleBackColor = true;
            buttonCell9.Click += buttonCell_Click;
            // 
            // buttonCell8
            // 
            buttonCell8.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            buttonCell8.AutoSize = true;
            buttonCell8.Enabled = false;
            buttonCell8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
            buttonCell8.Location = new System.Drawing.Point(270, 88);
            buttonCell8.Name = "buttonCell8";
            buttonCell8.Size = new System.Drawing.Size(86, 79);
            buttonCell8.TabIndex = 7;
            buttonCell8.TabStop = false;
            buttonCell8.Text = "8";
            buttonCell8.UseVisualStyleBackColor = true;
            buttonCell8.Click += buttonCell_Click;
            // 
            // buttonCell7
            // 
            buttonCell7.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            buttonCell7.AutoSize = true;
            buttonCell7.Enabled = false;
            buttonCell7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
            buttonCell7.Location = new System.Drawing.Point(181, 88);
            buttonCell7.Name = "buttonCell7";
            buttonCell7.Size = new System.Drawing.Size(83, 79);
            buttonCell7.TabIndex = 6;
            buttonCell7.TabStop = false;
            buttonCell7.Text = "7";
            buttonCell7.UseVisualStyleBackColor = true;
            buttonCell7.Click += buttonCell_Click;
            // 
            // buttonCell5
            // 
            buttonCell5.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            buttonCell5.AutoSize = true;
            buttonCell5.Enabled = false;
            buttonCell5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
            buttonCell5.Location = new System.Drawing.Point(3, 88);
            buttonCell5.Name = "buttonCell5";
            buttonCell5.Size = new System.Drawing.Size(83, 79);
            buttonCell5.TabIndex = 4;
            buttonCell5.TabStop = false;
            buttonCell5.Text = "5";
            buttonCell5.UseVisualStyleBackColor = true;
            buttonCell5.Click += buttonCell_Click;
            // 
            // buttonCell4
            // 
            buttonCell4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            buttonCell4.AutoSize = true;
            buttonCell4.Enabled = false;
            buttonCell4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
            buttonCell4.Location = new System.Drawing.Point(270, 3);
            buttonCell4.Name = "buttonCell4";
            buttonCell4.Size = new System.Drawing.Size(86, 79);
            buttonCell4.TabIndex = 3;
            buttonCell4.TabStop = false;
            buttonCell4.Text = "4";
            buttonCell4.UseVisualStyleBackColor = true;
            buttonCell4.Click += buttonCell_Click;
            // 
            // buttonCell3
            // 
            buttonCell3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            buttonCell3.AutoSize = true;
            buttonCell3.Enabled = false;
            buttonCell3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
            buttonCell3.Location = new System.Drawing.Point(181, 3);
            buttonCell3.Name = "buttonCell3";
            buttonCell3.Size = new System.Drawing.Size(83, 79);
            buttonCell3.TabIndex = 2;
            buttonCell3.TabStop = false;
            buttonCell3.Text = "3";
            buttonCell3.UseVisualStyleBackColor = true;
            buttonCell3.Click += buttonCell_Click;
            // 
            // buttonCell2
            // 
            buttonCell2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            buttonCell2.AutoSize = true;
            buttonCell2.Enabled = false;
            buttonCell2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
            buttonCell2.Location = new System.Drawing.Point(92, 3);
            buttonCell2.Name = "buttonCell2";
            buttonCell2.Size = new System.Drawing.Size(83, 79);
            buttonCell2.TabIndex = 1;
            buttonCell2.TabStop = false;
            buttonCell2.Text = "2";
            buttonCell2.UseVisualStyleBackColor = true;
            buttonCell2.Click += buttonCell_Click;
            // 
            // buttonCell1
            // 
            buttonCell1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            buttonCell1.AutoSize = true;
            buttonCell1.Enabled = false;
            buttonCell1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
            buttonCell1.Location = new System.Drawing.Point(3, 3);
            buttonCell1.Name = "buttonCell1";
            buttonCell1.Size = new System.Drawing.Size(83, 79);
            buttonCell1.TabIndex = 0;
            buttonCell1.TabStop = false;
            buttonCell1.Text = "1";
            buttonCell1.UseVisualStyleBackColor = true;
            buttonCell1.Click += buttonCell_Click;
            // 
            // buttonCell6
            // 
            buttonCell6.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            buttonCell6.AutoSize = true;
            buttonCell6.Enabled = false;
            buttonCell6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
            buttonCell6.Location = new System.Drawing.Point(92, 88);
            buttonCell6.Name = "buttonCell6";
            buttonCell6.Size = new System.Drawing.Size(83, 79);
            buttonCell6.TabIndex = 5;
            buttonCell6.TabStop = false;
            buttonCell6.Text = "6";
            buttonCell6.UseVisualStyleBackColor = true;
            buttonCell6.Click += buttonCell_Click;
            // 
            // groupBoxTime
            // 
            groupBoxTime.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            groupBoxTime.Controls.Add(labelTimer);
            groupBoxTime.Location = new System.Drawing.Point(408, 46);
            groupBoxTime.Name = "groupBoxTime";
            groupBoxTime.Size = new System.Drawing.Size(119, 65);
            groupBoxTime.TabIndex = 2;
            groupBoxTime.TabStop = false;
            groupBoxTime.Text = "Время:";
            // 
            // labelTimer
            // 
            labelTimer.Enabled = false;
            labelTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
            labelTimer.Location = new System.Drawing.Point(17, 28);
            labelTimer.Name = "labelTimer";
            labelTimer.Size = new System.Drawing.Size(88, 23);
            labelTimer.TabIndex = 0;
            labelTimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBoxMoves
            // 
            groupBoxMoves.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            groupBoxMoves.Controls.Add(labelMoves);
            groupBoxMoves.Location = new System.Drawing.Point(408, 126);
            groupBoxMoves.Name = "groupBoxMoves";
            groupBoxMoves.Size = new System.Drawing.Size(119, 65);
            groupBoxMoves.TabIndex = 2;
            groupBoxMoves.TabStop = false;
            groupBoxMoves.Text = "Ходы:";
            // 
            // labelMoves
            // 
            labelMoves.Enabled = false;
            labelMoves.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
            labelMoves.Location = new System.Drawing.Point(17, 28);
            labelMoves.Name = "labelMoves";
            labelMoves.Size = new System.Drawing.Size(88, 23);
            labelMoves.TabIndex = 0;
            labelMoves.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonNewGame
            // 
            buttonNewGame.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            buttonNewGame.Location = new System.Drawing.Point(408, 209);
            buttonNewGame.Name = "buttonNewGame";
            buttonNewGame.Size = new System.Drawing.Size(119, 38);
            buttonNewGame.TabIndex = 16;
            buttonNewGame.Text = "Новая игра";
            buttonNewGame.UseVisualStyleBackColor = true;
            buttonNewGame.Click += NewGameHandler;
            // 
            // timerGame
            // 
            timerGame.Tick += timerGame_Tick;
            // 
            // mainMenuStrip
            // 
            mainMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fileToolStripMenuItem, gameToolStripMenuItem, helpToolStripMenuItem });
            mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            mainMenuStrip.Name = "mainMenuStrip";
            mainMenuStrip.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            mainMenuStrip.Size = new System.Drawing.Size(553, 28);
            mainMenuStrip.TabIndex = 19;
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { fileBestScoresToolStripMenuItem, fileSeparatorToolStripMenuItem, fileExitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            fileToolStripMenuItem.Text = "&Файл";
            // 
            // fileBestScoresToolStripMenuItem
            // 
            fileBestScoresToolStripMenuItem.Name = "fileBestScoresToolStripMenuItem";
            fileBestScoresToolStripMenuItem.Size = new System.Drawing.Size(228, 26);
            fileBestScoresToolStripMenuItem.Text = "&Лучшие результаты";
            fileBestScoresToolStripMenuItem.Click += BestScoresHandler;
            // 
            // fileSeparatorToolStripMenuItem
            // 
            fileSeparatorToolStripMenuItem.Name = "fileSeparatorToolStripMenuItem";
            fileSeparatorToolStripMenuItem.Size = new System.Drawing.Size(225, 6);
            // 
            // fileExitToolStripMenuItem
            // 
            fileExitToolStripMenuItem.Name = "fileExitToolStripMenuItem";
            fileExitToolStripMenuItem.Size = new System.Drawing.Size(228, 26);
            fileExitToolStripMenuItem.Text = "&Выход";
            fileExitToolStripMenuItem.Click += ExitHandler;
            // 
            // gameToolStripMenuItem
            // 
            gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { gameNewGameToolStripMenuItem });
            gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            gameToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
            gameToolStripMenuItem.Text = "&Игра";
            // 
            // gameNewGameToolStripMenuItem
            // 
            gameNewGameToolStripMenuItem.Name = "gameNewGameToolStripMenuItem";
            gameNewGameToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N;
            gameNewGameToolStripMenuItem.Size = new System.Drawing.Size(225, 26);
            gameNewGameToolStripMenuItem.Text = "&Новая игра";
            gameNewGameToolStripMenuItem.Click += NewGameHandler;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { helpAboutToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new System.Drawing.Size(30, 24);
            helpToolStripMenuItem.Text = "&?";
            // 
            // helpAboutToolStripMenuItem
            // 
            helpAboutToolStripMenuItem.Name = "helpAboutToolStripMenuItem";
            helpAboutToolStripMenuItem.Size = new System.Drawing.Size(196, 26);
            helpAboutToolStripMenuItem.Text = "О &программе...";
            helpAboutToolStripMenuItem.Click += AboutHandler;
            // 
            // PuzzleForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(553, 410);
            Controls.Add(groupBoxMoves);
            Controls.Add(groupBoxTime);
            Controls.Add(tableLayoutPanelCellButtons);
            Controls.Add(buttonNewGame);
            Controls.Add(buttonExit);
            Controls.Add(buttonAbout);
            Controls.Add(mainMenuStrip);
            Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "PuzzleForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Пятнашки";
            tableLayoutPanelCellButtons.ResumeLayout(false);
            tableLayoutPanelCellButtons.PerformLayout();
            groupBoxTime.ResumeLayout(false);
            groupBoxMoves.ResumeLayout(false);
            mainMenuStrip.ResumeLayout(false);
            mainMenuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAbout;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelCellButtons;
        private System.Windows.Forms.Button buttonCell16;
        private System.Windows.Forms.Button buttonCell15;
        private System.Windows.Forms.Button buttonCell14;
        private System.Windows.Forms.Button buttonCell13;
        private System.Windows.Forms.Button buttonCell12;
        private System.Windows.Forms.Button buttonCell11;
        private System.Windows.Forms.Button buttonCell10;
        private System.Windows.Forms.Button buttonCell9;
        private System.Windows.Forms.Button buttonCell8;
        private System.Windows.Forms.Button buttonCell7;
        private System.Windows.Forms.Button buttonCell6;
        private System.Windows.Forms.Button buttonCell5;
        private System.Windows.Forms.Button buttonCell4;
        private System.Windows.Forms.Button buttonCell3;
        private System.Windows.Forms.Button buttonCell2;
        private System.Windows.Forms.Button buttonCell1;
        private System.Windows.Forms.GroupBox groupBoxTime;
        private System.Windows.Forms.Label labelTimer;
        private System.Windows.Forms.GroupBox groupBoxMoves;
        private System.Windows.Forms.Label labelMoves;
        private System.Windows.Forms.Button buttonNewGame;
        private System.Windows.Forms.Timer timerGame;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gameNewGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpAboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileBestScoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator fileSeparatorToolStripMenuItem;
    }
}

