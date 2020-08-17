using System;
using System.Collections.Generic;
using System.Text;
using TaskList.Core;
using TaskList.Core.Models;
using TaskList.Core.Services;

namespace TaskList.Services
{
    public class ToDoItemService : IToDoItemService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ToDoItemService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateToDoItem(ToDoItem toDoItem)
        {
            _unitOfWork.ToDoItems.Add(toDoItem);
            _unitOfWork.Commit();
        }

        public void DeleteToDoItem(ToDoItem toDoItem)
        {
            _unitOfWork.ToDoItems.Delete(toDoItem);
            _unitOfWork.Commit();
        }

        public ToDoItem GetWithProjectById(int id)
        {
            return _unitOfWork.ToDoItems.GetWithProjectById(id);
        }

        public IEnumerable<ToDoItem> GetAllWithProject()
        {
            return _unitOfWork.ToDoItems.GetAllWithProject();
        }

        public IEnumerable<ToDoItem> GetToDoItems()
        {
            return _unitOfWork.ToDoItems.GetAll();
        }

        public ToDoItem GetToDoItem(int id)
        {
            return _unitOfWork.ToDoItems.GetById(id);
        }

        public void UpdateToDoItem(ToDoItem toDoItemToBeUpdate, ToDoItem toDoItem)
        {
            toDoItemToBeUpdate.Name = toDoItem.Name;
            toDoItemToBeUpdate.IsCompleted = toDoItem.IsCompleted;
            toDoItemToBeUpdate.IsFromInbox = toDoItem.IsFromInbox;
            toDoItemToBeUpdate.ProjectId = toDoItem.ProjectId;

            _unitOfWork.Commit();
        }
    }
}
