namespace Calculator
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = base.CreateWindow(activationState);

            const int newWidth = 330;
            const int newHeight = 525;

            window.Width = newWidth;
            window.Height = newHeight;

            return window;
        }
    }
}
