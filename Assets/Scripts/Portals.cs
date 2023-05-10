using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portals : MonoBehaviour
{
    public Transform destination;
    private GameObject puck;

    private void Awake()
    {
        puck = GameObject.FindGameObjectWithTag("Puck");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Puck"))
        {
            if (Vector2.Distance(puck.transform.position,transform.position) > 0.5f)
            {
                puck.transform.position = destination.transform.position;
            }
            
        }
    }
}
