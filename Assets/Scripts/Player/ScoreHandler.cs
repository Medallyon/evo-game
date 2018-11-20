using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
 
public class ScoreHandler : MonoBehaviour
{
    private float currentScore = 0;

    #region Public Fields
    public float ScoreToWin = 1000;
    public Text textScore;
    #endregion
 
    #region Unity Methods
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Edible")
            return;
        
        List<ObstacleMover> movingObjects = FindObjectsOfType<ObstacleMover>().ToList();
        ObstacleMover wantedObject = movingObjects.Find(x => x.GetComponent<Collider>() == other);
        this.currentScore += wantedObject.Score;

        this.textScore.text = "Score: " + (int)this.currentScore;
    }
    #endregion

    #region Private Methods
    #endregion
}
