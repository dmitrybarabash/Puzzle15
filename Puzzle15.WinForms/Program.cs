using System;
using System.Windows.Forms;
using Puzzle15.Common;
using Puzzle15.DomainModel;
using Puzzle15.Presenters;
using Puzzle15.Views;

namespace Puzzle15
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
