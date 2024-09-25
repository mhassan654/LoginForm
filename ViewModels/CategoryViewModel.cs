using LoginForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace LoginForm.ViewModels
{
    public class CategoryViewModel: ViewModelBase
    {
        private string _category_name;
        private string _errorCategoryMessage;
        private ICategoryRepository categoryRepository;

        public string CategoryName
        {
            get => _category_name;
            set
            {
                _category_name = value;
                OnPropertyChanged(nameof(CategoryName));
            }

        }


        // -> Commands
        public ICommand SubmitCommand { get; }

        public CategoryViewModel()
        {
            SubmitCommand = new ViewModelCommand(ExecuteSaveCommand, CanExecuteSaveCommand);
        }


        public string CategoryErrorMessage
        {
            get => _errorCategoryMessage;
            set
            {
                _errorCategoryMessage = value;
                OnPropertyChanged(nameof(CategoryErrorMessage));
            }
        }

        private bool CanExecuteSaveCommand(object obj)
        {
            bool validData;
            if (string.IsNullOrWhiteSpace(CategoryName) || CategoryName.Length < 3 )
            {
                validData = false;
            }
            else
            {
                validData = true;
            }

            return validData;
        }

        private void ExecuteSaveCommand(object obj)
        {
            //if (txtName.Text == null || txtName.Text.Trim() == "")
            //{
            //    //if amount textbox is null or blank it will show the below message box
            //    MessageBox.Show("Please Enter category name", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

            //    //after clicking on message box ok sets the focus on amount txtbox
            //    txtName.Focus();
            //    return;
            //}
            //else
            //{
            //    ErrorMessage = "* Invalid username or password";
            //}

            //var save = categoryRepository.Add(CategoryName);
        }

        public List<CategoryModel> GetAll() {
            return categoryRepository.GetByAll();
        }
    }
}
