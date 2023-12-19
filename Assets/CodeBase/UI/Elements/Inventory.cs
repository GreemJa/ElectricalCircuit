using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Elements
{
    public class Inventory : MonoBehaviour
    {
        private List<UnifiedInventoryItems> _items = new();
        public Button PreviousButton, NextButton; 

        public void Initialize()
        {
            _items.AddRange(GetComponentsInChildren<UnifiedInventoryItems>());
            
            PreviousButton.gameObject.SetActive(_items.Count > 2);
            NextButton.gameObject.SetActive(_items.Count > 2);
        }
    }
}