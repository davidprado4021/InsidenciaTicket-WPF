using Proyecto01_InsidenciaTicket.Commands;
using Proyecto01_InsidenciaTicket.Conexion.DataBase;
using Proyecto01_InsidenciaTicket.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Proyecto01_InsidenciaTicket.ViewModel
{
    internal class UserViewModel : ViewModelBase
    {
       private readonly SqlConn BD;
       private ObservableCollection<Users> _users;
       private Users _user;

        public UserViewModel()
        {
           BD= new SqlConn();
           _user = new Users();
           _users = BD.ViewUserDB();
        }

        public Users User
        { 
          get => _user;
            set 
            { 
               if (_user != value)
               {
                    _user = value;
                    OnPropertyChanged(nameof(User));
               }
            }
        }

        public ICommand AddCommand
        {
            get 
            {
                return new RelayCommand<object>(AddExecute, AddCanExecute);
            }
        }

        public ObservableCollection<Users> Users 
        {
            get => _users;
            set 
            {
                if (_users != value)
                { 
                    _users = value;
                    OnPropertyChanged(nameof(Users));
                }
            }
        }
        private void AddExecute(Object user)
        {
            BD.AddUserDB(User);
            Users = BD.ViewUserDB();
        }

        private bool AddCanExecute(Object user) 
        {
        return true;
        }
    }
}