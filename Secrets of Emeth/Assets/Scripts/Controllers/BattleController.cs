using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BattleController : MonoBehaviour
{
    public GameObject playerPos;
    public GameObject player;
    public GameObject enemy;

    private CharacterController playerStats;
    private EnemyController enemyStats;

    private int playerHealth;
    private int enemyHealth;

    public Text playerHealthbar;
    public Text enemyHealthbar;

    public Button attack;
    public Button item;
    public Button run;

    public BattleboxController textbox;

    public TurnOrder turn;

    public RoomController room;

    void Start()
    {
        GameManager.Instance.ChangeGameState(Gamestates.IN_BATTLE);

        player = GameManager.Instance.Player;

        playerStats = player.GetComponent<CharacterController>();

        enemyStats = new EnemyController();

        room = GameManager.Instance.currentRoom;
        
        EnemyStats test = room.spawnPool[(int)UnityEngine.Random.Range(0, room.spawnPool.Length)].statFormat;
        enemyStats.InitializeEnemy(test);

        playerHealth = playerStats.health;
        enemyHealth = enemyStats.health;

        UpdateHealthbar();

        turn = TurnOrder.PLAYER;

        textbox.WriteText(playerStats.characterName + " encounted a " + enemyStats.enemyName + "!");

        Debug.Log(GameManager.Instance.GameState);
    }

    void Update()
    {
        if (playerHealth <= 0)
        {
            textbox.WriteText($"{enemyStats.enemyName} defeated {playerStats.characterName}.");
            SceneManager.LoadScene("Overworld");
        }
        if (enemyHealth <= 0)
        {
            textbox.WriteText($"{playerStats.characterName} defeated {enemyStats.enemyName}.");
            SceneManager.LoadScene("Overworld");
        }
    }

    void PlayerAction(int action)
    {
        StartCoroutine(BattleStep(action));
    }

    IEnumerator BattleStep(int action)
    {
        if (turn == TurnOrder.PLAYER)
        {
            int damage;
            if ((CharacterAction)action == CharacterAction.ATTACK)
            {
                damage = playerStats.Attack(enemyStats.defense);
                enemyHealth -= damage;
                textbox.WriteText($"{playerStats.characterName} did {damage} damage.");
                DisableButtons();
                yield return new WaitUntil(() => textbox.typing == false);
                UpdateHealthbar();
            }
            else if ((CharacterAction)action == CharacterAction.ITEM)
            {
                textbox.WriteText("You don't have any items!");
            }
            else if ((CharacterAction)action == CharacterAction.RUN)
            {
                textbox.WriteText($"You ran away.");
                SceneManager.LoadScene("Overworld");
            }
            turn = TurnOrder.ENEMY;
            DisableButtons();

            damage = enemyStats.Attack(playerStats.defense);
            playerHealth -= damage;
            textbox.WriteText($"{enemyStats.enemyName} did {damage} damage.");
            DisableButtons();
            yield return new WaitUntil(() => textbox.typing == false);
            UpdateHealthbar();
            turn = TurnOrder.PLAYER;
            EnableButtons();
        }
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
