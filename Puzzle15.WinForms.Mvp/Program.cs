using System;
using System.Windows.Forms;
using Puzzle15.DomainModel;
using Puzzle15.WinForms.Mvp.Presenters;
using Puzzle15.WinForms.Mvp.Views;

namespace Puzzle15.WinForms.Mvp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new SplashScreenForm());
            var puzzlePresenter = new PuzzlePresenter(new PuzzleDomainModel(), new PuzzleForm());
            Application.Run((Form)puzzlePresenter.View);
        }
    }
}
