using System.Collections.Generic;
using CodeBase.Data;
using CodeBase.Infrastructure.Services;
using CodeBase.Logic;
using CodeBase.StaticData.Device;
using CodeBase.StaticData.Levels;
using CodeBase.UI.Services.Windows;
using UnityEngine;

namespace CodeBase.UI.Services.Factory
{
    public interface IUIFactory : IService
    {
        void CreateUIRoot();
        void CreateMenu(IWindowService windowService);
        void CreateInProgress();
        void CreateGameplayWindow();
        void CreateDeviceSpawners(LevelStaticData levelData);
        void CreateDevice(DeviceSpawnerData deviceData);
        void Cleanup();
    }
}
