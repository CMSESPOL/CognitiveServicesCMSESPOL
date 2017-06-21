using AppCognitive.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace AppCognitive
{
    public partial class App : Application
    {
        public static NavigationPage Navigator { get; internal set; }
        public static CognitiveMDP Master { get; internal set; }

        public App()
        {
            InitializeComponent();
            MainPage = new CognitiveMDP();
            //MainPage = new NavigationPage(new Views.CognitiveMDP());
            //MainPage = new NavigationPage(new Views.CognitiveView());
            //MainPage = new AppCognitive.MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
