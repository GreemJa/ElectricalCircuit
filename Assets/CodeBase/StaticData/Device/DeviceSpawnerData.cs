using System;
using CodeBase.Data;
using UnityEngine;

namespace CodeBase.StaticData.Device
{
    [Serializable]
    public class DeviceSpawnerData
    {
        public DeviceTypeId DeviceTypeId;
        public DeviceState DeviceState;
        public TransformData TransformData;

        public DeviceSpawnerData(DeviceTypeId deviceTypeId, DeviceState deviceState, TransformData transformData)
        {
            DeviceTypeId = deviceTypeId;
            DeviceState = deviceState;
            TransformData = transformData;
        }
    }
}