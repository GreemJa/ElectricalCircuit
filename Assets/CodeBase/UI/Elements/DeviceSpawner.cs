using CodeBase.StaticData.Device;
using CodeBase.StaticData.Levels;
using CodeBase.UI.Services.Factory;
using UnityEngine;

namespace CodeBase.UI.Elements
{
    public class DeviceSpawner : MonoBehaviour
    {
        public DeviceTypeId DeviceTypeId;
        public DeviceState DeviceState;

        private IUIFactory _uiFactory;

        public void Construct(IUIFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }
        
        public void Spawn(DeviceSpawnerData deviceData)
        {
            _uiFactory.CreateDevice(deviceData);
        }
    }
}