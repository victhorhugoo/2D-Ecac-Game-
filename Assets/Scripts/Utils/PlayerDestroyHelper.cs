using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestroyHelper : MonoBehaviour
{
    public Player player;

    private void Awake()
    {
        if (player == null)
            player = GetComponent<Player>();
    }

    public void KillPlayer()
    {
        if (player == null)
        {
            Debug.LogError("PlayerDestroyHelper: player é null!");
            return;
        }

        // Use o HealthBase para matar corretamente, respeitando o fluxo
        player.healthBase.Damage(player.healthBase.startLife);
    }
}
