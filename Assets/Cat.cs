using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cat : MonoBehaviour
{
    public Animator Cage;

    private void Awake()
    {
        Cage.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag.Equals("Player"))
        {
            Cage.enabled = true;
            Destroy(gameObject, 3);
        }
    }
}
