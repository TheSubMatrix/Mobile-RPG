using System;
using MatrixUtils.Attributes;
using UnityEngine;
using UnityEngine.Events;

public class QuestResponder : MonoBehaviour
{
    [SerializeField, RequiredField] InterfaceReference<IQuestFactory> m_questToRespondTo;
    [SerializeField] UnityEvent<IQuest, IQuestFactory> m_onQuestStarted = new();
    [SerializeField] UnityEvent<IQuest, IQuestFactory> m_onQuestEnded;
    void OnEnable()
    {
        m_questToRespondTo.Value.OnQuestStarted += m_onQuestStarted.Invoke;
        m_questToRespondTo.Value.OnQuestEnded += m_onQuestEnded.Invoke;
    }
    void OnDisable()
    {
        m_questToRespondTo.Value.OnQuestStarted -= m_onQuestStarted.Invoke;
        m_questToRespondTo.Value.OnQuestEnded -= m_onQuestEnded.Invoke;
    }
}
