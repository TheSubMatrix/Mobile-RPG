using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour
{
    [Serializable]
    struct InventorySlotDisplayData
    {
        public Image ItemDisplayImage;
        public TMP_Text ItemAmountText;
    }
    [SerializeField] List<InventorySlotDisplayData> m_slotDisplayData = new();
    public void UpdateInventory(InventorySlotChangedEventArgs slotChangeData)
    {
        if(m_slotDisplayData.Count - 1 < slotChangeData.SlotIndex) return;
        m_slotDisplayData[slotChangeData.SlotIndex].ItemAmountText.text = slotChangeData.NewSlotCount.ToString();
        if(slotChangeData.Item is null) {m_slotDisplayData[slotChangeData.SlotIndex].ItemDisplayImage.sprite = null; return;}
        m_slotDisplayData[slotChangeData.SlotIndex].ItemDisplayImage.sprite = slotChangeData.Item.ItemSprite;
    }
}
