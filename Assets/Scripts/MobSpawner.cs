using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MobSpawner : MonoBehaviour
{
    public int enemiesToGo = 5;
    public float spawnTimer = 0;
    public float waitTime = 2;
    public int maxEnemies = 5;
    public static int enemies = 0;

    public List<GameObject> spawnPool;
    public Camera cam;
    private GameObject toSpawn;
    protected float height, width;
    int currentBuildIndex;


    // Update is called once per frame

    private void Start()
    {
        cam = Camera.main;
        enemiesToGo = GameManager.gameManager.enemiesRemaining;
        currentBuildIndex = SceneManager.GetActiveScene().buildIndex;
        maxEnemies += GameObject.FindObjectOfType<SavedInfo>().levelsCompleted;
    }

    void FixedUpdate()
    {
        enemiesToGo = GameManager.gameManager.enemiesRemaining;
        spawnTimer += Time.deltaTime;
        if (spawnTimer > waitTime)
        {
            if (enemiesToGo > 0 && enemies <= maxEnemies)
            {
                spawnTimer -= waitTime;
                toSpawn = spawnPool[currentBuildIndex];
                SpawnMob();
                enemiesToGo--;
                enemies++;
                Debug.Log("spawned");
            }
        }
    }

    void SpawnMob()
    {
        height = cam.orthographicSize + 1;
        width = cam.orthographicSize * cam.aspect + 1;
        float posX = Random.Range(-width, width);
        print(cam.transform.position.y);
        Vector2 pos;
        if (posX < 0)
        {
            pos = new Vector2(cam.transform.position.x - width + posX, cam.transform.position.y + height + Random.Range(-height, height));
        }
        else
        {
            pos = new Vector2(cam.transform.position.x + width + posX, cam.transform.position.y + height + Random.Range(-height, height));
        }
        Instantiate(toSpawn, pos, toSpawn.transform.rotation);
    }
}