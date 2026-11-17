using System;
using System.Windows.Forms;
using Puzzle15.Common.DomainModel;

namespace Puzzle15.WinForms.Mvp.Views;

public partial class BestScoredPlayerNameForm : Form
{
    public BestScoredPlayerNameForm()
    {
        InitializeComponent();
        nameTextBox.MaxLength = Score.MaxNameLength;
    }

    public string PlayerName { get => nameTextBox.Text.Trim(); }

    private void nameTextBox_TextChanged(object sender, EventArgs e)
    {
        buttonOk.Enabled = PlayerName.Length > 0;
    }
}
