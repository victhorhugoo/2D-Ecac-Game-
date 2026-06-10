using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollactableBase : MonoBehaviour
{
    public string comparedTag = "Player"; // Tag do objeto que pode coletar o item
    public ParticleSystem particleSystem;

    private void Awake()
    {
        if (particleSystem != null) particleSystem.transform.SetParent(null);
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
        gameObject.SetActive(false); // Desativa o item para simular a coleta
        OnCollect();
    }

    protected virtual void OnCollect() {
        if (particleSystem != null) particleSystem.Play();
    }
}
