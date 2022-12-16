using System;
using System.Threading;
using System.Windows.Forms;
using NUnit.Framework;
using Puzzle15.WinForms.Mvp.Presenters;
using Puzzle15.WinForms.Mvp.Views;
using Puzzle15.WinForms.Mvp.UnitTests.Stubs;

namespace Puzzle15.WinForms.Mvp.UnitTests.Presenters;

[TestFixture]
class PuzzlePresenterTests
{
    [Test]
    public void NewGame()
    {
        // Arrange
        var model = new StubPuzzleDomainModel();
        var view = new PuzzleForm();
        var presenter = new PuzzlePresenter(model, view);

        // Act

        // Способ 1
        new Thread(() => { view.ShowDialog(); }) { IsBackground = true }.Start();
        // Способ 2
        //Task.Run(() => { view.ShowDialog(); });

        var buttonNewGame = view.Controls.Find("buttonNewGame", searchAllChildren: true)[0];
        view.NewGameHandler(buttonNewGame, EventArgs.Empty);

        // Assert
        if (view.Controls.Find("labelTimer", searchAllChildren: true)[0].Enabled == false ||
            view.Controls.Find("labelMoves", searchAllChildren: true)[0].Enabled == false)
            Assert.Fail();
        for (int i = 1; i <= 16; i++)
            if (view.Controls.Find($"buttonCell{i}", searchAllChildren: true)[0].Enabled == false)
                Assert.Fail();
        for (int i = 1; i <= 14; i++)
            if (uint.Parse(view.Controls.Find($"buttonCell{i}", searchAllChildren: true)[0].Text) != i)
                Assert.Fail();
        if (uint.Parse(view.Controls.Find("buttonCell15", searchAllChildren: true)[0].Text) != 16U)
            Assert.Fail();
        if (uint.Parse(view.Controls.Find("buttonCell16", searchAllChildren: true)[0].Text) != 15U)
            Assert.Fail();
        if (view.Controls.Find("buttonCell15", searchAllChildren: true)[0].Visible)
            Assert.Fail();
        //if (!view.Controls.Find("buttonCell16", searchAllChildren: true)[0].Visible)
        //    Assert.Fail();
        Assert.Pass();
    }

    //[Test]
    //public void Move()
    //{
    //    // Arrange
    //    var model = new StubPuzzleDomainModel();
    //    var view = new PuzzleForm();
    //    var presenter = new PuzzlePresenter(model, view);
    //
    //    // Act
    //
    //    // Способ 1
    //    new Thread(() => { view.ShowDialog(); }) { IsBackground = true }.Start();
    //    // Способ 2
    //    //Task.Run(() => { view.ShowDialog(); });
    //
    //    var buttonNewGame = view.Controls.Find("buttonNewGame", searchAllChildren: true)[0];
    //    view.NewGameHandler(buttonNewGame, EventArgs.Empty);
    //    var buttonCell16 = view.Controls.Find("buttonCell16", searchAllChildren: true)[0] as Button;
    //    view.buttonCell_Click(buttonCell16, EventArgs.Empty);
    //
    //    // Assert
    //    for (int i = 1; i <= 16; i++)
    //        if (view.Controls.Find($"buttonCell{i}", searchAllChildren: true)[0].Enabled)
    //            Assert.Fail();
    //    for (int i = 1; i <= 16; i++)
    //        if (uint.Parse(view.Controls.Find($"buttonCell{i}", searchAllChildren: true)[0].Text) != i)
    //            Assert.Fail();
    //    if (!view.Controls.Find("buttonCell15", searchAllChildren: true)[0].Visible)
    //        Assert.Fail();
    //    if (view.Controls.Find("buttonCell16", searchAllChildren: true)[0].Visible)
    //        Assert.Fail();
    //    Assert.Pass();
    //}
}
