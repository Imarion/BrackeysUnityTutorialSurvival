using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int Health;

    // Start is called before the first frame update
    void Start()
    {
        Health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplyDamage(int TheDamage)
    {
        Health -= TheDamage;
        if (Health <= 0)
        {
            Dead();
        }
    }

    void Dead()
    {
        RespawnMenu.playerIsDead = true;
        Debug.Log("Player died");
    }

    void RespawnStats()
    {
        Debug.Log("RespawnStats received");
        Health = maxHealth;
    }
}
