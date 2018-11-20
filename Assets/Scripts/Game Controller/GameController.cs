using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float Difficulty;
    public GameObject Obstacle;
    public Vector3 SpawnPosition;

    private void SpawnWave()
    {
        Instantiate(this.Obstacle, new Vector3(Random.Range(-this.SpawnPosition.x, this.SpawnPosition.x), 1, this.SpawnPosition.z), Quaternion.identity);
    }

    // Use this for initialization
    IEnumerator Start()
    {
        while (GameObject.Find("Player") != null)
        {
            SpawnWave();
            this.Difficulty += .1f;
            yield return new WaitForSeconds(Mathf.Max(1f, Random.Range(0f, 5f) - this.Difficulty));
        }
    }
}
