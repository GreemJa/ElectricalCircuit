using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.StaticData;
using CodeBase.StaticData.Windows;
using CodeBase.UI.Services.Windows;
using CodeBase.UI.Windows;
using UnityEngine;

namespace CodeBase.UI.Services.Factory
{
    public class UIFactory : IUIFactory
    {
        public Transform UIRoot;
        private readonly IAssetProvider _assetProvider;
        private readonly IStaticDataService _staticData;
        private readonly IPersistentProgressService _progressService;

        public UIFactory(IAssetProvider assetProvider, IStaticDataService staticData, IPersistentProgressService progressService)
        {
            _assetProvider = assetProvider;
            _staticData = staticData;
            _progressService = progressService;
        }

        public void CreateUIRoot() => 
            UIRoot = _assetProvider.Instantiate(AssetPath.UIRootPath).transform;

        public void CreateMenu()
        {
            WindowConfig config = _staticData.ForWindow(WindowId.Menu);
            WindowBase window = Object.Instantiate(config.Prefab, UIRoot);
            window.Construct(_progressService);
        }
    }
}