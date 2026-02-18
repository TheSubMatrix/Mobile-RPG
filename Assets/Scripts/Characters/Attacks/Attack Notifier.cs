using UnityEngine;
using UnityEngine.Events;

public class AttackNotifier : MonoBehaviour, IAttackSource
{
    [field:SerializeField] public UnityEvent OnAttack { get; set; } = new();

    public void Notify()
    {
        OnAttack.Invoke();
    }
}
