using UnityEngine;

public class CharacterInteractor : MonoBehaviour, IInteractionHandler
{
    [SerializeField] float m_interactionRadius = 5;
    [SerializeField] ContactFilter2D m_contactFilter;
    readonly Collider2D[] m_foundColliders = new Collider2D[10];
    public void Interact()
    {
        int count = Physics2D.OverlapCircle(transform.position, m_interactionRadius, m_contactFilter, m_foundColliders);
        for(int i = 0; i < count; i++)
        {
            if (!m_foundColliders[i].TryGetComponent(out IInteractable interactable)) continue;
            interactable.Interact(m_foundColliders[i].gameObject, gameObject);
            break;
        }
    }
}
