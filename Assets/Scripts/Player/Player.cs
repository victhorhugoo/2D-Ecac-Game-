using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigidbody;

    public Vector2 friction = new Vector2(.1f, 0);

    public float speed;
    public float speedRun;

    public float ForceJump = 2;

    private float _currentSpeed;

    private void Update()
    {
        HandleJump();
        HandleMoviment();
    }

    // Movimentação do player
    private void HandleMoviment()
    {
        // Fazer o player correr
        if (Input.GetKey(KeyCode.Z))
        {
            _currentSpeed = speedRun;
        }
        else
        {
            _currentSpeed = speed;
        }

        // Fazer o player se mover para os lados
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //myRigidbody.MovePosition(myRigidbody.position - velocity * Time.deltaTime);
            myRigidbody.velocity = new Vector2(-_currentSpeed, myRigidbody.velocity.y);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //myRigidbody.MovePosition(myRigidbody.position + velocity * Time.deltaTime);
            myRigidbody.velocity = new Vector2(_currentSpeed, myRigidbody.velocity.y);
        }

        // Implementando uma fricção para que o player pare de se mover quando não estiver pressionando as setas
        if (myRigidbody.velocity.x > 0)
        {
            myRigidbody.velocity -= friction;
        }
        else if (myRigidbody.velocity.x < 0)
        {
            myRigidbody.velocity += friction;
        }
    }

    // Fazer o player pular
    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //myRigidbody.MovePosition(myRigidbody.position - velocity * Time.deltaTime);
            myRigidbody.velocity = Vector2.up * ForceJump;
        }
    }
}
