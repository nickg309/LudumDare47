using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject spawn1, spawn2, spawn3, spawn4;

    void Start()
    {
        StartCoroutine("SpawnZombies");
    }
    IEnumerator SpawnZombies()
    {
        GameObject zombie1 = ObjectPooler.SharedInstance.GetPooledZombie();
        if (zombie1 != null)
        {
            zombie1.transform.position = spawn1.transform.position;
            zombie1.transform.rotation = spawn1.transform.rotation;
            zombie1.SetActive(true);
            zombie1.GetComponent<ZombieControls>().health = 15;
        }
        GameObject zombie2 = ObjectPooler.SharedInstance.GetPooledZombie();
        if (zombie2 != null)
        {
            zombie2.transform.position = spawn2.transform.position;
            zombie2.transform.rotation = spawn2.transform.rotation;
            zombie2.SetActive(true);
            zombie2.GetComponent<ZombieControls>().health = 15;
        }
        GameObject zombie3 = ObjectPooler.SharedInstance.GetPooledZombie();
        if (zombie3 != null)
        {
            zombie3.transform.position = spawn3.transform.position;
            zombie3.transform.rotation = spawn3.transform.rotation;
            zombie3.SetActive(true);
            zombie3.GetComponent<ZombieControls>().health = 15;
        }
        GameObject zombie4 = ObjectPooler.SharedInstance.GetPooledZombie();
        if (zombie4 != null)
        {
            zombie4.transform.position = spawn4.transform.position;
            zombie4.transform.rotation = spawn4.transform.rotation;
            zombie4.SetActive(true);
            zombie4.GetComponent<ZombieControls>().health = 15;
        }

        yield return new WaitForSeconds(4);
        Recall();
    }

    void Recall()
    {
        StartCoroutine("SpawnZombies");
    }
}