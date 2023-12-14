namespace PassBox.Mobile
{
    public partial class App : Application
    {
        //public App()
        public App(AppShell page)
        {
            InitializeComponent();

            MainPage = page;
            //MainPage = new AppShell();
        }
    }
}
