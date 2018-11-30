using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class LifeHandler : MonoBehaviour
{
    #region Public Fields
    public int Lives = 5;
    public GameObject Canvas;
    public Text TextPrefab;
    public AudioClip CollideSound;
    #endregion

    #region Unity Methods
    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Obstacle")
            return;

        this.DecreaseLives();
        this.GetComponent<AudioSource>().PlayOneShot(this.CollideSound, .5f);
    }

    void Update()
    {
        this.TextPrefab.text = this.Lives.ToString();
    }
    #endregion

    #region Private Methods
    public void IncreaseLives()
    {
        this.Lives++;

        // Implement UI-specific code (i.e. 4 -> 5 hearts)
        this.TextPrefab.text = this.Lives.ToString();
    }

    public void DecreaseLives()
    {
        this.Lives--;

        // Implement UI-specific code (i.e. 5 -> 4 hearts)
        this.TextPrefab.text = this.Lives.ToString();

        if (this.Lives <= 0)
        {
            // End level and display Score
            Destroy(this.gameObject);
        }
    }
    #endregion
}
