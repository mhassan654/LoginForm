using System.Net;
using System.Security;
using System.Security.Principal;
using System.Threading;
using System.Windows.Input;
using LoginForm.Models;
using LoginForm.Repositories;

namespace LoginForm.ViewModels
{
    public class LoginViewModel: ViewModelBase
    {
        //fields 
        private string _username;
        private SecureString _password;
        private bool _isViewVisible =true;
        private string _errorMessage;
        private IUserRepository _userRepository;

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
          
        }

        public SecureString Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public bool IsViewVisible
        {
            get => _isViewVisible;
            set
            {
                _isViewVisible = value;
                OnPropertyChanged(nameof(IsViewVisible));
            } 
        }
        
        
        // -> Commands
        public ICommand LoginCommand { get; }
        public ICommand RecoverPasswordCommand { get; }
        public ICommand ShowPasswordCommand { get; }
        public ICommand RememberPasswordCommand { get; }
        
        // constructor
        public LoginViewModel()
        {
            _userRepository = new UserRepository();
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            RecoverPasswordCommand = new ViewModelCommand(p=>ExecuteRecoverPassworCommand("",""));
        }

        private void ExecuteRecoverPassworCommand(string username, string email)
        {
            throw new System.NotImplementedException();
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData;
            if (string.IsNullOrWhiteSpace(Username) || Username.Length < 3 || 
                Password == null || Password.Length < 3)
            {
                validData = false;
            }
            else
            {
                validData = true;
            }

            return validData;
        }

        private void ExecuteLoginCommand(object obj)
        {
            var isValidUser = _userRepository.AuthenticateUser(new NetworkCredential(Username, Password));
            if (isValidUser)
            {
                Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(Username), null);
                IsViewVisible = false;
            }
            else
            {
                ErrorMessage = "* Invalid username or password";
            }
        }
    }
}