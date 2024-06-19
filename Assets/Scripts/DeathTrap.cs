using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeathTrap : MonoBehaviour
{
    public HealthManager hm;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            hm.TakeDamage(10000000);
        }
    }
}
