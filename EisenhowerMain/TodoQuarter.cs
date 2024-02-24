using System;
using System.Collections.Generic;

namespace EisenhowerCore { 
    public class TodoQuarter {
        private List<TodoItem> TodoItems { get; set; }

        public TodoQuarter() {
            TodoItems = new List<TodoItem>();
        }
        public void AddItem(string Title, DateTime DeadLine) {
            // check if deadline is in the past EX.1.1/1.2
            if(!(DeadLine < DateTime.Now)) {
                // check if title is null EX.2.3
                if (!string.IsNullOrWhiteSpace(Title)) {
                    TodoItems.Add(new TodoItem(Title, DeadLine));
                }
                else { throw new ArgumentException("Title cannot be null."); }
            }
            else { throw new ArgumentException("Deadline cannot be in the past."); }
        }

        public void RemoveItem(int Index) {
            // check if item to remove index is in range of list EX.2.1
            if(Index >= 0 && Index < TodoItems.Count) {
                TodoItems.RemoveAt(Index);
            }
            else {
                throw new IndexOutOfRangeException("Invalid index. Cannot remove");
            }
        }
        public void ArchiveItems() {
            foreach(TodoItem Item in TodoItems) {
                if(Item.IsDone == true) {
                    TodoItems.Remove(Item);
                }
            }
        }
        public TodoItem GetItem(int Index) {
            // checking if item is in range EX.2.2
            if (Index >= 0 && Index < TodoItems.Count) {
                return TodoItems[Index];
            }
            else {
                throw new IndexOutOfRangeException("Invalid index. Cannot remove");
            }
        }
        public List<TodoItem> GetItems() {
            return TodoItems;
        }
        public List<string> ToList() {
            List<string> ItemsToReturn = new List<string>();
            foreach(TodoItem Item in TodoItems) {
                ItemsToReturn.Add(Item.ToString());
            }
            return ItemsToReturn;
        }
    }
}