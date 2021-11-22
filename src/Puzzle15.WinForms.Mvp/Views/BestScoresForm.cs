using System.Windows.Forms;

namespace Puzzle15.WinForms.Mvp.Views
{
    public partial class BestScoresForm : Form, IBestScoresView
    {
        public BestScoresForm()
        {
            InitializeComponent();
        }

        #region IBestScoresView implementation

        public TableLayoutControlCollection Labels => tableLayoutPanelLabels.Controls;

        #endregion
    }
}
