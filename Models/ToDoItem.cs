using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace ToDoListWPF
{
    /// <summary>
    /// Класс, представляющий собой модель ToDo item
    /// </summary>
    [DataContract]
    public class ToDoItem
    {
        /// <summary>
        /// уникальный ID ToDo item
        /// </summary>
        [DataMember]
        public int ID { get; set; }
        /// <summary>
        /// Время создания ToDo item
        /// </summary>
        [DataMember]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// булевое поле, показывающее состояние текущего ToDo item
        /// </summary>
        [DataMember]
        public bool IsDone { get; set; }
        /// <summary>
        /// Текст задания ToDo item
        /// </summary>
        [DataMember]
        public string Text { get; set; }

        /// <summary>
        /// конструктор 
        /// </summary>
        /// <param name="time">время создания</param>
        public ToDoItem(DateTime time)
        {
            CreateTime = time;
        }
    }
}
