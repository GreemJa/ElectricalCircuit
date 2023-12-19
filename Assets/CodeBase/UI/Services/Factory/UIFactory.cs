using System.Collections.Generic;
using CodeBase.Data;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.Infrastructure.Services.SaveLoad;
using CodeBase.Infrastructure.States;
using CodeBase.Logic;
using CodeBase.StaticData;
using CodeBase.StaticData.Device;
using CodeBase.StaticData.Levels;
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
        private readonly ISaveLoadProgressService _saveLoadProgressService;

        public UIFactory(IAssetProvider assetProvider, IStaticDataService staticData,
            IPersistentProgressService progressService, IGameStateMachine stateMachine, ISaveLoadProgressService saveLoadProgressService)
        {
            _assetProvider = assetProvider;
            _staticData = staticData;
            _progressService = progressService;
            _stateMachine = stateMachine;
            _saveLoadProgressService = saveLoadProgressService;
        }

        public void CreateUIRoot() =>
            UIRoot = _assetProvider.Instantiate(AssetPath.UIRootPath).transform;

        public void CreateMenuWindow(IWindowService windowService)
        {
            WindowConfig config = _staticData.ForWindow(WindowId.Menu);
            WindowBase window = Object.Instantiate(config.Prefab, UIRoot);
            window.Construct(_progressService, _stateMachine, this, _saveLoadProgressService);

            foreach (OpenWindowButton button in window.GetComponentsInChildren<OpenWindowButton>())
                button.Construct(windowService);
        }

        public void CreateInProgressWindow()
        {
            WindowConfig config = _staticData.ForWindow(WindowId.InProgress);
            WindowBase window = Object.Instantiate(config.Prefab, UIRoot);
            
            window.Construct(_progressService, _stateMachine, this, _saveLoadProgressService);
        }

        public void CreateGameplayWindow(LevelStaticData levelData, IWindowService windowService)
        {
            WindowConfig config = _staticData.ForWindow(WindowId.Gameplay);
            GameplayWindow window = Object.Instantiate(config.Prefab, UIRoot).GetComponent<GameplayWindow>();
            
            window.Construct(_progressService, _stateMachine, this, _saveLoadProgressService, windowService);
            window.Initialize(levelData);
        }

        public void CreateWinWindow()
        {
            WindowConfig config = _staticData.ForWindow(WindowId.WinWindow);
            WinWindow window = Object.Instantiate(config.Prefab, UIRoot).GetComponent<WinWindow>();
            
            window.Construct(_progressService, _stateMachine, this, _saveLoadProgressService);
        }

        public void CreateLoseWindow()
        {
            WindowConfig config = _staticData.ForWindow(WindowId.LoseWindow);
            WindowBase window = Object.Instantiate(config.Prefab, UIRoot);
            
            window.Construct(_progressService, _stateMachine, this, _saveLoadProgressService);
        }

        public void CreateDeviceSpawners(LevelStaticData levelData, Transform parent)
        {
            foreach (DeviceSpawnerData spawnerData in levelData.DeviceSpawners)
            {
                DeviceSpawner spawner = _assetProvider.Instantiate(AssetPath.DeviceSpawnerPath, spawnerData.TransformData, parent).GetComponent<DeviceSpawner>();
                spawner.Construct(this);
                spawner.Initialize(spawnerData.DeviceTypeId, spawnerData.DeviceState, spawnerData.CorrectDeviceTypes);
                spawner.Spawn(spawnerData, spawner.transform);
            }
        }

        public void CreateDevice(DeviceSpawnerData spawnerData, Transform parent)
        {
            Device device = _assetProvider
                .Instantiate(AssetPath.DevicePath, parent)
                .GetComponent<Device>();

            device.Construct(_staticData);
            device.Initialize(spawnerData.DeviceTypeId, spawnerData.DeviceState);
        }

        public void CreateInventoryItems(LevelStaticData levelData, Transform parent)
        {
            foreach (InventoryItemsData itemsData in levelData.InventoryItems)
            {
                UnifiedInventoryItems items = _assetProvider
                    .Instantiate(AssetPath.UnifiedInventoryItemsPath, parent)
                    .GetComponent<UnifiedInventoryItems>();

                items.Initialize(itemsData.Count, _staticData.ForDevice(itemsData.DeviceTypeId));
            }
        }

        public void Cleanup()
        {
        }
    }
}