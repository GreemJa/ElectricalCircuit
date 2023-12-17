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
            throw new System.NotImplementedException();
        }

        protected override void SubscribeUpdates()
        {
            throw new System.NotImplementedException();
        }

        protected override void CleanUp()
        {
            throw new System.NotImplementedException();
        }
    }
}