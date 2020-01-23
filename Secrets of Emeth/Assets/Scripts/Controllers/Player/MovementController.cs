using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    private Transform tr;
    // Movement speed of the player.
    public float speed;
    // Grid position of the player. Not the same as the realtime position acquired by transform.position.
    public Vector3 pos;
    // Length of the collision raycasts around the player. Suggested size for raycastlength is 1.9, making sure the player cannot run into a grid space another entity is also moving towards.
    public float raycastlength;

    public Vector3 dir;
    
    private bool isInteracting = false;

    private void Start()
    {
        // Set the current grid position to the starting position of the player.
        pos = transform.position;
        tr = transform;

        // Subscribe to GameStateChanged event.
        GameManager.OnGameStateChanged += GameStateChanged;
    }
    
    private void Update()
    {
        // Create raycasts for all 4 moving directions. The hits are used for collision detection with other entities.
        RaycastHit2D hitup = Physics2D.Raycast(transform.position, Vector2.up, raycastlength);
        RaycastHit2D hitdown = Physics2D.Raycast(transform.position, Vector2.down, raycastlength);
        RaycastHit2D hitright = Physics2D.Raycast(transform.position, Vector2.right, raycastlength);
        RaycastHit2D hitleft = Physics2D.Raycast(transform.position, Vector2.left, raycastlength);

        // Check is the space the player's moving to is not occupied. If the button is pressed and the grid space is available, add the appropriate direction to the pos variable.
        if (!isInteracting)
        {
            if (Input.GetAxisRaw("Vertical") == 1)
            {
                dir = Vector3.up;
                if (hitup.collider == null && tr.position == pos) pos += Vector3.up;
            }
            if (Input.GetAxisRaw("Vertical") == -1)
            {
                dir = Vector3.down;
                if (hitdown.collider == null && tr.position == pos) pos += Vector3.down;
            }
            if (Input.GetAxisRaw("Horizontal") == 1)
            {
                dir = Vector3.right;
                if (hitright.collider == null && tr.position == pos) pos += Vector3.right;
            }
            if (Input.GetAxisRaw("Horizontal") == -1)
            {
                dir = Vector3.left;
                if (hitleft.collider == null && tr.position == pos) pos += Vector3.left;
            }
        }

        // Let the gameobject smoothly transition over to the newly set position in one of the movement if statements, considering the deltatime for frame independent movement.
        transform.position = Vector3.MoveTowards(transform.position, pos, speed * Time.deltaTime);
    }

    private void GameStateChanged(Gamestates currentGameState, Gamestates newGameState)
    {
        if (newGameState == Gamestates.INTERACTING) isInteracting = true;
        if (currentGameState == Gamestates.INTERACTING) isInteracting = false;
    }
}
