using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeHandler : MonoBehaviour
{
    public int Lives = 5;

	// Use this for initialization
	void Start()
    {
		
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

        if (this.Lives <= 0)
        {
            // End level and display Score
            Destroy(this.gameObject);
        }
    }
}
