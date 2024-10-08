using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Enemy", order = 1)]
public class EnemyData : ScriptableObject
{
    public float hp;
    public int damage;
    public float speed;
    public float chaseRange;
    public float attackRange;
    public float range;
}