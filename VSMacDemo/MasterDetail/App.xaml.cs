﻿using System.Collections.Generic;

using Xamarin.Forms;

namespace MasterDetail
{
    public partial class App : Application
    {
        public static bool UseMockDataStore = false;
        //public static string BackendUrl = "https://masterdetail-mobileappservice.azurewebsites.net";
        public static string BackendUrl = "http://localhost:60372";
        public static IDictionary<string, string> LoginParameters => null;

        public App()
        {
            InitializeComponent();

            if (UseMockDataStore)
                DependencyService.Register<MockDataStore>();
            else
                DependencyService.Register<CloudDataStore>();

            SetMainPage();
        }

        public static void SetMainPage()
        {
            /*if (!UseMockDataStore && !Settings.IsLoggedIn)
            {
                Current.MainPage = new NavigationPage(new LoginPage())
                {
                    BarBackgroundColor = (Color)Current.Resources["Primary"],
                    BarTextColor = Color.White
                };
            }
            else
            {*/
                GoToMainPage();
            //}
        }

        public static void GoToMainPage()
        {
            Current.MainPage = new TabbedPage
            {
                Children = {
                    new NavigationPage(new ItemsPage())
                    {
                        Title = "Browse",
                        Icon = Device.OnPlatform("tab_feed.png", null, null)
                    },
                    new NavigationPage(new AboutPage())
                    {
                        Title = "About",
                        Icon = Device.OnPlatform("tab_about.png", null, null)
                    },
                }
            };
        }
    }
}
