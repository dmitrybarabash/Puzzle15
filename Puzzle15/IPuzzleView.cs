using System;
using System.Windows.Forms;

namespace Puzzle15
{
    public interface IPuzzleView
    {
        string LabelTimer { get; set; }
        string LabelMoves { get; set; }
        TableLayoutControlCollection Buttons { get; }

        event EventHandler<EventArgs> NewGame;
        event EventHandler<EventArgs> Timer;
        event EventHandler<EventArgs> Move;

        void StartTimer();
        void StopTimer();
        void UpdateGameLabels(bool active);
    }
}
