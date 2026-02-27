using System;
using UnityEngine;

public class PickupItemQuest : IQuest
{
    ItemSO m_itemToPickup;
    uint m_amountToPickup;
    uint m_currentAmount;
    InventorySlotChangedEventChannel m_inventorySlotChangedEventChannel;
    Action<QuestEventArgs<PickupItemQuest>> m_questInstanceFinished;
    IQuestFactory m_questInstanceCreator;
    public static PickupItemQuest CreateInstance(PickupItemQuestDefinitionSO definition)
    {
        PickupItemQuest quest = new()
        {
            m_inventorySlotChangedEventChannel = definition.InventorySlotChangedEventChannel,
            m_questInstanceCreator = definition,
            m_amountToPickup = definition.AmountToPickup,
            m_itemToPickup = definition.ItemToPickup,
            m_questInstanceFinished = args => definition.OnQuestInstanceEnded.Invoke(args)
        };
        quest.m_inventorySlotChangedEventChannel.OnEventRaised += quest.OnInventoryUpdated;
        definition.RequestInventoryUpdate.RaiseEvent();
        definition.OnQuestInstanceStarted.Invoke(new(quest, definition));
        return quest;
    }
    void OnInventoryUpdated(InventorySlotChangedEventArgs slotChangeData)
    {
        if (slotChangeData.Item != m_itemToPickup) return;
        m_currentAmount = slotChangeData.NewSlotCount;
        if (m_currentAmount >= m_amountToPickup)
        {
            m_questInstanceFinished.Invoke(new(this, m_questInstanceCreator));
        }
    }
    public float Progress => (float)m_currentAmount / m_amountToPickup;
}
