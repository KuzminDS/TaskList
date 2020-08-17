using System;
using System.Collections.Generic;
using System.Text;
using TaskList.Core.Models;

namespace TaskList.Core.Services
{
    public interface IToDoItemService
    {
        IEnumerable<ToDoItem> GetToDoItems();
        IEnumerable<ToDoItem> GetAllWithProject();
        ToDoItem GetToDoItem(int id);
        ToDoItem GetWithProjectById(int id);
        void CreateToDoItem(ToDoItem toDoItem);
        void UpdateToDoItem(ToDoItem toDoItemToBeUpdate, ToDoItem toDoItem);
        void DeleteToDoItem(ToDoItem toDoItem);
    }
}
