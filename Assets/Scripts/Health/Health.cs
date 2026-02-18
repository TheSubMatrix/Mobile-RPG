using System;
using MatrixUtils.Attributes;
using MatrixUtils.GenericDatatypes;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour, IDamageable, IHealable
{
    [field: SerializeField] public Observer<uint> MaxHealth { get; private set; } = new(100);
    [field: SerializeField] public Observer<uint> CurrentHealth { get; private set; } = new(100);
    [field: SerializeField, ReadOnly] public bool IsDead { get; private set; }
    [field: SerializeField] public UnityEvent OnDeath { get; private set; } = new();
    [field: SerializeField] public UnityEvent OnRevive { get; private set; } = new();
    

    void Awake()
    {
        CurrentHealth = MaxHealth;
        IsDead = CurrentHealth <= 0;
    }

    public void Damage(uint amount)
    {
        CurrentHealth.Value = CurrentHealth > amount ? CurrentHealth - amount : 0;
        if (CurrentHealth > 0 || IsDead) return;
        IsDead = true;
        OnDeath.Invoke();
    }

    public void Heal(uint amount)
    {
        CurrentHealth.Value = CurrentHealth + amount > MaxHealth ? MaxHealth : CurrentHealth + amount;
        if (CurrentHealth <= 0 || !IsDead) return;
        IsDead = true;
        OnRevive.Invoke();
    }
}
