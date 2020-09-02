using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public string enemyName;

    public int health;
    public int attack;
    public int defense;
    public int speed;

    public EnemyStats _statTemplate;

    public BattleController bController;

    public void InitializeEnemy(EnemyStats statTemplate)
    {
        _statTemplate = statTemplate;
        enemyName = _statTemplate.enemyName;
        health = _statTemplate.health;
        attack = _statTemplate.strength;
        defense = _statTemplate.vitality;
        speed = _statTemplate.dexterity;
    }

    public int MeleeAttack(int enemyDefense)
    {
        int damage = 0;
        if (attack < enemyDefense)
        {
            damage = Convert.ToInt32(attack / 4);
            Debug.Log(enemyName + "'s attack is lower.");
        }
        else if (attack == enemyDefense)
        {
            damage = Convert.ToInt32(attack / 2);
            Debug.Log(enemyName + "'s attack is equal.");
        }
        else if (attack > enemyDefense)
        {
            damage = attack;
            Debug.Log(enemyName + "'s attack is higher.");
        }
        return damage;
    }
}