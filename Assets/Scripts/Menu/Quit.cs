using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class Quit : MonoBehaviour
{
    #region Public Fields
    #endregion
 
    #region Unity Methods 
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(() => Application.Quit());
    }
    #endregion

    #region Private Methods
    #endregion
}
