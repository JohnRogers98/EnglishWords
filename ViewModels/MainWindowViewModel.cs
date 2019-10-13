using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using EnglishWords.Models;
using EnglishWords.Views;
using EnglishWords.Views.Controls;

namespace EnglishWords.ViewModels
{
    public class MainWindowViewModel
    {
        private MainWindow Window { get; set; }
        private DatabaseViewModel DbViewModel { get; set; }
        public static DatabaseMethods DbMethods { get; set; }

        private static ObservableCollection<WordObject> wordObjects; 
        public static ObservableCollection<WordObject> WordObjects { get { return wordObjects; }
            set { wordObjects = value; } 
        }

        private static ObservableCollection<MemberObject> memberObjects;
        public  static ObservableCollection<MemberObject> MemberObjects { get { return memberObjects; } 
            set { memberObjects = value; } 
        }

        private static ObservableCollection<SectionObject> sectionObjects;
        public static ObservableCollection<SectionObject> SectionObjects { get { return sectionObjects; }
            set { sectionObjects = value; }
        }

        private static EditingElements EditingElementControl { get; set; }
        private static StudyEnglish StudyEnglishControl { get; set; }

        public MainWindowViewModel(MainWindow window)
        {
            Window = window;
            DbViewModel = new DatabaseViewModel();
            DbMethods = new DatabaseMethods(DbViewModel);

            DbMethods.InitialAllCollectionFromDatabase(out wordObjects, out memberObjects, out sectionObjects);

            EditingElementControl = new EditingElements();
            Window.MainGrid.Children.Add(EditingElementControl);
            StudyEnglishControl = new StudyEnglish();
            Window.MainGrid.Children.Add(StudyEnglishControl);
            StudyEnglishControl.Visibility = System.Windows.Visibility.Hidden;
        }

        private static RelayCommand remodeScreen;
        public static RelayCommand RemodeScreen
        {
            get
            {
                return remodeScreen ?? new RelayCommand(
                    (obj) =>
                    {
                        if (EditingElementControl.Visibility == System.Windows.Visibility.Visible)
                        {
                            EditingElementControl.Visibility = System.Windows.Visibility.Hidden;
                            StudyEnglishControl.Visibility = System.Windows.Visibility.Visible;
                            return;
                        }
                        EditingElementControl.Visibility = System.Windows.Visibility.Visible;
                        StudyEnglishControl.Visibility = System.Windows.Visibility.Hidden;
                    });
            }
        }

    }
}
