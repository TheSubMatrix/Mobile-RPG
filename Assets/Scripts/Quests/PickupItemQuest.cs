using System;
public class PickupItemQuest : IQuest
{
    ItemSO m_itemToPickup;
    uint m_amountToPickup;
    uint m_currentAmount;
    InventoryItemCountChangedEventChannel m_inventoryItemCountChangedEventChannel;
    Action<QuestEventArgs<PickupItemQuest>> m_questInstanceFinished;
    IQuestFactory m_questInstanceCreator;

    public static PickupItemQuest CreateInstance(PickupItemQuestDefinitionSO definition)
    {
        PickupItemQuest quest = new()
        {
            m_inventoryItemCountChangedEventChannel = definition.InventoryItemCountChangedEventChannel,
            m_questInstanceCreator = definition,
            m_amountToPickup = definition.AmountToPickup,
            m_itemToPickup = definition.ItemToPickup,
            m_questInstanceFinished = args => definition.OnQuestInstanceEnded.Invoke(args)
        };
        definition.OnQuestInstanceStarted.Invoke(new(quest, definition));
        quest.m_inventoryItemCountChangedEventChannel.OnEventRaised += quest.OnItemCountChanged;
        definition.RequestInventoryUpdate.RaiseEvent();
        return quest;
    }

    void OnItemCountChanged(InventoryItemCountChangedEventArgs countData)
    {
        if (countData.Item != m_itemToPickup) return;
        m_currentAmount = countData.NewCount;
        if (m_currentAmount >= m_amountToPickup)
        {
            m_questInstanceFinished.Invoke(new(this, m_questInstanceCreator));
        }
    }

    public float Progress => (float)m_currentAmount / m_amountToPickup;
}
