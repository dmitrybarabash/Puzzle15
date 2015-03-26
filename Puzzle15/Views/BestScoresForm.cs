using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puzzle15.Views
{
    public partial class BestScoresForm : Form, IBestScoresView
    {

        #region IBestScoresView Implementation

        public TableLayoutControlCollection Labels
        {
            get { return tableLayoutPanelLabels.Controls; }
        }

        #endregion

        public BestScoresForm()
        {
            InitializeComponent();
        }
    }
}
