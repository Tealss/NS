using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultAttackData",menuName ="TopDownController/Attacks/Default", order = 0)]
public class AttackSo : ScriptableObject
{
    [Header("Attack Info")]
    public float size;
    public float speed;
    public float power;
    public float delay;
    public LayerMask Target;

    [Header("Knock Back Info")]
    public bool isOnKnckback;
    public float knockbackPower;
    public float knockbackTime;

}
