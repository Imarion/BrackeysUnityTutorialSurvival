﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int Health = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ApplyDamage(int TheDamage) {
        Health -= TheDamage;
        if (Health <= 0)
        {
            Dead();
        }
    }

    void Dead() {
        Destroy(gameObject);
    }
}
