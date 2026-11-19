using System;
using System.Windows.Forms;
using Puzzle15.Common.DomainModel;
using Puzzle15.WinForms.Mvp.Presenters;
using Puzzle15.WinForms.Mvp.Views;

namespace Puzzle15.WinForms.Mvp;

static class Program
{
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        Application.Run(new SplashScreenForm());
        var puzzleForm = new PuzzleForm();
        new PuzzlePresenter(new PuzzleDomainModel(), puzzleForm);
        Application.Run(puzzleForm);
    }
}
