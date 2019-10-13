using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EnglishWords.Models
{
    public sealed class WordObject : INotifyPropertyChanged
    {
        public Int32 Id { get; set; }

        private String word;
        [Required]
        public String Word {
            get { return word; }
            set 
            {
                word = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Word"));
            } 
        }

        private String wordTranscription;
        public String WordTranscription {
            get { return wordTranscription; }
            set 
            {
                wordTranscription = value;
                OnPropertyChanged(new PropertyChangedEventArgs("WordTranscription"));
            } 
        }

        private String wordTranslate;
        [Required]
        public String WordTranslate
        {
            get { return wordTranslate; }
            set 
            {
                wordTranslate = value;
                OnPropertyChanged(new PropertyChangedEventArgs("WordTranslate"));
            } 
        }

        public Int32 MemberObjectId { get; set; }
        public MemberObject MemberObject { get; set; }
        public Int32 SectionObjectId { get; set; }
        public SectionObject SectionObject { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, e);
        }
    }
}
