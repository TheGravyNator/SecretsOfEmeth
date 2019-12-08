using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float speed;
    private Vector3 pos;
    private Transform tr;

    void Start()
    {
        pos = transform.position;
        tr = transform;
        
    }
    
    void Update()
    {
        RaycastHit2D hitup = Physics2D.Raycast(transform.position, Vector2.up, 1.9f);
        RaycastHit2D hitdown = Physics2D.Raycast(transform.position, Vector2.down, 1.9f);
        RaycastHit2D hitright = Physics2D.Raycast(transform.position, Vector2.right, 1.9f);
        RaycastHit2D hitleft = Physics2D.Raycast(transform.position, Vector2.left, 1.9f);

        if (hitup.collider == null && (Input.GetAxisRaw("Vertical") == 1 && tr.position == pos)) pos += Vector3.up;
        if (hitdown.collider == null && (Input.GetAxisRaw("Vertical") == -1 && tr.position == pos)) pos += Vector3.down;
        if (hitright.collider == null && (Input.GetAxisRaw("Horizontal") == 1 && tr.position == pos)) pos += Vector3.right;
        if (hitleft.collider == null && (Input.GetAxisRaw("Horizontal") == -1 && tr.position == pos)) pos += Vector3.left;
        
        

        transform.position = Vector3.MoveTowards(transform.position, pos, speed * Time.deltaTime);
    }
}
