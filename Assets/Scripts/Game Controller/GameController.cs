using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float Difficulty = 1f;
    public GameObject Obstacle;
    public GameObject Edible;
    public GameObject PowerUp;
    public GameObject Coin;
    public Vector3 SpawnPosition;
    public GameObject Parent;

    private float waveSpawnRate;
    private float waveTimer = 0f;
    private float itemSpawnRate;
    private float itemTimer = 0f;

    // Use this for initialization
    void Start()
    {
        Time.timeScale = this.Difficulty;

        this.waveSpawnRate = Random.Range(.5f, 2f);
        this.itemSpawnRate = Random.Range(5f, 30f);

        if (this.Parent == null)
            this.Parent = Instantiate(new GameObject("=== [ Spawned ] ==="));
    }

    void Update()
    {
        // Don't update if Player is dead
        if (GameObject.Find("Player") == null)
            return;

        this.waveTimer += Time.deltaTime;
        this.itemTimer += Time.deltaTime;

        // Check if wave is ready to spawn
        if (this.waveTimer >= this.waveSpawnRate)
        {
            this.SpawnWave();

            this.waveSpawnRate = Random.Range(.5f, 2f);
            this.ResetTimer(ref this.waveTimer);
        }

        if (this.itemTimer >= this.itemSpawnRate)
        {
            this.SpawnPowerUp();

            this.itemSpawnRate = Random.Range(5f, 30f);
            this.ResetTimer(ref this.itemTimer);
        }
    }
    
    // This takes a reference to a float and sets it to 0
    private void ResetTimer(ref float timer)
    {
        timer = 0;
    }

    private void SpawnWave()
    {
        GameObject toInstantiate = this.Obstacle;

        // Change the object to spawn to an edible instead of an obstacle
        if (Random.value > .7f)
            toInstantiate = this.Edible;

        GameObject obj = Instantiate(toInstantiate, new Vector3(Random.Range(-this.SpawnPosition.x, this.SpawnPosition.x), 1, this.SpawnPosition.z), Quaternion.identity);
        obj.transform.parent = this.Parent.transform;
    }

    private void SpawnPowerUp()
    {
        GameObject toInstantiate = this.PowerUp;

        if (Random.value > .5f)
            toInstantiate = this.Coin;

        GameObject obj = Instantiate(toInstantiate, new Vector3(Random.Range(-this.SpawnPosition.x, this.SpawnPosition.x), 1, this.SpawnPosition.z), Quaternion.identity);
        obj.transform.parent = this.Parent.transform;
    }
}
