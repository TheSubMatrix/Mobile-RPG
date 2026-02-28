using UnityEngine;
[CreateAssetMenu( fileName = "New Pickup Item Quest Definition", menuName = "Quests/Pickup Item Quest Definition")]
public class PickupItemQuestDefinitionSO : QuestDefinitionSO<PickupItemQuest>
{
    public ItemSO ItemToPickup;
    public uint AmountToPickup;
    public InventoryItemCountChangedEventChannel InventoryItemCountChangedEventChannel;
    public VoidEventChannel RequestInventoryUpdate;
    protected override PickupItemQuest CreateAndInitializeQuest()
    {
        return PickupItemQuest.CreateInstance(this);
    }
}
