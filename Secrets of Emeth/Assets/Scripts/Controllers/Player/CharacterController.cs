using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public string characterName;

    public int health;
    public int strength;
    public int vitality;
    public int intelligence;
    public int willpower;
    public int speed;
    
    public int MeleeAttack(int enemyDefense)
    {
        int damage = 0;
        if (strength < enemyDefense)
        {
            damage = Convert.ToInt32(strength / 4);
            Debug.Log(characterName + "'s attack is lower.");
        }
        else if (strength == enemyDefense)
        {
            damage = Convert.ToInt32(strength / 2);
            Debug.Log(characterName + "'s attack is equal.");
        }
        else if (strength > enemyDefense)
        {
            damage = strength;
            Debug.Log(characterName + "'s attack is higher.");
        }
        return damage;
    }
}
