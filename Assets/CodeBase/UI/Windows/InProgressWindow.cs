using UnityEngine.UI;

namespace CodeBase.UI.Windows
{
    public sealed class InProgressWindow : WindowBase
    {
        public Button CloseButton;
        
        protected override void OnAwake() => 
            CloseButton.onClick.AddListener(()=>Destroy(gameObject));

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