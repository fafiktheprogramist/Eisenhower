using NUnit.Framework;
using System;

namespace EisenhowerCore.Tests
{
    [TestFixture]
    public class TodoIntegrationTests
    {
        [Test]
        public void AddingTask_UpdatesQuarterListCorrectly()
        {
            // create instance of TodoQuarter
            TodoQuarter quarter = new TodoQuarter();
            // add title
            string title = "Test Task";
            // set deadline to tomorrow
            DateTime deadline = DateTime.Now.AddDays(1); 

            // go 
            quarter.AddItem(title, deadline);

            // assertion
            Assert.AreEqual(1, quarter.GetItems().Count);
            Assert.AreEqual(title, quarter.GetItem(0).GetTitle());
            Assert.AreEqual(deadline, quarter.GetItem(0).GetDeadLine());
        }

        [Test]
        public void RemovingTask_UpdatesQuarterListCorrectly()
        {
            // arrange
            TodoQuarter quarter = new TodoQuarter();
            string title = "Test Task";
            // set deadline to tomorrow
            DateTime deadline = DateTime.Now.AddDays(1); 
            quarter.AddItem(title, deadline);

            // go
            quarter.RemoveItem(0);

            // assertion
      
            Assert.AreEqual(0, quarter.GetItems().Count);
            //Console.WriteLine("odpalil sie");
        }
        [Test]
        public void RemoveItem_IndexOutOfRange_ThrowsIndexOutOfRangeException()
        {
            // new instance
            TodoQuarter quarter = new TodoQuarter();

            // go and assertion
            Assert.Throws<IndexOutOfRangeException>(() => quarter.RemoveItem(0));
        }
        [Test]
        public void GetItem_IndexOutOfRange_ThrowsIndexOutOfRangeException()
        {
            // new instance
            TodoQuarter quarter = new TodoQuarter();

            // go and assertion
            Assert.Throws<IndexOutOfRangeException>(() => quarter.GetItem(0));
        }
    }
}
