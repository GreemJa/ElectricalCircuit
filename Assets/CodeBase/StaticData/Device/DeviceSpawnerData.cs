using System;
using UnityEngine;

namespace CodeBase.StaticData.Device
{
    [Serializable]
    public class DeviceSpawnerData
    {
        public DeviceTypeId DeviceTypeId;
        public DeviceState DeviceState;
        public Vector3 Position;
        public Vector4 Rotation;

        public DeviceSpawnerData(DeviceTypeId deviceTypeId, DeviceState deviceState, Vector3 position, Vector4 rotation)
        {
            DeviceTypeId = deviceTypeId;
            DeviceState = deviceState;
            Position = position;
            Rotation = rotation;
        }
    }
}