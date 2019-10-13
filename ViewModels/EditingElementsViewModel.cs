using EnglishWords.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace EnglishWords.ViewModels
{
    public class EditingElementsViewModel : INotifyPropertyChanged
    {
        private WordObject newWord;
        public WordObject NewWord {
            get { return newWord ?? (newWord = new WordObject()); }
            set { newWord = value;
                OnPropertyChanged(new PropertyChangedEventArgs("NewWord"));
            } 
        }

        private SectionObject newSection;
        public SectionObject NewSection
        {
            get { return newSection ?? (newSection = new SectionObject()); }
            set
            {
                newSection = value;
                OnPropertyChanged(new PropertyChangedEventArgs("NewSection"));
            }
        }

        private RelayCommand addWordCommand;
        public RelayCommand AddWordCommand
        {
            get
            {
                if (addWordCommand != null)
                    return addWordCommand;
                return addWordCommand = new RelayCommand(
                    (obj) => 
                    {
                        MainWindowViewModel.WordObjects.Add(NewWord);
                        MainWindowViewModel.DbMethods.AddWord(NewWord);
                        NewWord = new WordObject();
                    },
                    (obj) =>
                    {
                    if (NewWord.Word != "" && NewWord.Word != null && NewWord.WordTranslate != "" && NewWord.WordTranslate != null &&
                        NewWord.MemberObject != null && NewWord.SectionObject != null)
                            return true;
                        return false;
                    }
                    );
            }
        }

        private RelayCommand addSectionCommand;
        public RelayCommand AddSectionCommand
        {
            get
            {
                if (addSectionCommand != null)
                    return addSectionCommand;
                return addSectionCommand = new RelayCommand(
                    (obj) =>
                    {
                        MainWindowViewModel.SectionObjects.Add(NewSection);
                        MainWindowViewModel.DbMethods.AddSection(NewSection);
                        NewSection = new SectionObject();
                    },
                    (obj) =>
                    {
                        if (NewSection.Section != "" && NewSection.SectionTranslate != "" && NewSection.Section != null
                        && NewSection.SectionTranslate != null)
                            return true;
                        return false;
                    }
                    );
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public DatabaseViewModel Database { get; set; }
        


        private void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, e);
        }
    }
}
