using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float Difficulty = 1f;
    public GameObject Obstacle;
    public GameObject Edible;
    public Vector3 SpawnPosition;

    private void SpawnWave()
    {
        GameObject toInstantiate = this.Obstacle;

        // Change the object to spawn to an edible instead of an obstacle
        if (Random.value > .7f)
            toInstantiate = this.Edible;

        Instantiate(toInstantiate, new Vector3(Random.Range(-this.SpawnPosition.x, this.SpawnPosition.x), 1, this.SpawnPosition.z), Quaternion.identity);
    }

    // Use this for initialization
    IEnumerator Start()
    {
        Time.timeScale = this.Difficulty;
        while (GameObject.Find("Player") != null)
        {
            SpawnWave();
            yield return new WaitForSeconds(1f);
        }
    }
}
