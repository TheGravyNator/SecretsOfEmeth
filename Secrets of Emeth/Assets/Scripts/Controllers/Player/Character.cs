using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public string characterName;

    public int health;
    public int attack;
    public int defense;
    public bool isPlayer;

    private void Start()
    {
        if (isPlayer)
            DontDestroyOnLoad(this);
    }

    public int Attack(int enemyDefense)
    {
        int damage = 0;
        if (attack < enemyDefense)
        {
            damage = attack;
            Debug.Log(characterName + "'s attack is lower.");
        }
        else if (attack == enemyDefense)
        {
            damage = attack / 2;
            Debug.Log(characterName + "'s attack is equal.");
        }
        else if (attack > enemyDefense)
        {
            damage = attack / 4;
            Debug.Log(characterName + "'s attack is higher.");
        }
        return damage;
    }
}
