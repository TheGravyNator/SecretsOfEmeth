using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New EnemyStats", menuName = "Enemy Stats", order = 51)]
public class EnemyStats : ScriptableObject
{
    [SerializeField]
    public string enemyName;

    [SerializeField]
    public int health;
    [SerializeField]
    public int strength;
    [SerializeField]
    public int vitality;
    [SerializeField]
    public int dexterity;
    [SerializeField]
    public int intelligence;
    [SerializeField]
    public int willpower;

}
