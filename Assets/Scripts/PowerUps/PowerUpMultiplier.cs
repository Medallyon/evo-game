using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
 
public class PowerUpMultiplier : MonoBehaviour
{
    #region Public Fields
    #endregion

    #region Unity Methods
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

    void Update()
    {
        
    }
    #endregion
 
    #region Private Methods
    #endregion
}
