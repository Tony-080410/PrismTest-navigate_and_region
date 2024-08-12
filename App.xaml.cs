using Prism.Ioc;
using PrismTest2.Views;
using System.Windows;

namespace PrismTest2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<RegionFirstView>();
            containerRegistry.RegisterForNavigation<RegionSecondView>();
        }
    }
}
