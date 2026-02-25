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
    
    public UnityEvent<InventorySlotChangedEventArgs> OnInventoryChanged;

    void Awake()
    {
        m_slots = new InventorySlot[MaxSlots];
    }

    public IReadOnlyList<InventorySlot> Slots => m_slots;

    public uint TryAddItem(ItemSO item, uint amount)
    {
        for (int i = 0; i < m_slots.Length; i++)
        {
            if (amount == 0) break;
            if (m_slots[i].Item != item) continue;

            uint space = MaxStackSize - m_slots[i].Amount;
            if (space == 0) continue;

            uint toAdd = amount > space ? space : amount;
            m_slots[i].Amount += toAdd;
            amount -= toAdd;
            OnInventoryChanged.Invoke(new( m_slots[i].Item, m_slots[i].Amount, i));
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

        return amount;
    }

    public uint TryRemoveItem(ItemSO item, uint amount)
    {
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

        return amount;
    }
}