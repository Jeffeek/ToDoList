using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using ToDoObservableCollectionWPF;

namespace ToDoListWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// конструктор
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// метод, срабатывающий при закрытии окна(сохранение текущего состояния листа)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            ObservableCollection<ToDoItemViewModel> list = (this.DataContext as ToDoListModelView).Items;
            ObservableCollection<ToDoItem> listCorrect = new ObservableCollection<ToDoItem>();
            foreach (var item in list)
            {
                listCorrect.Add(item.Item);
            }
            ToDoListProvider.Reload(listCorrect);
        }
    }
}
