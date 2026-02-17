using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// Defines any object that can be possessed by a <see cref="ICharacterController"/>
/// </summary>
public interface IPossessable
{
    bool IsPossessed => CurrentPossessor != null;
    ICharacterController CurrentPossessor { get; protected set; }
    protected void Move(Vector2 direction);
    protected void Attack();
    public UnityEvent<ICharacterController> OnPossess { get; set; }
    public UnityEvent<ICharacterController> OnUnPossess{ get; set; }
    public void Possess(ICharacterController controller)
    {
        if(controller == null || IsPossessed) return;
        controller.OnMove.AddListener(Move);
        controller.OnAttack.AddListener(Attack);
        OnPossess.Invoke(controller);
        CurrentPossessor = controller;
    }
    public void UnPossess(ICharacterController controller)
    {
        if(controller == null || !IsPossessed || controller != CurrentPossessor) return;
        controller.OnMove.RemoveListener(Move);
        controller.OnAttack.RemoveListener(Attack);
        OnUnPossess.Invoke(controller);
        CurrentPossessor = null;
    }
}
