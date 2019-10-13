using System;
using System.Windows.Controls;
using EnglishWords.ViewModels;

namespace EnglishWords.Views.Controls
{
    /// <summary>
    /// Логика взаимодействия для AddElementControl.xaml
    /// </summary>
    public partial class EditingElements : UserControl
    {
        public EditingElements()
        {
            DataContext = new EditingElementsViewModel();
            InitializeComponent();
        }
    }
}
 