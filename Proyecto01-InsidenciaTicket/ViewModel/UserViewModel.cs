using Proyecto01_InsidenciaTicket.Commands;
using Proyecto01_InsidenciaTicket.Conexion.DataBase;
using Proyecto01_InsidenciaTicket.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows;
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
                    OnPropertyChanged(nameof(_user._username));
                    OnPropertyChanged(nameof(_user.Password)); 
                }
            }
        }
        //Agregar un Usuario a la Lista
        private void AddExecute(Object user)
        {
            BD.AddUserDB(User);
            Users = BD.ViewUserDB();
        }
        private bool AddCanExecute(Object user)
        {
            return true;
        }

        // Eliminar un Usuario de la Lista
        private void DeleteExecute(Object user)
        {
            if (user is Users selectedUser)
            {
                BD.DeleteUserDB(selectedUser);
                Users = BD.ViewUserDB();
            }
        }
        private bool DeleteCanExecute(Object user)
        {
            return user is Users;
        }

        // Actualizar un Usuario en la Lista
        private void UpdateExecute(Object user)
        {
            if (user is Users updatedUser)
            {
                BD.UpdateUserDB(updatedUser);
                Users = BD.ViewUserDB();
            }
        }
        private bool UpdateCanExecute(Object user)
        {
            return user is Users;
        }

        // Verificacion de Usuario en SQL
        private void AuthenticateExecute(object parameter)
        {
            // Verificar si el usuario y la contraseña son válidos
            if (BD.ValidateUser(_user._username, _user._password)) // Corregir _password a _passworsd
            {
                // Usuario autenticado correctamente
                // Aquí podrías navegar a la siguiente página o realizar otras acciones
                MessageBox.Show("Usuario autenticado correctamente");
            }
            else
            {
                // Usuario no autenticado
                MessageBox.Show("Nombre de usuario o contraseña incorrectos");
            }
        }
        private bool AuthenticateCanExecute(object parameter)
        {
            // Verificar si el usuario y la contraseña no están en blanco
            return !string.IsNullOrWhiteSpace(_user._username) && !string.IsNullOrWhiteSpace(_user._password);
        }

        public ICommand AuthenticateCommand
        {
            get { return new RelayCommand<object>(AuthenticateExecute, AuthenticateCanExecute); }
        }
        public ICommand AddCommand
        {
            get 
            {
                return new RelayCommand<object>(AddExecute, AddCanExecute);
            }
        }
        public ICommand DeleteCommand
        {
            get
            {
                return new RelayCommand<object>(DeleteExecute, DeleteCanExecute);
            }
        }
        public ICommand UpdateCommand
        {
            get
            {
                return new RelayCommand<object>(UpdateExecute, UpdateCanExecute);
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
    }
}