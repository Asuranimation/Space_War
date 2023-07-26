using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipMovement : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        Move();   
    }

    private void Move()
    {
        float deltaX = Input.GetAxis("Horizontal");
        float newXPosition = transform.position.x + deltaX;
        transform.position = new Vector2(newXPosition, transform.position.y);
    }
}
