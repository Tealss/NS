using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RangedAttackData", menuName = "TopDownController/Attacks/Ranged", order = 1)]
public class RangedAttackData : AttackSo
{
    [Header("Ranged Attack Data")]
    public string nulletNameTag;
    public float duration;
    public float spread;
    public int numerofProjectilesPerShot;
    public float mutipleProjectilesAngel;
    public Color projectileColor;
}
