using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;
 
public class ExtraLife : MonoBehaviour
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

        LifeHandler playerObject = FindObjectOfType<LifeHandler>();
        playerObject.IncreaseLives();

        Text scoreMultText = Instantiate(this.HoverTextPrefab);
        scoreMultText.text = "EXTRA LIFE";
        scoreMultText.transform.SetParent(this.Canvas.transform, false);

        Destroy(this.gameObject);
    }
    #endregion

    #region Private Methods
    #endregion
}
