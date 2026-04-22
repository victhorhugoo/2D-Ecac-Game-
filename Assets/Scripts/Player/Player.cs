using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigidbody;

    [Header("Speed setup")]

    public Vector2 friction = new Vector2(.1f, 0); // Fricção para o player parar de se mover quando não estiver pressionando as setas
    public float speed;
    public float speedRun;
    public float ForceJump = 2;

    [Header("Animation setup")]

    public float jumpScaleY = 1.5f;         // Quanto o player vai crescer na vertical quando pular para dar a sensação de que ele está se esticando para pular
    public float jumpScaleX = .7f;          // Quanto o player vai diminuir na horizontal quando pular para dar a sensação de que ele está se esticando para pular
    public float animationDuration = .3f;   // Duração da animação do pulo
    public Ease ease = Ease.OutBack;        // Ease para a animação do pulo

    private float _currentSpeed;            // Velocidade atual do player, que pode ser a velocidade normal ou a velocidade de corrida dependendo se o player está correndo ou não

    private void Update()
    {
        HandleJump();
        HandleMoviment();
    }

    // === Movimentação do player ===
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

    // === Fazer o player pular ===
    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            myRigidbody.velocity = Vector2.up * ForceJump;  // Aplicando uma força para o player pular
            myRigidbody.transform.localScale = Vector2.one; // Resetando a escala do player para evitar que o pulo fique estranho caso o player esteja correndo

            DOTween.Kill(myRigidbody.transform);            // Matando qualquer animação de escala que esteja acontecendo para evitar que o pulo fique estranho caso o player esteja correndo
            HandleScaleJump();                              // Chamando a função para animar o pulo
        }
    }

    // === Animar o pulo do player fazendo ele crescer na vertical e diminuir na horizontal para dar a sensação de que ele está se esticando para pular, e depois voltar ao normal
    private void HandleScaleJump()
    {
        myRigidbody.transform.DOScaleY(jumpScaleY, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease); // Animando a escala do player na vertical
        myRigidbody.transform.DOScaleX(jumpScaleX, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease); // Animando a escala do player na horizontal
    }

}
