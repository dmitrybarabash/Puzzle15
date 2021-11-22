using System;
using System.Windows.Forms;
using Puzzle15.Common;

namespace Puzzle15.WinForms.Mvp.Views;

public interface IPuzzleView : IView
{
    string LabelTimer { get; set; }
    string LabelMoves { get; set; }
    TableLayoutControlCollection Buttons { get; }

    event EventHandler NewGame;
    event EventHandler Timer;
    event EventHandler Move;
    event EventHandler BestScores;

    void StartTimer();
    void StopTimer();
    void UpdateGameLabels(bool active);
}
