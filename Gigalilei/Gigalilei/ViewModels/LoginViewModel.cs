﻿



namespace Gigalilei.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Xamarin.Forms;
    using views;

    public class LoginViewModel : BaseViewModel
    {
        

        #region atributes
        private string User;
        private string Password;
        private bool isRunning;
        private bool isEnabled;
        #endregion
        #region properties
        public string user
        {
            get { return this.User; }
            set { SetValue(ref User, value); }
        }
        public string password
        {
            get {return this.Password;}
            set{ SetValue(ref Password, value); }
        }
        public bool IsRunning
        {
            get { return this.isRunning; }
            set { SetValue(ref isRunning, value); }
        }
        public bool IsRemember
        {
            get;
            set;
        }
        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { SetValue(ref isEnabled, value); }
        }
        #region command
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }

        }



        private async void Login()
        {
            if (string.IsNullOrEmpty(this.user))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "error",
                    "Por favor Introduzca un usuario",
                    "Aceptar");
                return;

                this.IsRunning = true;
                this.IsEnabled = false;
            }
            
            if (string.IsNullOrEmpty(this.password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "error",
                    "Por favor Introduzca su contraseña",
                    "Aceptar");
                return;
                this.IsRunning = false;
                this.IsEnabled = false;
            }
            

            if (this.user != "12")
            {
                await Application.Current.MainPage.DisplayAlert(
                    "error",
                    "Usuario incorrecto",
                    "Aceptar");
                this.user = string.Empty;
                return;
                this.IsRunning = false;
                this.IsEnabled = false;
            }
            if (this.password != "12")
            {
                await Application.Current.MainPage.DisplayAlert(
                    "error",
                    "Contraseña incorrecta",
                    "Aceptar");
                this.password = string.Empty;
                this.IsRunning = false;
                this.IsEnabled = false;
            }
          
            if (this.user == "12" )
            {
                if (this.password == "12")
                {
                    this.user = string.Empty;
                    this.password = string.Empty;
                    this.IsRunning = false;
                    this.IsEnabled = true;
                    MainViewModel.GetInstance().Options = new OptionsViewModel(); 
                    await Application.Current.MainPage.Navigation.PushAsync(new OptionsPage());
                }
                return;
            }
            
        }
        #endregion
        #endregion

        #region constructors
        public LoginViewModel()
        {
            this.IsRemember = true;
            this.isEnabled = true;
        }
        #endregion
    }
}
