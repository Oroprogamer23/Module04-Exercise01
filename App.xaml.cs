using Microsoft.Maui.Controls;
using Module0Exercise0.View;
using Module0Exercise0.Services;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.Maui.ApplicationModel;
using System.Diagnostics;

namespace Module0Exercise0
{
    public partial class App : Application
    {
        private const string TestUrl = "https://www.google.com";

        private readonly IServiceProvider _serviceProvider;

        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            // Initialize MainPage as AppShell to ensure Shell is ready
            MainPage = new AppShell();
            _serviceProvider = serviceProvider;
        }

        protected override async void OnStart()
        {
            var current = Connectivity.NetworkAccess;

            bool isWebsiteReachable = await IsWebsiteReachable(TestUrl);

            if (current == NetworkAccess.Internet && isWebsiteReachable)
            {
                // Use Shell navigation here instead of directly setting MainPage
                var loginPage = _serviceProvider.GetRequiredService<LoginPage>();
                await Shell.Current.GoToAsync("//LoginPage");
                Debug.WriteLine("Application Started (Online)");
            }
            else
            {
                MainPage = new OfflinePage();
                Debug.WriteLine("Application Started (Offline)");
            }
        }

        private async Task<bool> IsWebsiteReachable(string url)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(url);
                    return response.IsSuccessStatusCode;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
