using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class ScoreHandler : MonoBehaviour
{
    #region Public Fields
    public float ScoreToWin = 1000;
    #endregion
 
    #region Unity Methods
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Edible")
            return;

        // Implement Score-specific code
    }
    #endregion

    #region Private Methods
    #endregion
}
