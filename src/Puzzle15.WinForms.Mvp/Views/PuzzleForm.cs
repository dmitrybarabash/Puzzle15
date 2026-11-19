using System;
using System.Windows.Forms;

namespace Puzzle15.WinForms.Mvp.Views;

public partial class PuzzleForm : Form, IPuzzleView
{
    // Кнопки поля по клеткам [y, x]
    private readonly Button[,] _cellButtons;

    public PuzzleForm()
    {
        InitializeComponent();

        // В какой клетке стоит каждая кнопка, задано в дизайнере, поэтому берем это из таблицы
        _cellButtons = new Button[tableLayoutPanelCellButtons.RowCount, tableLayoutPanelCellButtons.ColumnCount];
        foreach (Button button in tableLayoutPanelCellButtons.Controls)
        {
            TableLayoutPanelCellPosition position = tableLayoutPanelCellButtons.GetCellPosition(button);
            _cellButtons[position.Row, position.Column] = button;
        }
    }

    #region IPuzzleView implementation

    public event EventHandler NewGame;

    public event EventHandler Timer;

    public event EventHandler<CellClickedEventArgs> CellClicked;

    public event EventHandler BestScores;

    public void ShowCell(uint y, uint x, string text, bool visible)
    {
        Button button = _cellButtons[y, x];
        button.Text = text;
        button.Visible = visible;
    }

    public void SetFieldEnabled(bool enabled)
    {
        foreach (Button button in _cellButtons)
            button.Enabled = enabled;
    }

    public void ShowElapsedTime(string time)
    {
        labelTimer.Text = time;
    }

    public void ShowMoves(string moves)
    {
        labelMoves.Text = moves;
    }

    public void SetGameLabelsEnabled(bool enabled)
    {
        labelTimer.Enabled = enabled;
        labelMoves.Enabled = enabled;
    }

    public void StartTimer()
    {
        timerGame.Enabled = true;
    }

    public void StopTimer()
    {
        timerGame.Enabled = false;
    }

    public void ShowWinMessage(string message)
    {
        MessageBox.Show(message, "Молодец!", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    public string AskPlayerName()
    {
        using var bestScoredPlayerNameForm = new BestScoredPlayerNameForm();
        return bestScoredPlayerNameForm.ShowDialog() == DialogResult.OK ? bestScoredPlayerNameForm.PlayerName : null;
    }

    public IBestScoresView CreateBestScoresView()
    {
        return new BestScoresForm();
    }

    #endregion

    private void CellClickedHandler(object sender, EventArgs e)
    {
        TableLayoutPanelCellPosition position = tableLayoutPanelCellButtons.GetCellPosition((Control)sender);
        var cellClickedEventArgs = new CellClickedEventArgs((uint)position.Row, (uint)position.Column);

        // Потенциально опасный вариант, который может привести к NullReferenceException
        //if (CellClicked is not null)
        //    CellClicked(this, cellClickedEventArgs);

        // Безопасный вариант
        //EventHandler<CellClickedEventArgs> eventHandler = CellClicked;
        //if (eventHandler is not null)
        //    eventHandler(this, cellClickedEventArgs);

        // Другой, более короткий безопасный вариант
        CellClicked?.Invoke(this, cellClickedEventArgs);
    }

    private void TimerHandler(object sender, EventArgs e)
    {
        // Потенциально опасный вариант, который может привести к NullReferenceException
        //if (Timer is not null)
        //    Timer(this, EventArgs.Empty);

        // Безопасный вариант
        //EventHandler eventHandler = Timer;
        //if (eventHandler is not null)
        //    eventHandler(this, EventArgs.Empty);

        // Другой, более короткий безопасный вариант
        Timer?.Invoke(this, EventArgs.Empty);
    }

    private void NewGameHandler(object sender, EventArgs e)
    {
        // Потенциально опасный вариант, который может привести к NullReferenceException
        //if (NewGame is not null)
        //    NewGame(this, EventArgs.Empty);

        // Безопасный вариант
        //EventHandler eventHandler = NewGame;
        //if (eventHandler is not null)
        //    eventHandler(this, EventArgs.Empty);

        // Другой, более короткий безопасный вариант
        NewGame?.Invoke(this, EventArgs.Empty);
    }

    private void BestScoresHandler(object sender, EventArgs e)
    {
        // Потенциально опасный вариант, который может привести к NullReferenceException
        //if (BestScores is not null)
        //    BestScores(this, EventArgs.Empty);

        // Безопасный вариант
        //EventHandler eventHandler = BestScores;
        //if (eventHandler is not null)
        //    eventHandler(this, EventArgs.Empty);

        // Другой, более короткий безопасный вариант
        BestScores?.Invoke(this, EventArgs.Empty);
    }

    private void AboutHandler(object sender, EventArgs e)
    {
        using var aboutForm = new AboutForm();
        aboutForm.ShowDialog();
    }

    private void ExitHandler(object sender, EventArgs e)
    {
        Close();
    }
}
