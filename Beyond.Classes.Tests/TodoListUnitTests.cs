using Beyond.Contracts;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beyond.Classes.Tests
{
    [TestClass]
    public class TodoListUnitTests
    {
        [TestMethod]
        public void AddItem_WhenItemListIsEmpty_ShouldCreateListAndInsertItem()
        {
            // Arrange
            var todoList = new TodoList();
            var id = 1;
            var title = "foo";
            var description = "var";
            var category = "baz";

            // Act
            todoList.AddItem(id, title, description, category);

            // Assert
            todoList.Items.Should().NotBeNull();
            todoList.Items.Count.Should().Be(1);
            var firstItem = todoList.Items.First();
            firstItem.Id.Should().Be(id);
            firstItem.Title.Should().Be(title);
            firstItem.Description.Should().Be(description);
            firstItem.Category.Should().Be(category);
        }

        [TestMethod]
        public void AddItem_WhenItemListIsNotEmpty_ShouldAddNewItem()
        {
            // Arrange
            var todoList = new TodoList();

            var id = 2;
            var title = "foo";
            var description = "var";
            var category = "baz";

            todoList.Items = new List<ITodoItem>();
            todoList.Items.Add(new TodoItem
            {
                Id = 1,
                Title = "old",
                Description = "old",
                Category = "old"
            });

            // Act
            todoList.AddItem(id, title, description, category);

            // Assert
            todoList.Items.Should().NotBeNull();
            todoList.Items.Count.Should().Be(2);
            var firstItem = todoList.Items.First(i => i.Id == id);
            firstItem.Id.Should().Be(id);
            firstItem.Title.Should().Be(title);
            firstItem.Description.Should().Be(description);
            firstItem.Category.Should().Be(category);
        }

        [TestMethod]
        public void RemoveItem_IfSuitsConditions_ShouldRemoveItem()
        {
            // Arrange
            var todoList = new TodoList();

            var id = 1;
            var title = "foo";
            var description = "var";
            var category = "baz";

            todoList.AddItem(id, title, description, category);

            var progressionPercentage = 50;
            var progressionDateTime = DateTime.Now;

            todoList.RegisterProgression(id, progressionDateTime, progressionPercentage);

            // Act
            todoList.RemoveItem(id);

            // Assert
            todoList.Items.Count.Should().Be(0);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void RemoveItem_IfItemDoesNotExists_ShouldThrowException()
        {
            // Arrange
            var todoList = new TodoList();

            var id = 1;
            var title = "foo";
            var description = "var";
            var category = "baz";

            todoList.AddItem(id, title, description, category);

            var progressionPercentage = 50;
            var progressionDateTime = DateTime.Now;

            todoList.RegisterProgression(id, progressionDateTime, progressionPercentage);

            var noExistingItemId = 2;

            // Act
            todoList.RemoveItem(noExistingItemId);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataException))]
        public void RemoveItem_IfProgressIsGreaterThan50Percent_ShouldThrowException()
        {
            // Arrange
            var todoList = new TodoList();

            var id = 1;
            var title = "foo";
            var description = "var";
            var category = "baz";

            todoList.AddItem(id, title, description, category);

            var progressionPercentage = 51;
            var progressionDateTime = DateTime.Now;

            todoList.RegisterProgression(id, progressionDateTime, progressionPercentage);

            // Act
            todoList.RemoveItem(id);
        }
    }
}
