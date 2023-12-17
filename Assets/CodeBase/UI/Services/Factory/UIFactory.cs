using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.Infrastructure.States;
using CodeBase.Logic;
using CodeBase.StaticData;
using CodeBase.StaticData.Device;
using CodeBase.StaticData.Windows;
using CodeBase.UI.Elements;
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
        private readonly IGameStateMachine _stateMachine;

        public UIFactory(IAssetProvider assetProvider, IStaticDataService staticData,
            IPersistentProgressService progressService, IGameStateMachine stateMachine)
        {
            _assetProvider = assetProvider;
            _staticData = staticData;
            _progressService = progressService;
            _stateMachine = stateMachine;
        }

        public void CreateUIRoot() =>
            UIRoot = _assetProvider.Instantiate(AssetPath.UIRootPath).transform;

        public void CreateMenu(IWindowService windowService)
        {
            WindowConfig config = _staticData.ForWindow(WindowId.Menu);
            WindowBase window = Object.Instantiate(config.Prefab, UIRoot);
            window.Construct(_progressService, _stateMachine, _staticData);

            foreach (OpenWindowButton button in window.GetComponentsInChildren<OpenWindowButton>())
            {
                button.Construct(windowService);
            }

            Debug.Log($"Progress = {_progressService.Progress.GameData.Level}");
        }

        public void CreateInProgress()
        {
            WindowConfig config = _staticData.ForWindow(WindowId.InProgress);
            WindowBase window = Object.Instantiate(config.Prefab, UIRoot);
            window.Construct(_progressService, _stateMachine, _staticData);
        }

        public void CreateGameplayWindow()
        {
            WindowConfig config = _staticData.ForWindow(WindowId.Gameplay);
            WindowBase window = Object.Instantiate(config.Prefab, UIRoot);
            window.Construct(_progressService, _stateMachine, _staticData);
        }

        public void CreateDeviceSpawners(Transform at, DeviceTypeId deviceTypeId, DeviceState deviceState)
        {
            DeviceSpawner spawner =
                _assetProvider.Instantiate(AssetPath.DeviceSpawner, at).GetComponent<DeviceSpawner>();
            spawner.DeviceTypeId = deviceTypeId;
            spawner.DeviceState = deviceState;
        }
    }
}