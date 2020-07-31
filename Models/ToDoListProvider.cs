using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using ToDoListWPF;

namespace ToDoObservableCollectionWPF
{
    /// <summary>
    /// Класс-помощник для взаимодействия с файлом, где хранятся ToDo items
    /// </summary>
    public static class ToDoListProvider
    {
        /// <summary>
        /// путь к файлу в файловой системе
        /// </summary>
        private static readonly string JsonPath = $"{Directory.GetCurrentDirectory()}\\ToDo.json";

        /// <summary>
        /// метод, возвращающий список ToDo items из файла
        /// </summary>
        /// <returns></returns>
        public static ObservableCollection<ToDoItemViewModel> GetToDoItems()
        {
            ObservableCollection<ToDoItem> items = null;
            ObservableCollection<ToDoItemViewModel> items2 = new ObservableCollection<ToDoItemViewModel>();
            try
            {
                DataContractSerializer jsonSerializer =
                    new DataContractSerializer(typeof(ObservableCollection<ToDoItem>));
                using (var stream = new FileStream(JsonPath, FileMode.OpenOrCreate))
                {
                    items = jsonSerializer.ReadObject(stream) as ObservableCollection<ToDoItem>;
                }

                foreach (var item in items)
                {
                    items2.Add(new ToDoItemViewModel(item));
                }
            }
            catch (Exception)
            {
                Debug.WriteLine("LUL");
            }

            return items2;
        }

        /// <summary>
        /// метод, записывающий в файл переданного листа из ToDo items
        /// </summary>
        /// <param name="items"></param>
        public static async void Reload(ObservableCollection<ToDoItem> items)
        {
            await Task.Run(() =>
            {
                DataContractSerializer jsonSerializer =
                    new DataContractSerializer(typeof(ObservableCollection<ToDoItem>));
                try
                {
                    using (var writer = new StreamWriter(JsonPath))
                    {
                        writer.Write(String.Empty.ToCharArray());
                    }

                    using (var stream = new FileStream(JsonPath, FileMode.OpenOrCreate))
                    {
                        jsonSerializer.WriteObject(stream, items);
                    }
                }
                catch (Exception)
                {
                    Debug.WriteLine("LUL");
                }
            });
        }
    }
}
