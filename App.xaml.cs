using Zadania.Themes;

namespace Zadania
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
        public void ChangeTheme(bool isDarkTheme)

        {

            // Pobieramy MergedDictionaries z zasobów aplikacji 

            ICollection<ResourceDictionary> mergedDictionaries = Resources.MergedDictionaries;



            if (mergedDictionaries != null)

            {

                // Czyścimy obecny motyw 

                mergedDictionaries.Clear();



                // Dodajemy nowy motyw 

                if (isDarkTheme)

                {

                    mergedDictionaries.Add(new DarkTheme());

                }

                else

                {

                    mergedDictionaries.Add(new LightTheme());

                }

            }
        }
    }
}
