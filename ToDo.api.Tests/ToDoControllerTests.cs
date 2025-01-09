using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using todo.api.Controllers;
using todo.api.Data;
using todo.api.Interfaces;
using todo.api.Models;

namespace ToDo.api.Tests
{

    [TestFixture]
    public class ToDoControllerTests
    {
        readonly Mock<IToDoItemRepository> _toDoItemRepository = new Mock<IToDoItemRepository>();
        ToDoController _toDoController;

        [SetUp]
        public void SetUp()
        {
            _toDoController = new ToDoController(_toDoItemRepository.Object);
        }

        [Test]
        public async Task ToDoController_GetAllItemsInDatabase_ReturnsAListOfToDoItems()
        {
            var result = await _toDoController.Get();

            Assert.That(result, Is.TypeOf<ActionResult<List<ToDoItem>>>());
        }


        [Test]
        public async Task ToDoController_GetAllItemsInDatabase_ReturnsHTTP200AndListOfItems()
        {
            var expected = new List<ToDoItem>() 
            {
                new ToDoItem
                {
                    Id = 1,
                    Task = "Task 1",
                    Description = "Description",
                    IsCompleted = true,
                },
                new ToDoItem
                {
                    Id = 2,
                    Task = "Task 2",
                    Description = "Description",
                    IsCompleted = true,
                },
                new ToDoItem
                {
                    Id = 3,
                    Task = "Task 3",
                    Description = "Description",
                    IsCompleted = true,
                },
            };

            _toDoItemRepository
                .Setup(x => x.GetAll())
                .ReturnsAsync(expected);

            var response = await _toDoController.Get();

            Assert.That(response.Value as List<ToDoItem>, Is.EqualTo(expected));

        }
    }
}
