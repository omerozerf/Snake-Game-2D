using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class TailController : MonoBehaviour
{
    [SerializeField] private GameObject tail;
    [SerializeField] private Transform tails;
    
    
    
    public List<GameObject> snake = new List<GameObject>();

    private void Awake()
    {
        snake.Add(gameObject);
    }

    public void AddTail()
    {
        GameObject newTail = Instantiate(tail, snake[^1].transform.position, Quaternion.identity, tails);
        snake.Add(newTail);
        snake[1].GetComponent<Collider2D>().enabled = false;
    }

    public void FollowTail()
    {
        for (int i = snake.Count - 1; i > 0 ; i--)
        {
            snake[i].transform.position = snake[i - 1].transform.position;
        }
    }
    
}
