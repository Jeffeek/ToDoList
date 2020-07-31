using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ToDoListWPF
{
    /// <summary>
    /// Класс-связующий модель ToDoItem и View
    /// </summary>
    public class ToDoItemViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Отдельный элемент ToDo item
        /// </summary>
        public ToDoItem Item;
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// свойство модели ToDo item
        /// </summary>
        public bool IsDone
        {
            get => Item.IsDone;
            set
            {
                Item.IsDone = value;
                OnPropertyChanged(nameof(IsDone));
            }
        }

        /// <summary>
        /// свойство модели ToDo item
        /// </summary>
        public string Text
        {
            get => Item.Text;
            set
            {
                Item.Text = value;
                OnPropertyChanged(nameof(Text));
            }
        }

        /// <summary>
        /// свойство модели ToDo item
        /// </summary>
        public DateTime CreateTime
        {
            get => Item.CreateTime;
            set
            {
                Item.CreateTime = value;
                OnPropertyChanged(nameof(CreateTime));
            }
        }

        /// <summary>
        /// метод, срабатывающий при изменении свойства
        /// </summary>
        /// <param name="prop"></param>
        public void OnPropertyChanged([CallerMemberName] string prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="item">ToDo item модели, привязывающийся к ModelView</param>
        public ToDoItemViewModel(ToDoItem item)
        {
            Item = item;
            Text = Item.Text;
            CreateTime = Item.CreateTime;
            IsDone = Item.IsDone;
        }
    }
}
