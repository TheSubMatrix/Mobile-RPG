using System.Collections.Generic;
using MatrixUtils.Attributes;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public struct InventorySlot
{
    public ItemSO Item;
    public uint Amount;
    public bool IsEmpty => Item == null;
}

public class Inventory : MonoBehaviour
{
    [field: SerializeField] public uint MaxSlots { get; private set; } = 10;
    [field: SerializeField] public uint MaxStackSize { get; private set; } = 99;
    [ReadOnly, SerializeField] InventorySlot[] m_slots;
    public VoidEventChannel RequestInventoryData;
    public UnityEvent<InventorySlotChangedEventArgs> OnInventoryChanged;
    public UnityEvent<InventoryItemCountChangedEventArgs> OnItemCountChanged;
    readonly Dictionary<ItemSO, uint> m_itemCounts = new();

    void Awake()
    {
        m_slots = new InventorySlot[MaxSlots];
        RequestInventoryData.OnEventRaised += OnInventoryDataRequested;
        OnInventoryDataRequested();
    }

    public IReadOnlyList<InventorySlot> Slots => m_slots;

    void OnInventoryDataRequested()
    {
        for (int i = 0; i < m_slots.Length; i++)
        {
            OnInventoryChanged.Invoke(new(m_slots[i].Item, m_slots[i].Amount, i));
        }

        foreach (KeyValuePair<ItemSO, uint> kvp in m_itemCounts)
        {
            OnItemCountChanged.Invoke(new(kvp.Key, kvp.Value));
        }
    }

    public uint TryAddItem(ItemSO item, uint amount)
    {
        uint remaining = amount;

        // First pass: calculate available space without modifying anything
        for (int i = 0; i < m_slots.Length; i++)
        {
            if (remaining == 0) break;
            if (m_slots[i].Item != item) continue;

            uint space = MaxStackSize - m_slots[i].Amount;
            if (space == 0) continue;

            remaining -= remaining > space ? space : remaining;
        }

        foreach (InventorySlot t in m_slots)
        {
            if (remaining == 0) break;
            if (!t.IsEmpty) continue;

            remaining -= remaining > MaxStackSize ? MaxStackSize : remaining;
        }

        // Not enough room — don't add anything, return how many couldn't fit
        if (remaining > 0) return remaining;

        // Second pass: actually add the items
        for (int i = 0; i < m_slots.Length; i++)
        {
            if (amount == 0) break;
            if (m_slots[i].Item != item) continue;

            uint space = MaxStackSize - m_slots[i].Amount;
            if (space == 0) continue;

            uint toAdd = amount > space ? space : amount;
            m_slots[i].Amount += toAdd;
            amount -= toAdd;
            OnInventoryChanged.Invoke(new(m_slots[i].Item, m_slots[i].Amount, i));
        }

        for (int i = 0; i < m_slots.Length; i++)
        {
            if (amount == 0) break;
            if (!m_slots[i].IsEmpty) continue;

            uint toAdd = amount > MaxStackSize ? MaxStackSize : amount;
            m_slots[i] = new() { Item = item, Amount = toAdd };
            amount -= toAdd;
            OnInventoryChanged.Invoke(new(m_slots[i].Item, m_slots[i].Amount, i));
        }

        uint newTotal = RecalculateItemCount(item);
        OnItemCountChanged.Invoke(new(item, newTotal));

        return amount;
    }

    public uint TryRemoveItem(ItemSO item, uint amount)
    {
        uint total = GetItemCount(item);

        // Not enough items — don't remove anything, return the deficit
        if (total < amount) return amount - total;

        // Second pass: actually remove the items
        for (int i = m_slots.Length - 1; i >= 0; i--)
        {
            if (amount == 0) break;
            if (m_slots[i].Item != item) continue;

            uint toRemove = amount > m_slots[i].Amount ? m_slots[i].Amount : amount;
            m_slots[i].Amount -= toRemove;
            amount -= toRemove;

            if (m_slots[i].Amount == 0)
                m_slots[i] = new();
            OnInventoryChanged.Invoke(new(m_slots[i].Item, m_slots[i].Amount, i));
        }

        uint newTotal = RecalculateItemCount(item);
        OnItemCountChanged.Invoke(new(item, newTotal));

        return amount;
    }

    public bool HasItems(ItemSO item, uint amount = 1)
    {
        return GetItemCount(item) >= amount;
    }

    public uint GetItemCount(ItemSO item)
    {
        return m_itemCounts.TryGetValue(item, out uint count) ? count : 0;
    }

    uint RecalculateItemCount(ItemSO item)
    {
        uint total = 0;
        for (int i = 0; i < m_slots.Length; i++)
        {
            if (m_slots[i].Item != item) continue;
            total += m_slots[i].Amount;
        }

        if (total == 0)
            m_itemCounts.Remove(item);
        else
            m_itemCounts[item] = total;

        return total;
    }
}