using System;
using System.Threading;
using System.Windows.Forms;
using NUnit.Framework;
using Puzzle15.Presenters;
using Puzzle15.Tests.Stubs;
using Puzzle15.Views;

namespace Puzzle15.Tests.Presenters
{
    [TestFixture]
    class PuzzlePresenterTests
    {
        [Test]
        public void NewGame()
        {
            var model = new StubPuzzleDomainModel();
            var view = new PuzzleForm();
            var presenter = new PuzzlePresenter(model, view);

            // Способ 1
            new Thread(() => { view.ShowDialog(); }) { IsBackground = true }.Start();
            // Способ 2
            //Task.Run(() => { view.ShowDialog(); });

            var buttonNewGame = view.Controls.Find("buttonNewGame", true)[0];
            view.NewGameHandler(buttonNewGame, EventArgs.Empty);

            if (view.Controls.Find("labelTimer", true)[0].Enabled == false ||
                view.Controls.Find("labelMoves", true)[0].Enabled == false)
                Assert.Fail();
            for (int i = 1; i <= 16; i++)
                if (view.Controls.Find("buttonCell" + i, true)[0].Enabled == false)
                    Assert.Fail();
            for (int i = 1; i <= 14; i++)
                if (uint.Parse(view.Controls.Find("buttonCell" + i, true)[0].Text) != i)
                    Assert.Fail();
            if (uint.Parse(view.Controls.Find("buttonCell15", true)[0].Text) != 16U)
                Assert.Fail();
            if (uint.Parse(view.Controls.Find("buttonCell16", true)[0].Text) != 15U)
                Assert.Fail();
            if (view.Controls.Find("buttonCell15", true)[0].Visible)
                Assert.Fail();
            //if (view.Controls.Find("buttonCell16", true)[0].Visible == false)
            //    Assert.Fail();
            Assert.Pass();
        }

        //[Test]
        //public void Move()
        //{
        //    var model = new StubPuzzleDomainModel();
        //    var view = new PuzzleForm();
        //    var presenter = new PuzzlePresenter(model, view);

        //    // Способ 1
        //    new Thread(() => { view.ShowDialog(); }) { IsBackground = true }.Start();
        //    // Способ 2
        //    //Task.Run(() => { view.ShowDialog(); });

        //    var buttonNewGame = view.Controls.Find("buttonNewGame", true)[0];
        //    view.NewGameHandler(buttonNewGame, EventArgs.Empty);
        //    var buttonCell16 = view.Controls.Find("buttonCell16", true)[0] as Button;
        //    view.buttonCell_Click(buttonCell16, EventArgs.Empty);

        //    for (int i = 1; i <= 16; i++)
        //        if (view.Controls.Find("buttonCell" + i, true)[0].Enabled)
        //            Assert.Fail();
        //    for (int i = 1; i <= 16; i++)
        //        if (uint.Parse(view.Controls.Find("buttonCell" + i, true)[0].Text) != i)
        //            Assert.Fail();
        //    if (view.Controls.Find("buttonCell15", true)[0].Visible == false)
        //        Assert.Fail();
        //    if (view.Controls.Find("buttonCell16", true)[0].Visible)
        //        Assert.Fail();
        //    Assert.Pass();
        //}
    }
}
