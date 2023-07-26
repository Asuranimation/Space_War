using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float padding;
    private float xMin, xMax, yMin, yMax;
    void Start()
    {
        SetMovementLimit();
    }

    void Update()
    {
        Move();   
    }

    private void Move()
    {
        float deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed; 
        float deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        float newXPosition = Mathf.Clamp(transform.position.x + deltaX,xMin,xMax);
        float newYPosition = Mathf.Clamp(transform.position.y + deltaY,yMin,yMax);
        transform.position = new Vector2(newXPosition, newYPosition);
    }

    private void SetMovementLimit()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0,0,0)).x + padding ;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }
}
