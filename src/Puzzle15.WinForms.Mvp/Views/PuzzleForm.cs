﻿using System;
using System.Windows.Forms;

namespace Puzzle15.WinForms.Mvp.Views
{
    public partial class PuzzleForm : Form, IPuzzleView
    {
        public PuzzleForm()
        {
            InitializeComponent();
            UpdateGameLabels(false);
        }

        #region IPuzzleView implementation

        public string LabelTimer
        {
            get => labelTimer.Text;
            set => labelTimer.Text = value;
        }

        public string LabelMoves
        {
            get => labelMoves.Text;
            set => labelMoves.Text = value;
        }

        public TableLayoutControlCollection Buttons => tableLayoutPanelCellButtons.Controls;

        public event EventHandler NewGame;

        public event EventHandler Timer;

        public new event EventHandler Move;

        public event EventHandler BestScores;

        public void StartTimer()
        {
            timerGame.Enabled = true;
        }

        public void StopTimer()
        {
            timerGame.Enabled = false;
        }

        public void UpdateGameLabels(bool active)
        {
            labelTimer.Text = "00:00:00";
            labelTimer.Enabled = active;
            labelMoves.Text = "0";
            labelMoves.Enabled = active;
        }

        #endregion

        public void buttonCell_Click(object sender, EventArgs e)
        {
            // Потенциально опасный вариант, который может привести к NullReferenceException
            //if (Move is not null)
            //    Move(sender, EventArgs.Empty);

            // Безопасный вариант
            //EventHandler eventHandler = Move;
            //if (eventHandler is not null)
            //    eventHandler(sender, EventArgs.Empty);

            // Другой, более короткий безопасный вариант
            Move?.Invoke(sender, EventArgs.Empty);
        }

        private void timerGame_Tick(object sender, EventArgs e)
        {
            // Потенциально опасный вариант, который может привести к NullReferenceException
            //if (Timer is not null)
            //    Timer(this, EventArgs.Empty);

            // Безопасный вариант
            //EventHandler eventHandler = Timer;
            //if (eventHandler is not null)
            //    eventHandler(this, EventArgs.Empty);

            // Другой, более короткий безопасный вариант
            Timer?.Invoke(this, EventArgs.Empty);
        }

        public void NewGameHandler(object sender, EventArgs e)
        {
            // Потенциально опасный вариант, который может привести к NullReferenceException
            //if (Move is not null)
            //    Move(this, EventArgs.Empty);

            // Безопасный вариант
            //EventHandler eventHandler = NewGame;
            //if (eventHandler is not null)
            //    eventHandler(this, EventArgs.Empty);

            // Другой, более короткий безопасный вариант
            NewGame?.Invoke(this, EventArgs.Empty);
        }

        private void BestScoresHandler(object sender, EventArgs e)
        {
            // Потенциально опасный вариант, который может привести к NullReferenceException
            //if (BestScores is not null)
            //    BestScores(this, EventArgs.Empty);

            // Безопасный вариант
            //EventHandler eventHandler = BestScores;
            //if (eventHandler is not null)
            //    eventHandler(this, EventArgs.Empty);

            // Другой, более короткий вариант
            BestScores?.Invoke(this, EventArgs.Empty);
        }

        private void AboutHandler(object sender, EventArgs e)
        {
            new AboutForm().ShowDialog();
        }

        private void ExitHandler(object sender, EventArgs e)
        {
            Close();
        }
    }
}
