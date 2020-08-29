using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomController : MonoBehaviour
{
    public float spawnChance;

    public EnemySpawn[] spawnPool;
    
    public void RandomEncounter()
    {
        if (Random.value < spawnChance)
        {
            GameManager.Instance.ChangeGameState(Gamestates.IN_BATTLE);
            SceneManager.LoadScene("Battle");
        }
    }
}
