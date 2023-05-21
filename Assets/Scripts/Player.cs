using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public float movementSpeed;
    private float movement;
    private float levelWidth = 3;

    public float fallBoundary = -10f;
    public GameObject endGameUIPrefab;

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    private void Start()
    {
        rb.AddForce(new Vector2(0, 15), ForceMode2D.Impulse);
    }

    private void Update()
    {
        DontExitTheScreen();
        movement = Input.GetAxis("Horizontal") * movementSpeed;

        if (movement > 0)
        {
            transform.localScale = Vector3.one;
        }else if (movement < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private void FixedUpdate()
    {
        Vector2 vel = rb.velocity;
        vel.x = movement;
        rb.velocity = vel;


    }

    private void DontExitTheScreen()
    {
        if(transform.position.x > levelWidth)
        {
            transform.position -= new Vector3(2 * levelWidth, 0, 0);
        }
        else if(transform.position.x < -levelWidth)
        {
            transform.position += new Vector3(2 * levelWidth, 0, 0);
        }
    }

}
