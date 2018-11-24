using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class FireSparkMoveHandler : MonoBehaviour
{
    #region Public Fields
    public float Speed = 100;
    #endregion

    private Vector3 Target;
    private Vector3 OriginalPosition;

    // true = right, false = left
    private bool direction = true;
    private bool swiveled = false;
    private int framesSinceSwiveled = 0;
 
    #region Unity Methods
    void Start()
    {
        this.Speed = Random.Range(80, 200);
        this.Target = new Vector3(this.transform.position.x, this.transform.position.y + 1000, this.transform.position.z);
        this.OriginalPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);

        float size = Random.Range(1, 3);
        this.transform.localScale = new Vector3(size, size, size);
    }
 
    void Update()
    {
        // Move Object (Position)

        float step = this.Speed * Time.deltaTime;
        this.transform.position = Vector3.MoveTowards(this.transform.position, this.Target, step);

        if (this.transform.position.x > this.OriginalPosition.x + Random.value * 50)
        {
            this.direction = false;

            this.swiveled = true;
            this.framesSinceSwiveled++;
        }
        else if (this.transform.position.x < this.OriginalPosition.x - Random.value * 50)
        {
            this.direction = true;

            this.swiveled = true;
            this.framesSinceSwiveled++;
        }
        
        if (!this.swiveled)
        {
            if (this.direction)
                this.transform.position = new Vector3(this.transform.position.x + .5f, this.transform.position.y, this.transform.position.z);
            else
                this.transform.position = new Vector3(this.transform.position.x - .5f, this.transform.position.y, this.transform.position.z);
        }
        else if (this.framesSinceSwiveled == 2)
        {
            this.swiveled = false;
            this.framesSinceSwiveled = 0;
        }

        // Reduce Scale

        this.transform.localScale = new Vector3(this.transform.localScale.x - .01f, this.transform.localScale.y - .01f, this.transform.localScale.z - .01f);

        if (this.transform.localScale.x <= 0)
            Destroy(this.gameObject);
    }
    #endregion
 
    #region Private Methods
    #endregion
}
