using System.Windows.Forms;

namespace Puzzle15.Views
{
    public partial class BestScoresForm : Form, IBestScoresView
    {
        public BestScoresForm()
        {
            InitializeComponent();
        }

        #region IBestScoresView implementation

        public TableLayoutControlCollection Labels
        {
            get => tableLayoutPanelLabels.Controls;
        }

        #endregion
    }
}
