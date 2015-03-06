namespace Puzzle15
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.buttonAbout = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.tableLayoutPanelCellButtons = new System.Windows.Forms.TableLayoutPanel();
            this.buttonCell16 = new System.Windows.Forms.Button();
            this.buttonCell15 = new System.Windows.Forms.Button();
            this.buttonCell14 = new System.Windows.Forms.Button();
            this.buttonCell13 = new System.Windows.Forms.Button();
            this.buttonCell12 = new System.Windows.Forms.Button();
            this.buttonCell11 = new System.Windows.Forms.Button();
            this.buttonCell10 = new System.Windows.Forms.Button();
            this.buttonCell9 = new System.Windows.Forms.Button();
            this.buttonCell8 = new System.Windows.Forms.Button();
            this.buttonCell7 = new System.Windows.Forms.Button();
            this.buttonCell5 = new System.Windows.Forms.Button();
            this.buttonCell4 = new System.Windows.Forms.Button();
            this.buttonCell3 = new System.Windows.Forms.Button();
            this.buttonCell2 = new System.Windows.Forms.Button();
            this.buttonCell1 = new System.Windows.Forms.Button();
            this.buttonCell6 = new System.Windows.Forms.Button();
            this.groupBoxTime = new System.Windows.Forms.GroupBox();
            this.labelTimer = new System.Windows.Forms.Label();
            this.groupBoxMoves = new System.Windows.Forms.GroupBox();
            this.labelMoves = new System.Windows.Forms.Label();
            this.buttonNewGame = new System.Windows.Forms.Button();
            this.timerGame = new System.Windows.Forms.Timer(this.components);
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gameNewGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpAboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanelCellButtons.SuspendLayout();
            this.groupBoxTime.SuspendLayout();
            this.groupBoxMoves.SuspendLayout();
            this.mainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonAbout
            // 
            this.buttonAbout.Location = new System.Drawing.Point(446, 328);
            this.buttonAbout.Name = "buttonAbout";
            this.buttonAbout.Size = new System.Drawing.Size(136, 38);
            this.buttonAbout.TabIndex = 17;
            this.buttonAbout.Text = "О программе...";
            this.buttonAbout.UseVisualStyleBackColor = true;
            this.buttonAbout.Click += new System.EventHandler(this.AboutHandler);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(446, 383);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(136, 38);
            this.buttonExit.TabIndex = 18;
            this.buttonExit.Text = "Выход";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.ExitHandler);
            // 
            // tableLayoutPanelCellButtons
            // 
            this.tableLayoutPanelCellButtons.ColumnCount = 4;
            this.tableLayoutPanelCellButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelCellButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelCellButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelCellButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelCellButtons.Controls.Add(this.buttonCell16, 3, 3);
            this.tableLayoutPanelCellButtons.Controls.Add(this.buttonCell15, 2, 3);
            this.tableLayoutPanelCellButtons.Controls.Add(this.buttonCell14, 1, 3);
            this.tableLayoutPanelCellButtons.Controls.Add(this.buttonCell13, 0, 3);
            this.tableLayoutPanelCellButtons.Controls.Add(this.buttonCell12, 3, 2);
            this.tableLayoutPanelCellButtons.Controls.Add(this.buttonCell11, 2, 2);
            this.tableLayoutPanelCellButtons.Controls.Add(this.buttonCell10, 1, 2);
            this.tableLayoutPanelCellButtons.Controls.Add(this.buttonCell9, 0, 2);
            this.tableLayoutPanelCellButtons.Controls.Add(this.buttonCell8, 3, 1);
            this.tableLayoutPanelCellButtons.Controls.Add(this.buttonCell7, 2, 1);
            this.tableLayoutPanelCellButtons.Controls.Add(this.buttonCell5, 0, 1);
            this.tableLayoutPanelCellButtons.Controls.Add(this.buttonCell4, 3, 0);
            this.tableLayoutPanelCellButtons.Controls.Add(this.buttonCell3, 2, 0);
            this.tableLayoutPanelCellButtons.Controls.Add(this.buttonCell2, 1, 0);
            this.tableLayoutPanelCellButtons.Controls.Add(this.buttonCell1, 0, 0);
            this.tableLayoutPanelCellButtons.Controls.Add(this.buttonCell6, 1, 1);
            this.tableLayoutPanelCellButtons.Location = new System.Drawing.Point(29, 46);
            this.tableLayoutPanelCellButtons.Name = "tableLayoutPanelCellButtons";
            this.tableLayoutPanelCellButtons.RowCount = 4;
            this.tableLayoutPanelCellButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelCellButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelCellButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelCellButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelCellButtons.Size = new System.Drawing.Size(391, 375);
            this.tableLayoutPanelCellButtons.TabIndex = 1;
            // 
            // buttonCell16
            // 
            this.buttonCell16.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCell16.AutoSize = true;
            this.buttonCell16.Enabled = false;
            this.buttonCell16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCell16.Location = new System.Drawing.Point(294, 282);
            this.buttonCell16.Name = "buttonCell16";
            this.buttonCell16.Size = new System.Drawing.Size(94, 90);
            this.buttonCell16.TabIndex = 15;
            this.buttonCell16.UseVisualStyleBackColor = true;
            this.buttonCell16.Visible = false;
            this.buttonCell16.Click += new System.EventHandler(this.buttonCell_Click);
            // 
            // buttonCell15
            // 
            this.buttonCell15.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCell15.AutoSize = true;
            this.buttonCell15.Enabled = false;
            this.buttonCell15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCell15.Location = new System.Drawing.Point(197, 282);
            this.buttonCell15.Name = "buttonCell15";
            this.buttonCell15.Size = new System.Drawing.Size(91, 90);
            this.buttonCell15.TabIndex = 14;
            this.buttonCell15.Text = "15";
            this.buttonCell15.UseVisualStyleBackColor = true;
            this.buttonCell15.Click += new System.EventHandler(this.buttonCell_Click);
            // 
            // buttonCell14
            // 
            this.buttonCell14.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCell14.AutoSize = true;
            this.buttonCell14.Enabled = false;
            this.buttonCell14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCell14.Location = new System.Drawing.Point(100, 282);
            this.buttonCell14.Name = "buttonCell14";
            this.buttonCell14.Size = new System.Drawing.Size(91, 90);
            this.buttonCell14.TabIndex = 13;
            this.buttonCell14.Text = "14";
            this.buttonCell14.UseVisualStyleBackColor = true;
            this.buttonCell14.Click += new System.EventHandler(this.buttonCell_Click);
            // 
            // buttonCell13
            // 
            this.buttonCell13.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCell13.AutoSize = true;
            this.buttonCell13.Enabled = false;
            this.buttonCell13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCell13.Location = new System.Drawing.Point(3, 282);
            this.buttonCell13.Name = "buttonCell13";
            this.buttonCell13.Size = new System.Drawing.Size(91, 90);
            this.buttonCell13.TabIndex = 12;
            this.buttonCell13.Text = "13";
            this.buttonCell13.UseVisualStyleBackColor = true;
            this.buttonCell13.Click += new System.EventHandler(this.buttonCell_Click);
            // 
            // buttonCell12
            // 
            this.buttonCell12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCell12.AutoSize = true;
            this.buttonCell12.Enabled = false;
            this.buttonCell12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCell12.Location = new System.Drawing.Point(294, 189);
            this.buttonCell12.Name = "buttonCell12";
            this.buttonCell12.Size = new System.Drawing.Size(94, 87);
            this.buttonCell12.TabIndex = 11;
            this.buttonCell12.Text = "12";
            this.buttonCell12.UseVisualStyleBackColor = true;
            this.buttonCell12.Click += new System.EventHandler(this.buttonCell_Click);
            // 
            // buttonCell11
            // 
            this.buttonCell11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCell11.AutoSize = true;
            this.buttonCell11.Enabled = false;
            this.buttonCell11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCell11.Location = new System.Drawing.Point(197, 189);
            this.buttonCell11.Name = "buttonCell11";
            this.buttonCell11.Size = new System.Drawing.Size(91, 87);
            this.buttonCell11.TabIndex = 10;
            this.buttonCell11.Text = "11";
            this.buttonCell11.UseVisualStyleBackColor = true;
            this.buttonCell11.Click += new System.EventHandler(this.buttonCell_Click);
            // 
            // buttonCell10
            // 
            this.buttonCell10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCell10.AutoSize = true;
            this.buttonCell10.Enabled = false;
            this.buttonCell10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCell10.Location = new System.Drawing.Point(100, 189);
            this.buttonCell10.Name = "buttonCell10";
            this.buttonCell10.Size = new System.Drawing.Size(91, 87);
            this.buttonCell10.TabIndex = 9;
            this.buttonCell10.Text = "10";
            this.buttonCell10.UseVisualStyleBackColor = true;
            this.buttonCell10.Click += new System.EventHandler(this.buttonCell_Click);
            // 
            // buttonCell9
            // 
            this.buttonCell9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCell9.AutoSize = true;
            this.buttonCell9.Enabled = false;
            this.buttonCell9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCell9.Location = new System.Drawing.Point(3, 189);
            this.buttonCell9.Name = "buttonCell9";
            this.buttonCell9.Size = new System.Drawing.Size(91, 87);
            this.buttonCell9.TabIndex = 8;
            this.buttonCell9.Text = "9";
            this.buttonCell9.UseVisualStyleBackColor = true;
            this.buttonCell9.Click += new System.EventHandler(this.buttonCell_Click);
            // 
            // buttonCell8
            // 
            this.buttonCell8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCell8.AutoSize = true;
            this.buttonCell8.Enabled = false;
            this.buttonCell8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCell8.Location = new System.Drawing.Point(294, 96);
            this.buttonCell8.Name = "buttonCell8";
            this.buttonCell8.Size = new System.Drawing.Size(94, 87);
            this.buttonCell8.TabIndex = 7;
            this.buttonCell8.Text = "8";
            this.buttonCell8.UseVisualStyleBackColor = true;
            this.buttonCell8.Click += new System.EventHandler(this.buttonCell_Click);
            // 
            // buttonCell7
            // 
            this.buttonCell7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCell7.AutoSize = true;
            this.buttonCell7.Enabled = false;
            this.buttonCell7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCell7.Location = new System.Drawing.Point(197, 96);
            this.buttonCell7.Name = "buttonCell7";
            this.buttonCell7.Size = new System.Drawing.Size(91, 87);
            this.buttonCell7.TabIndex = 6;
            this.buttonCell7.Text = "7";
            this.buttonCell7.UseVisualStyleBackColor = true;
            this.buttonCell7.Click += new System.EventHandler(this.buttonCell_Click);
            // 
            // buttonCell5
            // 
            this.buttonCell5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCell5.AutoSize = true;
            this.buttonCell5.Enabled = false;
            this.buttonCell5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCell5.Location = new System.Drawing.Point(3, 96);
            this.buttonCell5.Name = "buttonCell5";
            this.buttonCell5.Size = new System.Drawing.Size(91, 87);
            this.buttonCell5.TabIndex = 4;
            this.buttonCell5.Text = "5";
            this.buttonCell5.UseVisualStyleBackColor = true;
            this.buttonCell5.Click += new System.EventHandler(this.buttonCell_Click);
            // 
            // buttonCell4
            // 
            this.buttonCell4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCell4.AutoSize = true;
            this.buttonCell4.Enabled = false;
            this.buttonCell4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCell4.Location = new System.Drawing.Point(294, 3);
            this.buttonCell4.Name = "buttonCell4";
            this.buttonCell4.Size = new System.Drawing.Size(94, 87);
            this.buttonCell4.TabIndex = 3;
            this.buttonCell4.Text = "4";
            this.buttonCell4.UseVisualStyleBackColor = true;
            this.buttonCell4.Click += new System.EventHandler(this.buttonCell_Click);
            // 
            // buttonCell3
            // 
            this.buttonCell3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCell3.AutoSize = true;
            this.buttonCell3.Enabled = false;
            this.buttonCell3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCell3.Location = new System.Drawing.Point(197, 3);
            this.buttonCell3.Name = "buttonCell3";
            this.buttonCell3.Size = new System.Drawing.Size(91, 87);
            this.buttonCell3.TabIndex = 2;
            this.buttonCell3.Text = "3";
            this.buttonCell3.UseVisualStyleBackColor = true;
            this.buttonCell3.Click += new System.EventHandler(this.buttonCell_Click);
            // 
            // buttonCell2
            // 
            this.buttonCell2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCell2.AutoSize = true;
            this.buttonCell2.Enabled = false;
            this.buttonCell2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCell2.Location = new System.Drawing.Point(100, 3);
            this.buttonCell2.Name = "buttonCell2";
            this.buttonCell2.Size = new System.Drawing.Size(91, 87);
            this.buttonCell2.TabIndex = 1;
            this.buttonCell2.Text = "2";
            this.buttonCell2.UseVisualStyleBackColor = true;
            this.buttonCell2.Click += new System.EventHandler(this.buttonCell_Click);
            // 
            // buttonCell1
            // 
            this.buttonCell1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCell1.AutoSize = true;
            this.buttonCell1.Enabled = false;
            this.buttonCell1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCell1.Location = new System.Drawing.Point(3, 3);
            this.buttonCell1.Name = "buttonCell1";
            this.buttonCell1.Size = new System.Drawing.Size(91, 87);
            this.buttonCell1.TabIndex = 0;
            this.buttonCell1.Text = "1";
            this.buttonCell1.UseVisualStyleBackColor = true;
            this.buttonCell1.Click += new System.EventHandler(this.buttonCell_Click);
            // 
            // buttonCell6
            // 
            this.buttonCell6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCell6.AutoSize = true;
            this.buttonCell6.Enabled = false;
            this.buttonCell6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCell6.Location = new System.Drawing.Point(100, 96);
            this.buttonCell6.Name = "buttonCell6";
            this.buttonCell6.Size = new System.Drawing.Size(91, 87);
            this.buttonCell6.TabIndex = 5;
            this.buttonCell6.Text = "6";
            this.buttonCell6.UseVisualStyleBackColor = true;
            this.buttonCell6.Click += new System.EventHandler(this.buttonCell_Click);
            // 
            // groupBoxTime
            // 
            this.groupBoxTime.Controls.Add(this.labelTimer);
            this.groupBoxTime.Location = new System.Drawing.Point(446, 46);
            this.groupBoxTime.Name = "groupBoxTime";
            this.groupBoxTime.Size = new System.Drawing.Size(136, 65);
            this.groupBoxTime.TabIndex = 2;
            this.groupBoxTime.TabStop = false;
            this.groupBoxTime.Text = "Время:";
            // 
            // labelTimer
            // 
            this.labelTimer.Enabled = false;
            this.labelTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTimer.Location = new System.Drawing.Point(19, 28);
            this.labelTimer.Name = "labelTimer";
            this.labelTimer.Size = new System.Drawing.Size(100, 23);
            this.labelTimer.TabIndex = 0;
            this.labelTimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBoxMoves
            // 
            this.groupBoxMoves.Controls.Add(this.labelMoves);
            this.groupBoxMoves.Location = new System.Drawing.Point(446, 126);
            this.groupBoxMoves.Name = "groupBoxMoves";
            this.groupBoxMoves.Size = new System.Drawing.Size(136, 65);
            this.groupBoxMoves.TabIndex = 2;
            this.groupBoxMoves.TabStop = false;
            this.groupBoxMoves.Text = "Ходы:";
            // 
            // labelMoves
            // 
            this.labelMoves.Enabled = false;
            this.labelMoves.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMoves.Location = new System.Drawing.Point(19, 28);
            this.labelMoves.Name = "labelMoves";
            this.labelMoves.Size = new System.Drawing.Size(100, 23);
            this.labelMoves.TabIndex = 0;
            this.labelMoves.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonNewGame
            // 
            this.buttonNewGame.Location = new System.Drawing.Point(446, 209);
            this.buttonNewGame.Name = "buttonNewGame";
            this.buttonNewGame.Size = new System.Drawing.Size(136, 38);
            this.buttonNewGame.TabIndex = 16;
            this.buttonNewGame.Text = "Новая игра";
            this.buttonNewGame.UseVisualStyleBackColor = true;
            this.buttonNewGame.Click += new System.EventHandler(this.NewGameHandler);
            // 
            // timerGame
            // 
            this.timerGame.Tick += new System.EventHandler(this.timerGame_Tick);
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.gameToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(611, 28);
            this.mainMenuStrip.TabIndex = 19;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileExitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
            this.fileToolStripMenuItem.Text = "&Файл";
            // 
            // fileExitToolStripMenuItem
            // 
            this.fileExitToolStripMenuItem.Name = "fileExitToolStripMenuItem";
            this.fileExitToolStripMenuItem.Size = new System.Drawing.Size(175, 24);
            this.fileExitToolStripMenuItem.Text = "Вы&ход";
            this.fileExitToolStripMenuItem.Click += new System.EventHandler(this.ExitHandler);
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameNewGameToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.gameToolStripMenuItem.Text = "&Игра";
            // 
            // gameNewGameToolStripMenuItem
            // 
            this.gameNewGameToolStripMenuItem.Name = "gameNewGameToolStripMenuItem";
            this.gameNewGameToolStripMenuItem.Size = new System.Drawing.Size(175, 24);
            this.gameNewGameToolStripMenuItem.Text = "&Новая игра";
            this.gameNewGameToolStripMenuItem.Click += new System.EventHandler(this.NewGameHandler);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpAboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(28, 24);
            this.helpToolStripMenuItem.Text = "&?";
            // 
            // helpAboutToolStripMenuItem
            // 
            this.helpAboutToolStripMenuItem.Name = "helpAboutToolStripMenuItem";
            this.helpAboutToolStripMenuItem.Size = new System.Drawing.Size(182, 24);
            this.helpAboutToolStripMenuItem.Text = "О &программе...";
            this.helpAboutToolStripMenuItem.Click += new System.EventHandler(this.AboutHandler);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 447);
            this.Controls.Add(this.groupBoxMoves);
            this.Controls.Add(this.groupBoxTime);
            this.Controls.Add(this.tableLayoutPanelCellButtons);
            this.Controls.Add(this.buttonNewGame);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonAbout);
            this.Controls.Add(this.mainMenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Пятнашки";
            this.tableLayoutPanelCellButtons.ResumeLayout(false);
            this.tableLayoutPanelCellButtons.PerformLayout();
            this.groupBoxTime.ResumeLayout(false);
            this.groupBoxMoves.ResumeLayout(false);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}

