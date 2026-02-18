using UnityEngine;
using UnityEngine.Events;

public interface IAttackSource
{
    public UnityEvent OnAttack{ get; }
}
