using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    public float raycastlength;
    private MovementController player;

    void Start()
    {
        player = gameObject.GetComponent<MovementController>();
    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(player.pos, player.dir, raycastlength);
        Debug.DrawLine(player.pos, player.pos + player.dir, Color.green);
        if (hit.collider != null)
        {
            if (hit.collider.tag == "enemy" && Input.GetButtonDown("Jump"))
            {
                Debug.Log("This is an enemy.");
            }
        }
    }
}
