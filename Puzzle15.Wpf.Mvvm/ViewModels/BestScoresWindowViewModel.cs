using Puzzle15.Common;
using Puzzle15.DomainModel;

namespace Puzzle15.Wpf.Mvvm.ViewModels
{
    public class BestScoresWindowViewModel : BaseViewModel
    {
        private IPuzzleDomainModel Model => (System.Windows.Application.Current as App).Model;


    }
}
