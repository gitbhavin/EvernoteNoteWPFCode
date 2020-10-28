using NotesApp.Models;
using NotesApp.ViewModels.Commands;
using NotesApp.ViewModels.Helpers;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.ViewModels
{
    public class NotesVM : INotifyPropertyChanged
    {

        private bool isEditing;

        public bool IsEditing
        {
            get { return isEditing; }
            set
            {
                isEditing = value;
                OnPropertyChanged("IsEditing");
            }
        }

        private bool isNoteEditing;

        public bool IsNoteEditing
        {
            get { return isNoteEditing; }
            set
            {
                isNoteEditing = value;
                OnPropertyChanged("IsNoteEditing");
            }
        }

        //private ObservableCollection<NoteBook> noteBooks;
        //public ObservableCollection<NoteBook> Notebooks
        //{
        //    get
        //    {
        //        return noteBooks;
        //    }
        //    set
        //    {
        //        noteBooks = value;
        //        OnPropertyChanged("Notebooks");
        //    }
        //}

        public ObservableCollection<NoteBook> Notebooks { get; set; }
        private NoteBook selectedNotebook;

        public NoteBook SelectedNotebook
        {
            get { return selectedNotebook; }
            set
            {
                selectedNotebook = value;
                //TODO : get notes
                OnPropertyChanged("SelectedNotebook");
                ReadNotes();
            }
        }

        private ObservableCollection<Note> notes;

        public ObservableCollection<Note> Notes
        {
            get { return notes; }
            set
            {
                notes = value;
                OnPropertyChanged("Notes");
            }
        }

        private Note selectedNote;

        public Note SelectedNote
        {
            get { return selectedNote; }
            set
            {
                selectedNote = value;
                OnPropertyChanged("SelectedNote");
                SelectedNoteChanged(this, new EventArgs());
            }
        }


        public NewNotebookCommand NewNotebookCommand { get; set; }
        public NewNoteCommand NewNoteCommand { get; set; }
        public RenameNoteBookCommand RenameNoteBookCommand { get; set; }
        public HasNotebookRenamedCommand HasNotebookRenamedCommand { get; set; }
        public RenameNoteCommand RenameNoteCommand { get; set; }
        public HasNoteRenamedCommand HasNoteRenamedCommand { get; set; }
        public DeleteNotebookCommand DeleteNotebookCommand { get; set; }
        public DeleteNoteCommand DeleteNoteCommand { get; set; }


        public event EventHandler SelectedNoteChanged;
        public NotesVM()
        {
            IsEditing = false;
            IsNoteEditing = false;

            NewNotebookCommand = new NewNotebookCommand(this);
            NewNoteCommand = new NewNoteCommand(this);
            RenameNoteBookCommand = new RenameNoteBookCommand(this);
            HasNotebookRenamedCommand = new HasNotebookRenamedCommand(this);
            DeleteNotebookCommand = new DeleteNotebookCommand(this);
            RenameNoteCommand = new RenameNoteCommand(this);
            HasNoteRenamedCommand = new HasNoteRenamedCommand(this);
            DeleteNoteCommand = new DeleteNoteCommand(this);

            Notebooks = new ObservableCollection<NoteBook>();
            Notes = new ObservableCollection<Note>();

            ReadNoteBooks();
            ReadNotes();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public void ReadNoteBooks()
        {
            using (SQLiteConnection conn = new SQLiteConnection(DatabaseHelper.dbFile))
            {
                conn.CreateTable<NoteBook>();

                //int userid = int.Parse(App.UserId);
                var notebooks = conn.Table<NoteBook>().ToList();
                Notebooks.Clear();
                if (notebooks != null)
                {
                    foreach (var notebook in notebooks)
                    {
                        Notebooks.Add(notebook);
                    }
                }

            }
        }

        public void ReadNotes()
        {
            using (SQLiteConnection conn = new SQLiteConnection(DatabaseHelper.dbFile))
            {
                if (selectedNotebook != null)
                {
                    conn.CreateTable<Note>();
                    var notes = conn.Table<Note>().Where(n => n.NotbookId == selectedNotebook.Id).ToList();
                    Notes.Clear();
                    if (notes != null)
                    {
                        foreach (var note in notes)
                        {
                            Notes.Add(note);
                        }
                    }
                }

            }
        }
        public void CreateNewNotebook()
        {
            NoteBook newNotebook = new NoteBook()
            {
                UserId = int.Parse(App.UserId),
                Name = "New NoteBook2"
            };
            DatabaseHelper.Insert(newNotebook);
            ReadNoteBooks();
        }
        public void CreateNewNote(int id)
        {
            Note newNote = new Note()
            {
                NotbookId = id,
                Title = "New Note2",
                CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now

            };
            DatabaseHelper.Insert(newNote);
            ReadNotes();
        }

        public void StartEditing()
        {
            IsEditing = true;
        }

        public void HasRenamed(NoteBook noteBook)
        {
            if (noteBook != null)
            {
                DatabaseHelper.Update(noteBook);
                IsEditing = false;
                ReadNoteBooks();
            }
        }

        public void DeleteNotebook(NoteBook noteBook)
        {
            if (noteBook != null)
            {
                DatabaseHelper.Delete(noteBook);
                Notebooks.Remove(noteBook);
                ReadNoteBooks();
            }
        }

        public void UpdateSelectedNote()
        {
            DatabaseHelper.Update(selectedNote);
        }

        public void HasNoteRenamed(Note note)
        {
            if (note != null)
            {
                DatabaseHelper.Update(note);
                IsNoteEditing = false;
                ReadNotes();
            }
        }
        public void RenameNote()
        {
            IsNoteEditing = true;
        }

        public void DeleteNote(Note note)
        {
            if (note != null)
            {
                DatabaseHelper.Delete(note);
                ReadNotes();
            }
        }
    }
}
