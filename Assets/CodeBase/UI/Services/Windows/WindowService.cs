using CodeBase.UI.Services.Factory;
using UnityEngine;

namespace CodeBase.UI.Services.Windows
{
    public class WindowService : IWindowService
    {
        private readonly IUIFactory _uiFactory;

        public WindowService(IUIFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }

        public void Open(WindowId windowId)
        {
            switch (windowId)
            {
                case WindowId.Unknown:
                    break;
                case WindowId.Menu:
                    _uiFactory.CreateMenuWindow(this);
                    break;
                case WindowId.InProgress:
                    _uiFactory.CreateInProgressWindow();
                    break;
                case WindowId.WinWindow:
                    _uiFactory.CreateWinWindow();
                    break;
                case WindowId.LoseWindow:
                    _uiFactory.CreateLoseWindow();
                    break;
            }
        }
    }
}