using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Quit : MonoBehaviour
{
    #region Public Fields
    #endregion
 
    #region Unity Methods 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    private void OnMouseUp()
    {
        Debug.Log("Clicked Sprite");
        Application.Quit();
    }
    #endregion

    #region Private Methods
    #endregion
}
