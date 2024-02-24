using System;
using System.Collections.Generic;

namespace EisenhowerCore {
    public class EisenhowerMain {
        static public void Main(string[] args) {
            bool IsRunning = true;
            TodoMatrix TasksBoard = new TodoMatrix();
            while(IsRunning) {
                Console.WriteLine("Witajcie w matrycy Eisehowera...");
                Console.Write("1.Dodaj zadanie. \n2.Wyswietl wszystkie zadania. \n3.Oznacz zadanie jako wykonane/nie wykonane. \n4.Usuń zadanie z listy zadań. \n5.Wyście. \nWybierz numer odpowiadający temu, co chcesz zrobić: ");
                string option = Console.ReadLine();
                switch(option) {
                    case "1":
                        string Title;
                        string InputDeadLine;
                        bool IsImportant = false;

                        Console.Write("Podaj nazwę zadania: ");
                        Title = Console.ReadLine();

                        bool ValidDeadLine = false;
                        DateTime DeadLine = DateTime.MinValue;
                        while(!ValidDeadLine) {
                            Console.Write("Podaj termin ważności (dd-mm):");
                            InputDeadLine = Console.ReadLine();
                            if(DateTime.TryParse(InputDeadLine, out DeadLine)) {
                                ValidDeadLine = true;
                            } else {
                                Console.WriteLine("Niepoprawny format daty!");
                            }
                        }

                        bool ValidIsImportant = false;
                        while(!ValidIsImportant) {
                            Console.Write("Czy to zadanie ma mieć status ważnego (tak/nie): ");
                            string InputIsImportant = Console.ReadLine();
                            
                            if(InputIsImportant == "tak" || InputIsImportant == "nie") {
                                IsImportant = true ? InputIsImportant == "tak" : false;
                                ValidIsImportant = true;
                            } else {
                                Console.WriteLine("Niepoprawne dane!");
                            }
                        }
                        
                        TasksBoard.AddItem(Title, DeadLine, IsImportant);
                        Console.WriteLine("Pomyślnie dodano zadanie do listy!");
                        break;

                        case "2":
                            Console.Clear();
                            foreach(KeyValuePair<string, TodoQuarter> Quarter in TasksBoard.GetQuarters()) {
                                Console.WriteLine($"{Quarter.Key}:");
                                foreach(string Item in Quarter.Value.ToList()) {
                                    Console.WriteLine(Item);
                                };
                                Console.WriteLine("");
                            }
                            break;
                    case "3":
                        Console.Write("Podaj ćwiartkę w której chcesz odznaczyć/zaznaczyć zadanie (IU | IN | NU  | NN): ");
                        string QuarterInputMark = Console.ReadLine().ToUpper();
                        if(TasksBoard.GetQuarters().ContainsKey(QuarterInputMark)) {
                            TodoQuarter SelectedQuarter = TasksBoard.GetQuarter(QuarterInputMark);
                            List<string> QuarterTasks = SelectedQuarter.ToList();
                            Console.WriteLine("Wszytskie zadania w podanej ćwiartce: ");
                            for(int ItemNumber = 0; ItemNumber < QuarterTasks.Count; ItemNumber++) {
                                Console.WriteLine($"{ItemNumber +1}. {QuarterTasks[ItemNumber]}");
                            }
                            Console.Write("Podaj numer zadania które chcesz odznaczyć/zaznaczyć: ");
                            int ItemIndex = Convert.ToInt32(Console.ReadLine());
                            if(ItemIndex -1 >= 0 && ItemIndex -1 <= QuarterTasks.Count) {
                                TodoItem SelectedItem = SelectedQuarter.GetItem(ItemIndex -1);
                                if(SelectedItem.IsDone == true) {
                                    SelectedItem.Unmark();
                                    Console.WriteLine("Pomyślnie oznaczono zadanie jako nie wykonane!");
                                } else {
                                    SelectedItem.Mark();
                                    Console.WriteLine("Pomyślnie zaznaczono zadanie jako wykonane!");
                                }
                            } else {
                                Console.WriteLine("Nie ma takiego zadania!");
                            }
                        } else {
                            Console.WriteLine("Nie ma tekiej ćwiartki!");
                        }
                        break;
                    case "4":
                        Console.Write("Podaj ćwiartkę w której chcesz usunąć zadanie (IU | IN | NU  | NN): ");
                        string QuarterInputDelete = Console.ReadLine().ToUpper();
                        if (TasksBoard.GetQuarters().ContainsKey(QuarterInputDelete)) {
                            TodoQuarter SelectedQuarter = TasksBoard.GetQuarter(QuarterInputDelete);
                            List<string> QuarterTasks = SelectedQuarter.ToList();
                            Console.WriteLine("Wszytskie zadania w podanej ćwiartce: ");
                            for (int ItemNumber = 0; ItemNumber < QuarterTasks.Count; ItemNumber++) {
                                Console.WriteLine($"{ItemNumber + 1}. {QuarterTasks[ItemNumber]}");
                            }
                            Console.Write("Podaj numer zadania które chcesz usunąć: ");
                            int ItemIndex = Convert.ToInt32(Console.ReadLine());
                            if (ItemIndex - 1 >= 0 && ItemIndex - 1 <= QuarterTasks.Count) {
                                SelectedQuarter.RemoveItem(ItemIndex - 1);
                                Console.WriteLine("Pomyślnie usunięto zadanie.");
                            } else {
                                Console.WriteLine("Nie ma takiego zadania!");
                            }
                        } else {
                            Console.WriteLine("Nie ma tekiej ćwiartki!");
                        }
                        break;
                    case "5":
                        IsRunning = false;
                        break;
                }
            }
        }
    }
}
