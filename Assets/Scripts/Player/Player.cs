using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public HealthBase healthBase;

    [Header("Setup")]
    public SOPlayerSetup soPlayerSetup;
    //public Animator animator;
    public float playerSwipeDuration = .1f; // Duração da animação de swipe do player

    private float _currentSpeed;            // Velocidade atual do player, que pode ser a velocidade normal ou a velocidade de corrida dependendo se o player está correndo ou não
    private Animator _currentPlayer;

    private void Awake()
    {
        if (healthBase != null)
        {
            healthBase.OnKill += OnPlayerKill;
        }

        _currentPlayer = Instantiate(soPlayerSetup.player, transform);
    }

    private void OnPlayerKill()
    {
        healthBase.OnKill -= OnPlayerKill;
        _currentPlayer.SetTrigger(soPlayerSetup.triggerDeath);
    }

    private void Update()
    {
        HandleJump();
        HandleMoviment();

        // Detectar "fim do pulo"
        if (Mathf.Abs(myRigidbody.velocity.y) < 0.01f)
        {
            _currentPlayer.SetBool(soPlayerSetup.boolJump, false);
        }
    }

    // === Movimentação do player ===
    private void HandleMoviment()
    {
        // Fazer o player correr
        if (Input.GetKey(KeyCode.Z))
        {
            _currentSpeed = soPlayerSetup.speedRun;
            _currentPlayer.speed = 2; // Aumentar a velocidade da animação para dar a sensação de que o player está correndo
        }
        else
        {
            _currentSpeed = soPlayerSetup.speed;
            _currentPlayer.speed = 1; // Resetar a velocidade da animação para o normal quando o player não estiver correndo
        }

        // Fazer o player se mover para os lados
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //myRigidbody.MovePosition(myRigidbody.position - velocity * Time.deltaTime);
            myRigidbody.velocity = new Vector2(-_currentSpeed, myRigidbody.velocity.y);
            if(myRigidbody.transform.localScale.x != -1) // Virar o player para a esquerda
            {
                myRigidbody.transform.DOScaleX(-1, playerSwipeDuration);
            }
            _currentPlayer.SetBool(soPlayerSetup.boolRun, true);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //myRigidbody.MovePosition(myRigidbody.position + velocity * Time.deltaTime);
            myRigidbody.velocity = new Vector2(_currentSpeed, myRigidbody.velocity.y);
            if (myRigidbody.transform.localScale.x != 1) // Virar o player para a direita
            {
                myRigidbody.transform.DOScaleX(1, playerSwipeDuration);
            }
            _currentPlayer.SetBool(soPlayerSetup.boolRun, true);
        }
        else
        {
            _currentPlayer.SetBool(soPlayerSetup.boolRun, false);
        }

        // Implementando uma fricção para que o player pare de se mover quando não estiver pressionando as setas
        if (myRigidbody.velocity.x > 0)
        {
            myRigidbody.velocity -= soPlayerSetup.friction;
        }
        else if (myRigidbody.velocity.x < 0)
        {
            myRigidbody.velocity += soPlayerSetup.friction;
        }
    }

    // === Fazer o player pular ===
    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            myRigidbody.velocity = Vector2.up * soPlayerSetup.ForceJump;  // Aplicando uma força para o player pular
            myRigidbody.transform.localScale = Vector2.one; // Resetando a escala do player para evitar que o pulo fique estranho caso o player esteja correndo
            
            DOTween.Kill(myRigidbody.transform);            // Matando qualquer animação de escala que esteja acontecendo para evitar que o pulo fique estranho caso o player esteja correndo
            HandleScaleJump();                              // Chamando a função para animar o pulo

            _currentPlayer.SetBool(soPlayerSetup.boolJump, true);
        }
    }

    // === Animar o pulo do player fazendo ele crescer na vertical e diminuir na horizontal para dar a sensação de que ele está se esticando para pular, e depois voltar ao normal
    private void HandleScaleJump()
    {
        myRigidbody.transform.DOScaleY(soPlayerSetup.jumpScaleY, soPlayerSetup.animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(soPlayerSetup.ease); // Animando a escala do player na vertical
        myRigidbody.transform.DOScaleX(soPlayerSetup.jumpScaleX, soPlayerSetup.animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(soPlayerSetup.ease); // Animando a escala do player na horizontal
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}
