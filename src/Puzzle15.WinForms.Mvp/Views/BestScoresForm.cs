using System.Windows.Forms;

namespace Puzzle15.WinForms.Mvp.Views;

public partial class BestScoresForm : Form, IBestScoresView
{
    private const int NameColumn = 1;
    private const int MovesColumn = 2;
    private const int TimerColumn = 3;

    // Подписи таблицы рекордов по ячейкам [строка, столбец]
    private readonly Label[,] _labels;

    public BestScoresForm()
    {
        InitializeComponent();

        // В какой ячейке стоит каждая подпись, задано в дизайнере, поэтому берем это из таблицы
        _labels = new Label[tableLayoutPanelLabels.RowCount, tableLayoutPanelLabels.ColumnCount];
        foreach (Label label in tableLayoutPanelLabels.Controls)
        {
            TableLayoutPanelCellPosition position = tableLayoutPanelLabels.GetCellPosition(label);
            _labels[position.Row, position.Column] = label;
        }
    }

    #region IBestScoresView implementation

    public void ShowScore(int index, string name, string moves, string time)
    {
        _labels[index, NameColumn].Text = name;
        _labels[index, MovesColumn].Text = moves;
        _labels[index, TimerColumn].Text = time;
    }

    public void ShowWarning(string message)
    {
        MessageBox.Show(message, "Пятнашки", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    public void ShowModal()
    {
        ShowDialog();
    }

    #endregion
}
