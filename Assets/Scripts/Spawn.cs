using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    //public PartyGoer enemyPrefab;
    public GameObject manager;
    public GameObject enemy_one;
    public GameObject enemy_two;
    public GameObject enemy_three;
    public List<Vector3> spawnspots = new List<Vector3>();

    public float spawnDelay = 0.5f;

    public void Awake()
    {
        //Vector3 position1 = new Vector3(0, 0, 0);
        //spawnspots.Add(position1);
        //Vector3 position2 = new Vector3(4, 6, 0);
        //spawnspots.Add(position2);
    }

    public GameObject spawn(int turncount)
    {
        int num = Random.Range(0, 3);
        if (num == 0)
        {
            GameObject new_enemy = spawn_chad();

            int x = Random.Range(0, spawnspots.Count);
            new_enemy.transform.position = spawnspots[x];

            return new_enemy;
        }
        
        if (num == 1)
        {
            GameObject new_enemy = spawn_vanessa();

            int x = Random.Range(0, spawnspots.Count);
            new_enemy.transform.position = spawnspots[x];

            return new_enemy;
        }

        if (num == 2)
        {
            GameObject new_enemy = spawn_andrew();

            int x = Random.Range(0, spawnspots.Count);
            new_enemy.transform.position = spawnspots[x];

            return new_enemy;
        }

        return null;

    }

    public GameObject spawn_chad()
    {
        GameObject enemy = Instantiate<GameObject>(enemy_one);
        Debug.Log("chad");
        return enemy;
    }

    public GameObject spawn_vanessa()
    {
        GameObject enemy = Instantiate<GameObject>(enemy_two);
        Debug.Log("vanessa");
        return enemy;
    }

    public GameObject spawn_andrew()
    {
        GameObject enemy = Instantiate<GameObject>(enemy_three);
        Debug.Log("andrew");
        return enemy;
    }

    //public void setLimit(int lim)
    //{
    //limit = lim;
    //}

}