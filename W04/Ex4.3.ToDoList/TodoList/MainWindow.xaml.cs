using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace TodoList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // data binding works only for properties: (so not just a field, here)
        public ObservableCollection<TodoItem> TodoItems { get; set; }

        // get the number of undone items using linq or 0 (if collection is not set/null)
        public int OpenItems => TodoItems?.Count(x => !x.IsDone) ?? 0;


        public MainWindow()
        {
            InitializeComponent();

            InitItems();

            // set the data context, e.g. to this item
            // (would typically be set from outside, see week 7)
            DataContext = this;
        }

        // set up some test data
        private void InitItems()
        {
            TodoItems = new ObservableCollection<TodoItem>();
            TodoItems.Add(new TodoItem("Übung 1 erledigen", DateTime.Now.AddDays(-28), true)); // done
            TodoItems.Add(new TodoItem("Übung 2 erledigen", DateTime.Now.AddDays(-21), true)); // done
            TodoItems.Add(new TodoItem("Übung 3 erledigen", DateTime.Now.AddDays(-14), true)); // done
            TodoItems.Add(new TodoItem("Übung 4 erledigen", DateTime.Now.AddDays(-7))); // overdue
            TodoItems.Add(new TodoItem("Übung 5 erledigen", DateTime.Now.AddDays(1))); // by tomorrow
            TodoItems.Add(new TodoItem("Miniprojekt fertigstellen", DateTime.Now.AddDays(14))); // in 2 weeks
            TodoItems.Add(new TodoItem("Stoff repetieren", DateTime.Now.AddMonths(2))); // in 2 months
        }
    }
}
