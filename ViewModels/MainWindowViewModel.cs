using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System.Linq;

namespace PrismTest2.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {

        private readonly IRegionManager regionManager;

        public DelegateCommand<string> OpenRegionCommand { get; private set; }
        public DelegateCommand<string> CloseRegionCommand { get; private set; }

        public MainWindowViewModel(IRegionManager regionManager)
        {
            OpenRegionCommand = new DelegateCommand<string>(DoOpenRegionCommand);
            CloseRegionCommand = new DelegateCommand<string>(DoCloseRegionCommand);
            this.regionManager = regionManager;
        }
        private void DoCloseRegionCommand(string obj)
        {
            var views = regionManager.Regions["MainContent"];
            var view = views.Views.FirstOrDefault(it => it.GetType().Name == obj);
            if (view != default)
            {
                views.Remove(view);
            }
        }

        private void DoOpenRegionCommand(string obj)
        {
            regionManager.Regions["MainContent"].RequestNavigate(obj);
        }
    }
}
