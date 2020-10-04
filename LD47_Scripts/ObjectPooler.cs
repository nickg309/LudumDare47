using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public GameObject player, bulletPrefab, zombiePrefab, healthOrbPrefab;
    public static ObjectPooler SharedInstance;
    public List<GameObject> poolBullet, poolZombie, poolOrb;
    public int amountToPool;
    public bool shouldExpand = true;

    void Awake() 
    {
        SharedInstance = this;
    }

    void Start()
    {
        poolBullet = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = (GameObject)Instantiate(bulletPrefab);
            obj.SetActive(false);
            poolBullet.Add(obj);
        }

        poolZombie = new List<GameObject>();
        for(int i = 0;i < amountToPool; i++)
        {
            GameObject obj = (GameObject)Instantiate(zombiePrefab);
            obj.gameObject.GetComponent<ZombieControls>().player = player;
            obj.SetActive(false);
            poolZombie.Add(obj);
        }

        poolOrb = new List<GameObject>();
        for(int i = 0; i < amountToPool; i++)
        {
            GameObject obj = (GameObject)Instantiate(healthOrbPrefab);
            obj.SetActive(false);
            poolOrb.Add(obj);
        }
    }

    public GameObject GetPooledBullet()
    {
        for (int i = 0; i < poolBullet.Count; i++)
        {
            if (!poolBullet[i].activeInHierarchy)
            {
                return poolBullet[i];
            }
        }
        if (shouldExpand)
        {
            GameObject obj = (GameObject)Instantiate(bulletPrefab);
            obj.SetActive(false);
            poolBullet.Add(obj);
            return obj;
        }
        else
        {
            return null;
        }
    }

    public GameObject GetPooledZombie()
    {
        for (int i = 0; i < poolZombie.Count; i++)
        {
            if (!poolZombie[i].activeInHierarchy)
            {
                return poolZombie[i];
            }
        }
        if (shouldExpand)
        {
            GameObject obj = (GameObject)Instantiate(zombiePrefab);
            obj.gameObject.GetComponent<ZombieControls>().player = player;
            obj.SetActive(false);
            poolZombie.Add(obj);
            return obj;
        }
        else
        {
            return null;
        }
    }

    public GameObject GetPooledHealthOrb()
    {
        for (int i = 0; i < poolOrb.Count; i++)
        {
            if (!poolOrb[i].activeInHierarchy)
            {
                return poolOrb[i];
            }
        }
        if (shouldExpand)
        {
            GameObject obj = (GameObject)Instantiate(healthOrbPrefab);
            obj.SetActive(false);
            poolOrb.Add(obj);
            return obj;
        }
        else
        {
            return null;
        }
    }
}