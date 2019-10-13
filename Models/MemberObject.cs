using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EnglishWords.Models
{
    public sealed class MemberObject : INotifyPropertyChanged
    {
        public Int32 Id { get; set; }

        private String member;
        [Required]
        public String Member 
        {
            get { return member; }
            set {
                member = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Member"));
            } 
        }

        private String memberTranslate;
        [Required]
        public String MemberTranslate 
        {
            get 
            {
                return memberTranslate;
            }
            set 
            {
                memberTranslate = value;
                OnPropertyChanged(new PropertyChangedEventArgs("MemberTranslate"));
            } 
        }
        public List<WordObject> WordObjects { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this,e);
        }

        public override String ToString()
        {
            return Member;
        }
    }
}
