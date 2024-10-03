using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    public GameObject[] obstacles;
    Vector3 spawnPos;
    public float spawnRate;

    // Start is called before the first frame update
    void Start()
    {
        spawnPos = transform.position;

        StartCoroutine(ISpawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ISpawn()
    {
        while (true)
        {
            Spawn();

            yield return new WaitForSeconds(spawnRate);

            GameManager.instance.UpdateScore();
        }

    }

    void Spawn()
    {
        int randObstacles = Random.Range(0, obstacles.Length);

        int randPos = Random.Range(0, 2);

        spawnPos = transform.position;

        if (randPos < 1)
        {
            Instantiate(obstacles[randObstacles], spawnPos, transform.rotation);
        }
        else
        {
            spawnPos.y = -transform.position.y;

            if(randObstacles == 1)
            {
                spawnPos.x += 1;
            }
            else if(randObstacles == 2)
            {
                spawnPos.x += 2;
            }

            GameObject obj = Instantiate(obstacles[randObstacles], spawnPos, transform.rotation);
            obj.transform.eulerAngles = new Vector3(0, 0, 180);
        }
    }
}
