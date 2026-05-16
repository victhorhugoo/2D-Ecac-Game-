using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

[CreateAssetMenu]
public class SOPlayerSetup : ScriptableObject
{
    public Animator player;
    public SOString soStringName;

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

    [Header("Animation Player")]
    public string boolRun = "Run";
    public string triggerDeath = "Death";
    public string boolJump = "Jump";
    //public Animator animator;
    public float playerSwipeDuration = .1f; // Duração da animação de swipe do player

}
