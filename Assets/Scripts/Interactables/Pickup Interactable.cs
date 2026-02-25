using UnityEngine;

public class PickupInteractable : MonoBehaviour, IInteractable
{
    ItemSO m_itemToGive;
    uint m_amountToGive;
    public void Interact(GameObject self, GameObject interactor)
    {
        if (!interactor.TryGetComponent(out Inventory inventory)) return;
        uint amount = inventory.TryAddItem(m_itemToGive, m_amountToGive);
        if (amount > 0)
        {
            m_amountToGive = amount;
        }
        else
        {
            Destroy(this);
        }
    }
}
