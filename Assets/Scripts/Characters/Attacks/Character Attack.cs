using UnityEngine;

public class CharacterAttack : MonoBehaviour, IAttackHandler
{
    public void Attack()
    {
        Debug.Log("Attack");
    }
}
