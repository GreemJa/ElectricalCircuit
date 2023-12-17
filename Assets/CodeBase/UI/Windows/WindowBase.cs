using CodeBase.Data;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.Infrastructure.States;
using CodeBase.StaticData;
using CodeBase.UI.Services.Windows;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Windows
{
    public abstract class WindowBase : MonoBehaviour
    {
        protected IPersistentProgressService _progressService;
        protected IGameStateMachine _gameStateMachine;
        protected IStaticDataService _staticData;
        protected PlayerProgress Progress => _progressService.Progress;
        
        public void Construct(IPersistentProgressService progressService, IGameStateMachine gameStateMachine, IStaticDataService staticData)
        {
            _progressService = progressService;
            _gameStateMachine = gameStateMachine;
            _staticData = staticData;
        }

        private void Awake() => 
            OnAwake();

        private void Start()
        {
            Initialize();
            SubscribeUpdates();
        }

        private void OnDestroy() => 
            CleanUp();

        protected abstract void OnAwake();

        protected abstract void Initialize();

        protected abstract void SubscribeUpdates();

        protected abstract void CleanUp();
    }
}