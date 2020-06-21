using System.Windows.Forms;
using Puzzle15.Common;

namespace Puzzle15.Views
{
    public interface IBestScoresView : IView
    {
        TableLayoutControlCollection Labels { get; }
    }
}