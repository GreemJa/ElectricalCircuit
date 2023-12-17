using System.Collections.Generic;
using CodeBase.Logic;
using CodeBase.StaticData.Device;
using UnityEngine;

namespace CodeBase.StaticData.Levels
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "StaticData/Level")]
    public class LevelStaticData : ScriptableObject
    {
        public string LevelKey;
        public List<DeviceSpawnerData> EnemySpawners = new();
        public Sprite ContentSprite;
    }
}