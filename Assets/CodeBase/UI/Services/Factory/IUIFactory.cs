using CodeBase.Infrastructure.Services;
using CodeBase.StaticData.Device;
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
        void CreateDeviceSpawners(Transform at, DeviceTypeId  deviceTypeId, DeviceState deviceState);
    }
}
