using CodeBase.StaticData.Device;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Elements
{
    public class Device : MonoBehaviour
    {
        public GameObject Background;
        public Image Icon;
        
        public DeviceState DeviceState
        {
            get => _deviceState;
            set
            {
                _deviceState = value;
                OnStateChanged();
            }
        }

        private DeviceState _deviceState;
        private DeviceConfig _deviceConfig;

        public void Initialize(DeviceState deviceState, DeviceConfig deviceConfig)
        {
            DeviceState = deviceState;
            _deviceConfig = deviceConfig;
        }

        void OnStateChanged()
        {
            Icon.sprite = _deviceConfig.Sprite;
            Icon.gameObject.SetActive(_deviceState == DeviceState.Filled || _deviceState == DeviceState.Сonnected);
            Background.SetActive(_deviceState != DeviceState.Сonnected);
        }
    }
}