using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    [SerializeField] private PointController pointController;
    [SerializeField] private TailController tailController;
    
    
    [SerializeField] private float speed;

    private Vector3 direction;
    private Vector3 desiredDirection;
    
    private void Start()
    {
        desiredDirection = Vector3.up;
        StartCoroutine(Move());
    }

    private void Update()
    {
        UpdateDirection();
    }

    
    
    private IEnumerator Move()
    {
        while (true)
        {
            yield return new WaitForSeconds(1 / speed);
            
            tailController.FollowTail();
            
            direction = desiredDirection;
            var position = transform.position + direction;
            transform.position = position;
        }
    }

    private void UpdateDirection()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && direction != Vector3.left)
        {
            desiredDirection = Vector3.right;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && direction != Vector3.right)
        {
            desiredDirection = Vector3.left;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && direction != Vector3.down)
        {
            desiredDirection = Vector3.up;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && direction != Vector3.up)
        {
            desiredDirection = Vector3.down;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Wall") || col.CompareTag("Tail"))
        {
            Debug.Log("You Lost!");
        }
        else if (col.CompareTag("Point"))
        {
            pointController.RePosition();
            tailController.AddTail();
        }
    }
}
