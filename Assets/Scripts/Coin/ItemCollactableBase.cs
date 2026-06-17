using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollactableBase : MonoBehaviour
{
    public string comparedTag = "Player"; // Tag do objeto que pode coletar o item
    public ParticleSystem particleSystem;
    public float timeToHide = 3;
    public GameObject graphicItem;

    [Header("Sounds")]
    public AudioSource audioSource;

    private void Awake()
    {
        //if (particleSystem != null) particleSystem.transform.SetParent(null);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag(comparedTag))
        {
            Collect();
        }
    }

    protected virtual void Collect()
    {
        //Debug.Log("Collect");
        if(graphicItem != null) graphicItem.SetActive(false);
        Invoke("HideObject", timeToHide);
         // Desativa o item para simular a coleta
        OnCollect();
    }

    private void HideObject()
    {
        gameObject.SetActive(false);
    }

    protected virtual void OnCollect() {
        if (particleSystem != null) particleSystem.Play();
        if (audioSource != null) audioSource.Play();
    }
}
