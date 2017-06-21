using AppCognitive.Views;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AppCognitive.ViewModel
{
    public class MenuItemVM
    {
        public string Icon { get; set; }
        public string Title { get; set; }
        public string PageName { get; set; }

        public ICommand NavigateCommand
        {
            get { return new RelayCommand(Navigate); }
        }

        private void Navigate()
        {
            App.Master.IsPresented = false;
            switch (PageName)
            {
                case "NewCapturePage":
                    App.Navigator.PushAsync(new NewCapturePage());
                    break;
                case "UsPage":
                    App.Navigator.PushAsync(new UsPage());
                    break;
                default:
                    break;
            }
        }
    }
}
