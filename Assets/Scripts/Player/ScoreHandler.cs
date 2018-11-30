using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
 
public class ScoreHandler : MonoBehaviour
{
    #region Public Fields
    public string NextLevel;
    public float ScoreToWin = 1000;
    public float ScoreMultiplier = 1;
    public GameObject Canvas;
    public Text TextPrefab;
    public AudioClip CollideSound;
    #endregion

    public float currentScore = 0f;
 
    #region Unity Methods
    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Edible")
            return;
        
        List<ObstacleMover> movingObjects = FindObjectsOfType<ObstacleMover>().ToList();
        ObstacleMover wantedObject = movingObjects.Find(x => x.GetComponent<Collider>() == other);
        this.currentScore += wantedObject.Score * this.ScoreMultiplier;

        if (this.currentScore >= this.ScoreToWin)
            SceneManager.LoadSceneAsync(this.NextLevel, LoadSceneMode.Single);

        this.GetComponent<AudioSource>().PlayOneShot(this.CollideSound, .5f);
    }

    void Update()
    {
        this.TextPrefab.text = ((int)this.currentScore).ToString();
        if (this.ScoreMultiplier > 1f)
            this.TextPrefab.text += " (" + this.ScoreMultiplier.ToString("0.##") + "x)";
    }
    #endregion

    #region Private Methods
    #endregion
}
