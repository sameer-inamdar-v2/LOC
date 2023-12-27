using LoanOffersCalculator.UnitTest.Shared;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanOffersCalculator.UnitTest.Windows
{
    public class ToDoTestCase
    {
        private ToDo toDo;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            toDo = new ToDo();
        }

        [Test, Order(1)]
        public void OpenTodoPage() => toDo.OpenTodoPage();

        [Test, Order(2)]
        public void AddToDo() => toDo.AddToDo();

        [Test, Order(3)]
        public void RemoveToDo() => toDo.RemoveToDo();
    }
}
