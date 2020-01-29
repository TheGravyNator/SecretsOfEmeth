using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BattleController : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;

    private Character playerStats;
    private Character enemyStats;

    private int playerHealth;
    private int enemyHealth;

    public Text playerHealthbar;
    public Text enemyHealthbar;

    public Button attack;
    public Button item;
    public Button run;

    public BattleboxController textbox;

    public TurnOrder turn;

    void Start()
    {
        playerStats = player.GetComponent<Character>();
        enemyStats = enemy.GetComponent<Character>();

        playerHealth = playerStats.health;
        enemyHealth = enemyStats.health;

        UpdateHealthbar();

        turn = TurnOrder.PLAYER;

        textbox.WriteText(playerStats.characterName + " encounted a " + enemyStats.characterName + "!");
    }

    void Update()
    {
        if (playerHealth <= 0)
        {
            SceneManager.LoadScene("Overworld");
        }
        if (enemyHealth <= 0)
        {
            SceneManager.LoadScene("Overworld");
        }
    }

    void PlayerAction(int action)
    {
        if (turn == TurnOrder.PLAYER)
        {
            if ((CharacterAction)action == CharacterAction.ATTACK)
            {
                int damage = enemyStats.Attack(playerStats.attack);
                enemyHealth -= damage;
                Debug.Log("Player did " + damage + " damage.");
                UpdateHealthbar();
            }
            else if ((CharacterAction)action == CharacterAction.ITEM)
            {
                textbox.WriteText("You don't have any items!");
            }
            else if ((CharacterAction)action == CharacterAction.RUN)
            {
                SceneManager.LoadScene("Overworld");
            }
            turn = TurnOrder.ENEMY;
            DisableButtons();
            EnemyAction();
        }
    }

    void EnemyAction()
    {
        int damage = playerStats.Attack(enemyStats.attack);
        playerHealth -= damage;
        UpdateHealthbar();
        turn = TurnOrder.PLAYER;
        EnableButtons();
    }

    void UpdateHealthbar()
    {
        playerHealthbar.text = Mathf.Clamp(playerHealth,0,playerHealth).ToString();
        enemyHealthbar.text = Mathf.Clamp(enemyHealth,0,enemyHealth).ToString();
    }

    void DisableButtons()
    {
        attack.interactable = false;
        item.interactable = false;
        run.interactable = false;
    }

    void EnableButtons()
    {
        attack.interactable = true;
        item.interactable = true;
        run.interactable = true;
    }
}

public enum CharacterAction
{
    ATTACK,
    ITEM,
    RUN
}

public enum TurnOrder
{
    PLAYER,
    ENEMY
}
