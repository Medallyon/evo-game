using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeHandler : MonoBehaviour
{
    public int Lives = 5;
    public Text textLives; 

	// Use this for initialization
	void Start()
    {
        this.textLives.text = "Lives: " + this.Lives;
	}
	
	// Update is called once per frame
	void Update()
    {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Obstacle")
            return;

        this.DecreaseLives();
    }

    private void DecreaseLives()
    {
        this.Lives--;

        // Implement UI-specific code (i.e. 5 -> 4 hearts)
        this.textLives.text = "Lives: " + this.Lives;

        if (this.Lives <= 0)
        {
            // End level and display Score
            Destroy(this.gameObject);
        }
    }
}
