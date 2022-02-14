using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public GameObject WiiMote;
    public GameObject Reverse;

    private float ySpawnRange = 2.8f;
    private float xSpawnRange = 1f;

    public void spawnPowerUp() {
        Vector3 spawnPos = new Vector3(Random.Range(-xSpawnRange, xSpawnRange), Random.Range(-ySpawnRange, ySpawnRange), 0);
        if (Random.Range(0,2) == 0)
            Instantiate(WiiMote, spawnPos, Quaternion.identity);
        else
            Instantiate(Reverse, spawnPos, Quaternion.identity);
    }
}
