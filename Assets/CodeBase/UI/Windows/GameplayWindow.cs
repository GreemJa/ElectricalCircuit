using System.Collections.Generic;
using CodeBase.Logic;
using CodeBase.StaticData.Levels;
using CodeBase.UI.Elements;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CodeBase.UI.Windows
{
    public sealed class GameplayWindow : WindowBase
    {
        public Image ContentImage;
        private List<DeviceSpawner> _deviceSpawner = new();
        
        protected override void OnAwake()
        {
        }

        protected override void Initialize()
        {
            LevelStaticData levelData = _staticData.ForLevel(SceneManager.GetActiveScene().name);
            ContentImage.sprite = levelData.ContentSprite;
        }

        protected override void SubscribeUpdates()
        {
        }

        protected override void CleanUp()
        {
        }
    }
}