using EnglishWords.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Media;
using System.Linq;
using System.Windows.Controls.Primitives;

namespace EnglishWords.ViewModels
{
    public class StudyEnglishViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private WordObject selectedWord;
        public WordObject SelectedWord
        {
            get { return selectedWord; }
            set
            {
                selectedWord = value;
                OnPropertyChanged(new PropertyChangedEventArgs("SelectedWord"));
            }
        }

        private Int32 count;
        private String translate;
        public String Translate
        {
            get { return translate; }
            set
            {
                translate = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Translate"));
            }
        }

        private Brush translateColor = Brushes.White;
        public Brush TranslateColor
        {
            get { return translateColor; }
            set
            {
                translateColor = value;
                OnPropertyChanged(new PropertyChangedEventArgs("TranslateColor"));
            }
        }

        private RelayCommand nextWord;
        public RelayCommand NextWord
        {
            get
            {
                return nextWord ??
                    new RelayCommand((obj) => 
                    {
                        if (Translate != SelectedWord.WordTranslate)
                        {
                            TranslateColor = Brushes.Red;
                            return;
                        }
                        TranslateColor = Brushes.White;
                        Translate = "";
                        count++;
                        try
                        {
                            SelectedWord = MainWindowViewModel.WordObjects.ElementAt(count);
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            count = 0;
                            SelectedWord = MainWindowViewModel.WordObjects.ElementAt(count);
                        }
                        if (Language)
                        {
                            String translate = SelectedWord.WordTranslate;
                            SelectedWord.WordTranslate = SelectedWord.Word;
                            SelectedWord.Word = translate;
                        }
                    }
                    );
            }
        }

        /// <summary>
        /// false - rus, true - eng
        /// </summary>
        private Boolean language = false;
        public Boolean Language
        {
            get { return language; }
            set
            {
                language = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Language"));
            }
        }
        private RelayCommand changeMode;
        public RelayCommand ChangeMode
        {
            get
            {
                return changeMode ??
                    new RelayCommand((obj) =>
                    {
                        if (Language)
                        {
                            Language = false;
                        }
                        else
                        {
                            Language = true;
                        }

                        String translate = SelectedWord.WordTranslate;
                        SelectedWord.WordTranslate = SelectedWord.Word;
                        SelectedWord.Word = translate;

                        TranslateColor = Brushes.Green;
                    }
                    );
            }
        }

        private RelayCommand openedPopup;
        public RelayCommand OpenedPopup
        {
            get
            {
                return openedPopup ??
                    new RelayCommand((obj) =>
                    {
                        Popup pop = (Popup)obj;
                        if (pop.IsOpen == false)
                            pop.IsOpen = true;
                        else
                            pop.IsOpen = false;
                    }
                    );
            }
        }


        public StudyEnglishViewModel()
        {
            MainWindowViewModel.WordObjects = new ObservableCollection<WordObject>(
                MainWindowViewModel.DbMethods.Context.WordObjects.ToList());
            count = 0;
            SelectedWord = MainWindowViewModel.WordObjects.ElementAt(count);
        }

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, e);
        }
    }


}
