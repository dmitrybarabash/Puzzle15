using System.Windows.Forms;

namespace Puzzle15.Views
{
    public partial class BestScoresForm : Form, IBestScoresView
    {
        public BestScoresForm()
        {
            InitializeComponent();
        }

        #region IBestScoresView Implementation

        public TableLayoutControlCollection Labels
        {
            get { return tableLayoutPanelLabels.Controls; }
        }

        #endregion
    }
}
