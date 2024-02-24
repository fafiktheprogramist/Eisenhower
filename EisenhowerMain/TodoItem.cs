using System;

namespace EisenhowerCore {
    public class TodoItem
    {
        public string Title { get; private set; }
        public DateTime Deadline { get; private set; }
        public bool IsDone { get; private set; }

        public TodoItem(string Title, DateTime Deadline) {
            // check if datetime is in the past or today EX.1.2
            if (!(Deadline < DateTime.Now) || Deadline != DateTime.Now)
            {
                this.Title = Title;
                this.Deadline = Deadline;
                IsDone = false;
            }
            else { throw new ArgumentException("Deadline must be in future"); }
        }

        public DateTime GetDeadLine() {
            return Deadline;
        }
        public string GetTitle() {
            return Title;
        }
        public void Mark() {
            IsDone = true;
        }
        public void Unmark() {
            IsDone = false;
        }
        public override string ToString() {
            string FormattedDeadLine = Deadline.ToString("dd-MM");
            string status = IsDone ? "[x]" : "[]";
            return $"{status} {FormattedDeadLine} {Title}";
        }
    }
}