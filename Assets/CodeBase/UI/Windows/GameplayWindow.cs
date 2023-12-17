using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CodeBase.UI.Windows
{
    public sealed class GameplayWindow : WindowBase
    {
        public Image ContentImage;
        
        protected override void OnAwake()
        {
            throw new System.NotImplementedException();
        }

        protected override void Initialize()
        {
            Sprite contentSprite = _staticData.ForLevel(SceneManager.GetActiveScene().name).ContentSprite;
            ContentImage.sprite = contentSprite;
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