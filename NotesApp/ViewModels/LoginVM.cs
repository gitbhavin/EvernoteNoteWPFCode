using NotesApp.Models;
using NotesApp.ViewModels.Commands;
using NotesApp.ViewModels.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.ViewModels
{
    public class LoginVM : INotifyPropertyChanged
    {
        private Users user;
        public Users User
        {
            get { return user; }
            set
            {
                user = value;
                OnPropertyChanged("User");
            }
        }

        public RegisterCommand RegisterCommand { get; set; }
        public LoginCommand LoginCommand { get; set; }

        public event EventHandler HasLogedIn;

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public LoginVM()
        {
            User = new Users();
            RegisterCommand = new RegisterCommand(this);
            LoginCommand = new LoginCommand(this);
         
        }

        public void Login()
        {
            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(DatabaseHelper.dbFile))
            {
                connection.CreateTable<Users>();

                var user = connection.Table<Users>().Where(u => u.UsertName == User.UsertName).FirstOrDefault();

                if (user != null)
                {
                    if(user.Password == User.Password)
                    {
                        App.UserId = System.Convert.ToString(user.Id);
                        HasLogedIn.Invoke(this, new EventArgs());
                    }
                }
            }
        }

        public void Register()
        {
            bool result = DatabaseHelper.Insert(User);
            if (result)
            {
                App.UserId = System.Convert.ToString(User.Id);
                HasLogedIn.Invoke(this, new EventArgs());
            }
           
        }
    }
}
