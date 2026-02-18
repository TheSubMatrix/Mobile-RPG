using System;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyDefeatQuest", menuName = "Scriptable Objects/EnemyDefeatQuest")]
public class EnemyDefeatQuest : Quest<EnemyDefeatData>
{
    
}
[Serializable]
public struct EnemyDefeatData : IEquatable<EnemyDefeatData>
{
    [SerializeField] int m_enemiesDefeated;
    public bool Equals(EnemyDefeatData other)
    {
        return m_enemiesDefeated == other.m_enemiesDefeated;
    }
    public override bool Equals(object obj)
    {
        return obj is EnemyDefeatData other && Equals(other);
    }
    public override int GetHashCode()
    {
        return m_enemiesDefeated;
    }
}
