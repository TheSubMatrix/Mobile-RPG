using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using MatrixUtils.DependencyInjection;
using TMPro;
using UnityEngine;

public class HUDDialogueDisplay : MonoBehaviour, IDialogueDisplay, IDependencyProvider
{
    readonly Queue<string> m_dialogueQueue = new();
    [SerializeField] TMP_Text m_dialogueText;
    [SerializeField] CanvasGroup m_dialogueCanvasGroup;
    bool m_isDisplaying;

    [Provide, UsedImplicitly] IDialogueDisplay GetDialogueDisplay() => this;

    public void Display(string dialogue)
    {
        m_dialogueQueue.Enqueue(dialogue);
        if (!m_isDisplaying)
            StartCoroutine(ProcessQueue());
    }

    IEnumerator ProcessQueue()
    {
        m_isDisplaying = true;
        while (m_dialogueQueue.Count > 0)
        {
            string line = m_dialogueQueue.Dequeue();
            yield return FadeDialogueLine(line);
        }
        m_isDisplaying = false;
    }

    IEnumerator FadeDialogueLine(string line)
    {
        m_dialogueText.text = line;
        yield return FadeCanvasGroupAsync(0.5f, 1, m_dialogueCanvasGroup);
        yield return new WaitForSeconds(5f);
        yield return FadeCanvasGroupAsync(0.5f, 0, m_dialogueCanvasGroup);
    }

    static IEnumerator FadeCanvasGroupAsync(float duration, float desiredAlpha, CanvasGroup canvasGroup)
    {
        float startAlpha = canvasGroup.alpha;
        float elapsed = 0;
        while (elapsed < duration)
        {
            canvasGroup.alpha = Mathf.Lerp(startAlpha, desiredAlpha, elapsed / duration);
            canvasGroup.interactable = canvasGroup.alpha > 0;
            canvasGroup.blocksRaycasts = canvasGroup.alpha > 0;
            elapsed += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = desiredAlpha;
        canvasGroup.interactable = desiredAlpha > 0;
        canvasGroup.blocksRaycasts = desiredAlpha > 0;
    }
}