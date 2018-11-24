using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
 
public class LoadScene : MonoBehaviour
{
    #region Public Fields
    public string Scene;
    #endregion
 
    #region Unity Methods
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(LoadGame);
    }
    #endregion

    #region Private Methods
    private void LoadGame()
    {
        Debug.Log("Scene loading: " + this.Scene);
        SceneManager.LoadScene(this.Scene, LoadSceneMode.Single);
    }
    #endregion
}
