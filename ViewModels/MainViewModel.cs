using System.Threading;
using System.Windows;
using LoginForm.Models;
using LoginForm.Repositories;
using LoginForm.ViewModels;

namespace LoginForm.ViewModels
{
    public class MainViewModel: ViewModelBase
    {
        //fields 
        private UserAccountModel _userAccountModel;
        private IUserRepository _userRepository;

        public MainViewModel()
        {
            _userRepository = new UserRepository();
            CurrentUserAccount = new UserAccountModel();
            LoadCurrentUserData();
        }

        private void LoadCurrentUserData()
        {
            var user = _userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
            if (user != null)
            {
                CurrentUserAccount.Username = user.Username;
                CurrentUserAccount.DisplayName = $"Welcome {user.Name} {user.LastName} ;)";
                CurrentUserAccount.ProfilePicture = null;
            }
            else
            {
                CurrentUserAccount.DisplayName="Invalid user, not logged in";
                // hide child views
                
            }
        }

        public UserAccountModel CurrentUserAccount
        {
            get => _userAccountModel;
            set
            {
                _userAccountModel = value;
                OnPropertyChanged(nameof(CurrentUserAccount));
            } 
        }
        
    }
}