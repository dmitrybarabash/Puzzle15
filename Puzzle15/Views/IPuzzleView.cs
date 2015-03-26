using System;
using System.Windows.Forms;
using Puzzle15.Common;

namespace Puzzle15.Views
{
    public interface IPuzzleView : IView
    {
        string LabelTimer { get; set; }
        string LabelMoves { get; set; }
        TableLayoutControlCollection Buttons { get; }

        event EventHandler NewGame;
        event EventHandler Timer;
        event EventHandler Move;

        void StartTimer();
        void StopTimer();
        void UpdateGameLabels(bool active);
    }
}
