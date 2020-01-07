using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    public float raycastlength;
    private MovementController player;
    public GameObject textboxObject;
    private TextboxController textbox;

    void Start()
    {
        player = gameObject.GetComponent<MovementController>();
        textbox = textboxObject.GetComponent<TextboxController>();
    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(player.pos, player.dir, raycastlength);
        Debug.DrawLine(player.pos, player.pos + player.dir, Color.green);
        if (hit.collider != null)
        {
            if (hit.collider.tag == "enemy" && Input.GetButtonDown("Jump") && !textbox.inTextbox)
            {
                textbox.WriteText("My name is Yoshikage Kira. I'm 33 years old. My house is in the northeast section of Morioh, where all the villas are, and I am not married. I work as an employee for the Kame Yu department stores, and I get home every day by 8 PM at the latest. I don't smoke, but I occasionally drink.");
            }
        }
    }
}
