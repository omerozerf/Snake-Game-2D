using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointController : MonoBehaviour
{
    [SerializeField] private TailController tailController;
    

    public void RePosition()
    {
        transform.position = RandomSpawnPosition();
    }

    private Vector3 RandomSpawnPosition()
    {
        var xPos = Random.Range(1, 21);
        var yPos = Random.Range(1, 21);
        var spawnPosition = new Vector3(xPos, yPos, 0);

        foreach (var part in tailController.snake) //point spawn bug
        {
            if (spawnPosition == part.transform.position)
            {
                Debug.Log("Reposition Point!");
                return RandomSpawnPosition();
            }
        }
        return spawnPosition;
        
    }
    
}
