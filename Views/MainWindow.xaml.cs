using System;
using System.Windows;

namespace EnglishWords.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            new ViewModels.MainWindowViewModel(this);
        }
    }
}
