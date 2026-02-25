[System.Serializable]
public readonly struct InventorySlotChangedEventArgs
{
    public readonly ItemSO Item;
    public readonly uint NewSlotCount;
    public readonly int SlotIndex;
    public InventorySlotChangedEventArgs(ItemSO item, uint newSlotCount, int slotIndex)
    {
        Item = item;
        NewSlotCount = newSlotCount;
        SlotIndex = slotIndex;
    }
}
