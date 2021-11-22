using System.Windows.Forms;
using Puzzle15.Common;

namespace Puzzle15.WinForms.Mvp.Views;

public interface IBestScoresView : IView
{
    TableLayoutControlCollection Labels { get; }
}
