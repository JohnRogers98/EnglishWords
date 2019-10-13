using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EnglishWords.Models
{
    public sealed class SectionObject : INotifyPropertyChanged
    {
        public Int32 Id { get; set; }

        private String section;
        [Required]
        public String Section 
        {
            get { return section; }
            set { section = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Section"));
            } 
        }

        private String sectionTranslate;
        [Required]
        public String SectionTranslate 
        {
            get { return sectionTranslate; }
            set { sectionTranslate = value;
                OnPropertyChanged(new PropertyChangedEventArgs("SectionTranslate"));
            } 
        }
        public List<WordObject> WordObjects { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, e);
        }

        public override String ToString()
        {
            return Section;
        }
    }
}
