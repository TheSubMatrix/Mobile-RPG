using UnityEngine;
[CreateAssetMenu( fileName = "New Pickup Item Quest Definition", menuName = "Quests/Pickup Item Quest Definition")]
public class PickupItemQuestDefinitionSO : QuestDefinitionSO<PickupItemQuest>
{
    public ItemSO ItemToPickup;
    public uint AmountToPickup;
    public InventorySlotChangedEventChannel InventorySlotChangedEventChannel;
    public VoidEventChannel RequestInventoryUpdate;
    protected override PickupItemQuest CreateAndInitialize()
    {
        return PickupItemQuest.CreateInstance(this);
    }
}
