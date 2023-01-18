using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using TestApp_Intermodular.Core;

namespace TestApp_Intermodular.MVVM.ViewModel
{
    internal class MainViewModel : ObservableObject
    {
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand DiscoveryViewCommand { get; set; }
        public RelayCommand LogInViewCommand { get; set; }
        public RelayCommand FavoritesViewCommand { get; set; }
        public RelayCommand ProfileViewCommand { get; set; }
        public RelayCommand RegisterViewCommand { get; set; }
        public RelayCommand InitialViewCommand { get; set; }


        public HomeViewModel HomeVM { get; set; }
        public LogInViewModel LogginVM { get; set; }
        public DiscoveryViewModel DiscoveryVM { get; set; }
        public ProfileViewModel ProfileVM { get; set; }
        public FavoritesViewModel FavVM { get; set; }
        public RegisterViewModel RegisterVM { get; set; }
        public InitialViewModel InitialVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set 
            { 
                _currentView = value;
                OnProppertyChanged();
            }
        }
        public MainViewModel()
        {
            HomeVM = new HomeViewModel();
            DiscoveryVM = new DiscoveryViewModel();
            LogginVM = new LogInViewModel();
            FavVM = new FavoritesViewModel();
            ProfileVM = new ProfileViewModel();
            RegisterVM = new RegisterViewModel();
            InitialVM = new InitialViewModel();

            CurrentView =InitialVM;

            HomeViewCommand = new RelayCommand(action => 
            {
                CurrentView = HomeVM;
            });
            RegisterViewCommand = new RelayCommand(action =>
            {
                CurrentView = RegisterVM;
            });
            DiscoveryViewCommand = new RelayCommand(action =>
            {
                CurrentView = DiscoveryVM;
            });
            LogInViewCommand = new RelayCommand(action =>
            {
                CurrentView = LogginVM;
            });
            FavoritesViewCommand = new RelayCommand(action =>
            {
                CurrentView = FavVM;
            });
            ProfileViewCommand = new RelayCommand(action =>
            {
                CurrentView = ProfileVM;
            });
            InitialViewCommand = new RelayCommand(action =>
            {
                CurrentView = InitialVM;
            });

        }
    }
}
