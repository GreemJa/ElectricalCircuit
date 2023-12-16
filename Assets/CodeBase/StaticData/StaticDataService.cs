using System.Collections.Generic;
using System.Linq;
using CodeBase.StaticData.Windows;
using CodeBase.UI.Services.Windows;
using UnityEngine;

namespace CodeBase.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private const string WindowsStaticDataPath = "StaticData/UI/WindowStaticData";

        private Dictionary<WindowId, WindowConfig> _windowConfigs;

        public void LoadStaticData()
        {
            _windowConfigs = Resources.Load<WindowStaticData>(WindowsStaticDataPath).Configs.ToDictionary(x => x.WindowId, x => x);
        }

        public WindowConfig ForWindow(WindowId windowId) =>
            _windowConfigs.TryGetValue(windowId, out WindowConfig windowConfig)
                ? windowConfig
                : null;
    }
}