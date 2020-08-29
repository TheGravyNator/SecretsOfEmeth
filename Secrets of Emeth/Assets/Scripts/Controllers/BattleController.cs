using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

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

        StartCoroutine(Opening());
    }

    void Update()
    {
    }

    IEnumerator Opening()
    {
        textbox.WriteText(playerStats.characterName + " encounted a " + enemyStats.enemyName + "!", false);
        yield return new WaitUntil(() => textbox.typing == false);
    }

    void PlayerAction(int action)
    {
        StartCoroutine(BattleStep(action));
    }

    IEnumerator BattleStep(int action)
    {
        int playerRoll = Random.Range(0, 20) + playerStats.speed;
        int enemyRoll = Random.Range(0, 20) + enemyStats.speed;
        int damage;
        if ((CharacterAction)action == CharacterAction.ATTACK)
        {
            if (playerRoll > enemyRoll || playerRoll == enemyRoll)
            {
                damage = playerStats.Attack(enemyStats.defense);
                enemyHealth -= damage;
                textbox.WriteText($"{playerStats.characterName} did {damage} damage.", false); ;
                DisableButtons();
                yield return new WaitUntil(() => textbox.typing == false);
                UpdateHealthbar();
                damage = enemyStats.Attack(playerStats.defense);
                playerHealth -= damage;
                textbox.WriteText($"{enemyStats.enemyName} did {damage} damage.", false);
                DisableButtons();
                yield return new WaitUntil(() => textbox.typing == false);
                UpdateHealthbar();
            }
            if (playerRoll < enemyRoll)
            {
                damage = enemyStats.Attack(playerStats.defense);
                playerHealth -= damage;
                textbox.WriteText($"{enemyStats.enemyName} did {damage} damage.", false);
                DisableButtons();
                yield return new WaitUntil(() => textbox.typing == false);
                UpdateHealthbar();
                damage = playerStats.Attack(enemyStats.defense);
                enemyHealth -= damage;
                textbox.WriteText($"{playerStats.characterName} did {damage} damage.", false);
                DisableButtons();
                yield return new WaitUntil(() => textbox.typing == false);
                UpdateHealthbar();
            }
            if (playerHealth <= 0)
            {
                textbox.WriteText($"{enemyStats.enemyName} defeated {playerStats.characterName}.", true);
                yield return new WaitUntil(() => textbox.typing == false);
                SceneManager.LoadScene("Overworld");
            }
            if (enemyHealth <= 0)
            {
                textbox.WriteText($"{playerStats.characterName} defeated {enemyStats.enemyName}.", true);
                yield return new WaitUntil(() => textbox.typing == false);
                SceneManager.LoadScene("Overworld");
            }
        }
        else if ((CharacterAction)action == CharacterAction.ITEM)
        {
            textbox.WriteText("You don't have any items!", false);
            DisableButtons();
            yield return new WaitUntil(() => textbox.typing == false);
        }
        else if ((CharacterAction)action == CharacterAction.RUN)
        {
            textbox.WriteText($"You ran away.", true);
            DisableButtons();
            yield return new WaitUntil(() => textbox.typing == false);
            SceneManager.LoadScene("Overworld");
        }
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
