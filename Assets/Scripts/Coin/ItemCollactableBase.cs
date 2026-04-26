using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollactableBase : MonoBehaviour
{
    public string comparedTag = "Player"; // Tag do objeto que pode coletar o item

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

    protected virtual void OnCollect() { }
}
