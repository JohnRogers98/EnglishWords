using System;
using System.Windows.Controls;

namespace EnglishWords.Views.Controls
{
    /// <summary>
    /// Логика взаимодействия для StudyEnglish.xaml
    /// </summary>
    public partial class StudyEnglish : UserControl
    {
        public StudyEnglish()
        {
            InitializeComponent();
            DataContext = new ViewModels.StudyEnglishViewModel();
        }
    }
}
