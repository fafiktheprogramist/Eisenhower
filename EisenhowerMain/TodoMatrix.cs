using System;
using System.Collections.Generic;


namespace EisenhowerCore {
    public class TodoMatrix {
        private Dictionary<string, TodoQuarter> TodoQuarters { get; set; }
        public TodoMatrix() {
            TodoQuarters = new Dictionary<string, TodoQuarter> {
                {"IU", new TodoQuarter()},  // important - urgent
                {"IN", new TodoQuarter()},  // important - not urgent
                {"NU", new TodoQuarter()},  // not important - urgent
                {"NN", new TodoQuarter()}   // not important - not urgent
            };
        }
        public Dictionary<string, TodoQuarter> GetQuarters() {
            return TodoQuarters;
        }
        public TodoQuarter GetQuarter(string status) {
            return TodoQuarters[status];
        }
        public void AddItem(string Title, DateTime DeadLine, bool IsImportant = false) {
            if(IsImportant == false) {
                if((DeadLine - DateTime.Now).TotalHours <= 72) {
                    TodoQuarters["NU"].AddItem(Title, DeadLine);
                    DatabaseCrud.AddTaskToDatabase("UrgentNotImportant", Title, DeadLine);
                } else {
                    TodoQuarters["NN"].AddItem(Title, DeadLine);
                    DatabaseCrud.AddTaskToDatabase("NotUrgentNotImportant", Title, DeadLine);
                }
            } else {
                if((DeadLine - DateTime.Now).TotalHours <= 72) {
                    TodoQuarters["IU"].AddItem(Title, DeadLine);
                    DatabaseCrud.AddTaskToDatabase("UrgentImportant", Title, DeadLine);
                } else {
                    TodoQuarters["IN"].AddItem(Title, DeadLine);
                    DatabaseCrud.AddTaskToDatabase("NotUrgentImportant", Title, DeadLine);
                }
            }
        }
    }
}