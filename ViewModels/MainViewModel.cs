using System;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using FontAwesome.Sharp;
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

        private ViewModelBase _currentChildView;
        private string _caption;
        private IconChar _icon;

        // commands
        public ICommand ShowHomeViewCommand { get; }
        public ICommand ShowCustomerViewCommand { get; }
        public ICommand ShowPOSViewCommand { get; }

        public MainViewModel()
        {
            _userRepository = new UserRepository();
            CurrentUserAccount = new UserAccountModel();
            ShowHomeViewCommand = new ViewModelCommand(ExecuteShowHomeViewCommand);
            ShowCustomerViewCommand = new ViewModelCommand(ExecuteShowCustomerViewCommand);
            ShowPOSViewCommand = new ViewModelCommand(ExecuteShowPOSViewCommand);

            // default view
           // ExecuteShowHomeViewCommand(null);
            ExecuteShowPOSViewCommand(null);
            LoadCurrentUserData();
        }

        private void ExecuteShowPOSViewCommand(object obj)
        {
            CurrentChildView=new POSViewModel();
            Caption = "POS";
            Icon = IconChar.ArrowsAlt;
        }

        private void ExecuteShowCustomerViewCommand(object obj)
        {
            CurrentChildView = new CustomerViewModel();
            Caption = "Customer";
            Icon = IconChar.UserGroup;
        }

        private void ExecuteShowHomeViewCommand(object obj)
        {
            CurrentChildView = new HomeViewModel();
            Caption = "Dashboard";
            Icon = IconChar.Home;
        }

        private void LoadCurrentUserData()
        {
            var user = _userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
            if (user != null)
            {
                CurrentUserAccount.Username ="Hassan saava"; //user.Username;
                CurrentUserAccount.DisplayName ="saava" ;// $"Welcome {user.Name} {user.LastName} ;)";
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
        
        public ViewModelBase CurrentChildView
        {
            get => CurrentChildView1;
            set
            { CurrentChildView1 = value;
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }

        public string Caption
        {
            get => Caption1;
            set
            {
                Caption1 = value;
                OnPropertyChanged(nameof(Caption));
            }
        }

        public IconChar Icon
        {
            get => Icon1;
            set
            {
                Icon1 = value; 
                OnPropertyChanged(nameof(Icon));
            }
        }

        public ViewModelBase CurrentChildView1 { get => _currentChildView; set => _currentChildView = value; }
        public string Caption1 { get => _caption; set => _caption = value; }
        public IconChar Icon1 { get => _icon; set => _icon = value; }
    }
}