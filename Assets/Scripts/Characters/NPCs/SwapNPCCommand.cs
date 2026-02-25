using MatrixUtils.Attributes;
using UnityEngine;

public class SwapNPCCommand : MonoBehaviour
{
    [SerializeField] NPC m_npc;
    [SerializeReference, ClassSelector] INPCCommand m_command;
    public void Swap()
    {
        m_npc.InteractionCommand = m_command;
    }
}
