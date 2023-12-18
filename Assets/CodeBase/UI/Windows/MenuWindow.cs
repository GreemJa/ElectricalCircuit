using CodeBase.Infrastructure.States;
using CodeBase.UI.Services.Windows;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Windows
{
    public sealed class MenuWindow : WindowBase
    {
        public Button PlayBtn;

        protected override void OnAwake() => 
            PlayBtn.onClick.AddListener(()=>_gameStateMachine.Enter<LoadLevelState,string>($"Level {_progressService.Progress.GameData.Level}"));

        protected override void Initialize()
        {
        }

        protected override void SubscribeUpdates()
        {
        }

        protected override void CleanUp()
        {
        }
    }
}