using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
 
public class PowerUpMover : MonoBehaviour
{
    #region Public Fields
    public float Speed = 1;
    #endregion
    
    private Vector3 target;
 
    #region Unity Methods
    void Start()
    {
        Vector3 playerPosition = GameObject.Find("Player").transform.position;
        this.target = new Vector3(playerPosition.x, playerPosition.y, playerPosition.z);
        this.target.Set(this.target.x, this.target.y, this.target.z - 10);
    }
 
    void Update()
    {
        float step = this.Speed * Time.deltaTime;
        this.transform.position = Vector3.MoveTowards(this.transform.position, this.target, step);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
            return;

        ScoreHandler playerObject = FindObjectOfType<ScoreHandler>();
        playerObject.ScoreMultiplier = 2;

        // TODO: Instantiate(DOUBLE SCORE TEXT!!!);

        Timer timer = new Timer()
        {
            Interval = 10000,
            Enabled = true
        };

        timer.Elapsed += (object Source, ElapsedEventArgs e) =>
        {
            playerObject.ScoreMultiplier = 1;
            timer.Enabled = false;
        };

        Destroy(this.gameObject);
    }
    #endregion

    #region Private Methods
    #endregion
}
