using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointController : MonoBehaviour
{

    public void RePosition()
    {
        transform.position = RandomSpawnPosition();
    }

    private Vector3 RandomSpawnPosition()
    {
        var xPos = Random.Range(1, 21);
        var yPos = Random.Range(1, 21);
        var spawnPosition = new Vector3(xPos, yPos, 0);

        return spawnPosition;
    }
    
}
