using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;
 
public class PowerUpMultiplier : MonoBehaviour
{
    #region Public Fields
    public GameObject Canvas;
    public Text HoverTextPrefab;
    #endregion

    #region Unity Methods
    void Start()
    {
        if (this.Canvas == null)
            this.Canvas = GameObject.Find("UI Canvas");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
            return;

        ScoreHandler playerObject = FindObjectOfType<ScoreHandler>();
        playerObject.ScoreMultiplier *= 2f;

        // TODO: Instantiate(DOUBLE SCORE TEXT!!!);

        Timer timer = new Timer()
        {
            Interval = 20000,
            Enabled = true
        };

        timer.Elapsed += (object Source, ElapsedEventArgs e) =>
        {
            playerObject.ScoreMultiplier /= 2f;
            timer.Enabled = false;
        };

        Text scoreMultText = Instantiate(this.HoverTextPrefab);
        scoreMultText.text = "DOUBLE POINTS";
        scoreMultText.transform.SetParent(this.Canvas.transform, false);

        Destroy(this.gameObject);
    }

    void Update()
    {
        
    }
    #endregion
 
    #region Private Methods
    #endregion
}
