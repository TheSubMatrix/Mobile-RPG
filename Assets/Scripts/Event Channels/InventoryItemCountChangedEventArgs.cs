[System.Serializable]
public readonly struct InventoryItemCountChangedEventArgs
{
    public readonly ItemSO Item;
    public readonly uint NewCount;
    public InventoryItemCountChangedEventArgs(ItemSO item, uint newCount)
    {
        Item = item;
        NewCount = newCount;
    }
}
