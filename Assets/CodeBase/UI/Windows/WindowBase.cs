using CodeBase.Data;
using CodeBase.Infrastructure.Services.PersistentProgress;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Windows
{
    public abstract class WindowBase : MonoBehaviour
    {
        protected IPersistentProgressService _progressService;
        protected PlayerProgress Progress => _progressService.Progress;
        
        public void Construct(IPersistentProgressService progressService) => 
            _progressService = progressService;

        private void Awake() => 
            OnAwake();

        private void Start()
        {
            Initialize();
            SubscribeUpdates();
        }

        private void OnDestroy() => 
            CleanUp();

        protected virtual void OnAwake() { }

        protected virtual void Initialize() { }

        protected virtual void SubscribeUpdates() { }

        protected virtual void CleanUp() { }

    }
}