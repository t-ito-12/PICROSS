using CreatePICROSS.ViewModels;

namespace CreatePICROSS
{
    public partial class MainPage : ContentPage
    {
        private MainPageViewModel ViewModel { get; set; }

        public MainPage()
        {
            InitializeComponent();
            ViewModel = new MainPageViewModel();
            this.BindingContext = ViewModel;
            this.MainLayout.Add(ViewModel.Page);
        }

    }
}