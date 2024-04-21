using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public GameObject[] powerups;

    void Start()
    {
        StartCoroutine(SpawnPowerup());
    }

    IEnumerator SpawnPowerup()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            int randomIndex = Random.Range(0, powerups.Length);
            Instantiate(powerups[randomIndex], new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0), Quaternion.identity);
        }
    }
}
