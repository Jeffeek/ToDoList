using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Prism.Commands;
using ToDoObservableCollectionWPF;

namespace ToDoListWPF
{
    /// <summary>
    /// Основной класс ModelView листа из ToDo items
    /// </summary>
    class ToDoListModelView : INotifyPropertyChanged
    {
        /// <summary>
        /// основная коллеция всех ToDo items
        /// </summary>
        public ObservableCollection<ToDoItemViewModel> Items { get; set; }

        /// <summary>
        /// комманда добавления
        /// </summary>
        public DelegateCommand Add => new DelegateCommand(() =>
        {
            Items.Add(new ToDoItemViewModel(new ToDoItem(DateTime.Now)));
            OnPropertyChanged(nameof(Items));
        });

        /// <summary>
        /// команда удаления
        /// </summary>
        public DelegateCommand<ToDoItemViewModel> Remove => new DelegateCommand<ToDoItemViewModel>(item =>
        {
            Items.Remove(item);
            OnPropertyChanged(nameof(Items));
        }, item => item != null);

        /// <summary>
        /// команда удаления всех элементов
        /// </summary>
        public DelegateCommand DeleteAll => new DelegateCommand(() =>
        {
            Items.Clear();
            OnPropertyChanged(nameof(Items));
        });

        /// <summary>
        /// команда сохранения текущего листа в файл для сериализациии
        /// </summary>
        public DelegateCommand Save => new DelegateCommand(() =>
        {
            var items = new ObservableCollection<ToDoItem>();
            foreach (var item in Items)
            {
                items.Add(item.Item);
            }
            ToDoListProvider.Reload(items);
            OnPropertyChanged(nameof(Items));
        });

        /// <summary>
        /// конструктор
        /// </summary>
        public ToDoListModelView()
        {
            Items = ToDoListProvider.GetToDoItems();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// метод, вызывающийся при изменении листа
        /// </summary>
        /// <param name="prop">свойство, которое было изменено</param>
        public void OnPropertyChanged([CallerMemberName] string prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
