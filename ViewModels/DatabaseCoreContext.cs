using EnglishWords.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace EnglishWords.ViewModels
{
    public class DatabaseViewModel : DbContext
    {
        public DbSet<WordObject> WordObjects { get; set; }
        public DbSet<MemberObject> MemberObjects { get; set; }
        public DbSet<SectionObject> SectionObjects { get; set; }

        public DatabaseViewModel()
        {
            Database.EnsureCreated();
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;UserId=root;Password=root;database=english_words;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }

    public class DatabaseMethods
    {
        public DatabaseViewModel Context { get; set; }
        public DatabaseMethods(DatabaseViewModel context)
        {
            Context = context;
        }

        private void AddMembers()
        {
            Context.MemberObjects.Add(new MemberObject() { Member = "Subject", MemberTranslate = "Подлежащее" });
            Context.MemberObjects.Add(new MemberObject() { Member = "Predicate", MemberTranslate = "Сказуемое" });
            Context.MemberObjects.Add(new MemberObject() { Member = "Object", MemberTranslate = "Дополнение" });
            Context.MemberObjects.Add(new MemberObject() { Member = "Attribute", MemberTranslate = "Определение" });
            Context.MemberObjects.Add(new MemberObject() { Member = "Adverbial modifier", MemberTranslate = "Обстоятельство" });
            Context.SaveChanges();
        }

        public async void AddWord(WordObject word)
        {
            await Context.WordObjects.AddAsync(word);
            await Context.SaveChangesAsync();
        }

        public async void AddSection(SectionObject word)
        {
            await Context.SectionObjects.AddAsync(word);
            await Context.SaveChangesAsync();
        }

        public void InitialAllCollectionFromDatabase(out ObservableCollection<WordObject> wordObjects,
            out ObservableCollection<MemberObject> memberObjects,
            out ObservableCollection<SectionObject> sectionObjects)
        {
            wordObjects = new ObservableCollection<WordObject>(Context.WordObjects.ToList());
            memberObjects = new ObservableCollection<MemberObject>(Context.MemberObjects.ToList());
            sectionObjects = new ObservableCollection<SectionObject>(Context.SectionObjects.ToList());
        }
        public void InitialCollectionWordsFromDatabase(out ObservableCollection<WordObject> wordObjects)
        {
            wordObjects = new ObservableCollection<WordObject>(Context.WordObjects.ToList());
        }
        public void InitialCollectionMembersFromDatabase(out ObservableCollection<MemberObject> memberObjects)
        {
            memberObjects = new ObservableCollection<MemberObject>(Context.MemberObjects.ToList());
        }
        public void InitialCollectionSectionsFromDatabase(out ObservableCollection<SectionObject> sectionObjects)
        {
            sectionObjects = new ObservableCollection<SectionObject>(Context.SectionObjects.ToList());
        }

    }
}
