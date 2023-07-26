using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("wall"))
        {
            transform.position = Vector3.zero;
            gameObject.SetActive(false);
        }
    }
}