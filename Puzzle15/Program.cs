using System;
using System.Windows.Forms;
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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SplashScreenForm());

            //var puzzle = new Puzzle();
            //var puzzleForm = new PuzzleForm();
            //var puzzlePresenter = new PuzzlePresenter(puzzle, puzzleForm);
            //Application.Run(puzzleForm);

            var puzzlePresenter = new PuzzlePresenter(new Puzzle(), new PuzzleForm());
            Application.Run((Form)puzzlePresenter.View);
        }
    }
}
