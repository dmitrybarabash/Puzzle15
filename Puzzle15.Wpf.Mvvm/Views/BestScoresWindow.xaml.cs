using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Puzzle15.Common;
using Puzzle15.DomainModel;

namespace Puzzle15.Wpf.Mvvm.Views
{
    public partial class BestScoresWindow : Window
    {
        private IPuzzleDomainModel Model { get; }

        public BestScoresWindow(IPuzzleDomainModel model)
        {
            InitializeComponent();

            Model = model;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //
            // Загружаем лучшие результаты из файла
            //
            try
            {
                Model.BestScoresStorage.Load(Model.BestScores);
            }
            catch
            {
                // Ничего не делаем, пользователю ничего не говорим.
                // Не получилось прочитать файл с рекордами — ок, просто пропускаем эту часть.
                return;
            }

            //
            // Раскладываем их по TextBlock'ам в сетке
            //

            //
            // Подробный вариант
            //
            // Получаем все дочерние контролы сетки в виде коллекции UIElementCollection
            //UIElementCollection elementCollection = gridBestScores.Children;
            // Преобразуем полученную коллекцию в List<FrameworkElement>
            //List<FrameworkElement> elementList = elementCollection.Cast<FrameworkElement>().ToList();
            // Выделяем из этого списка всех контролов только TextBlock'и
            //IEnumerable<TextBlock> textBlockList = elementList.OfType<TextBlock>();

            //
            // Этот же вариант покороче
            //
            var textBlockList = gridBestScores.Children.Cast<FrameworkElement>().ToList().OfType<TextBlock>();

            foreach (TextBlock textBlock in textBlockList)
            {
                if (textBlock.Name.StartsWith("textBlockName"))
                {
                    int index = int.Parse(textBlock.Name.Remove(0, 13)) - 1;
                    if (index < Model.BestScores.Count)
                        textBlock.Text = Model.BestScores[index].Name;
                }
                if (textBlock.Name.StartsWith("textBlockMoves"))
                {
                    int index = int.Parse(textBlock.Name.Remove(0, 14)) - 1;
                    if (index < Model.BestScores.Count)
                        textBlock.Text = $"{Model.BestScores[index].Moves} {Utils.GetMovesWord(Model.BestScores.Scores[index].Moves)}";
                }
                if (textBlock.Name.StartsWith("textBlockTimer"))
                {
                    int index = int.Parse(textBlock.Name.Remove(0, 14)) - 1;
                    if (index < Model.BestScores.Count)
                        textBlock.Text = Model.BestScores[index].Timer.ToString(@"hh\:mm\:ss");
                }
            }
        }
    }
}
