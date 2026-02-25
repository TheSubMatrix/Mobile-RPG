using MatrixUtils.DependencyInjection;
using UnityEngine;

public class DialogueDisplayRequester : MonoBehaviour
{
    [Inject] IDialogueDisplay m_dialogueDisplay;
    public void MakeDialogueRequest(string dialogueToDisplay)
    {
        m_dialogueDisplay.Display(dialogueToDisplay);
    }
}
