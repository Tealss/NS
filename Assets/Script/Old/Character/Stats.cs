using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatsChange
{
    Add,
    Multiple,
    Override,
}
public class CharacterStats
{
    public StatsChange StatsChange;
    [Range(1, 100)] public int MaxHealth;
    [Range(1f, 20f)] public float Speed;

    AttackSo attackSo;

}
