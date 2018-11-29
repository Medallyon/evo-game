using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PowerUpMover : MonoBehaviour
{
    #region Public Fields
    public float Speed = 1;
    #endregion
    
    private Vector3 target;
 
    #region Unity Methods
    void Start()
    {
        Vector3 playerPosition = GameObject.Find("Player").transform.position;
        this.target = new Vector3(playerPosition.x, playerPosition.y, playerPosition.z);
        this.target.Set(this.target.x, this.transform.position.y, this.target.z - 10);
    }
 
    void Update()
    {
        float step = this.Speed * Time.deltaTime;
        this.transform.position = Vector3.MoveTowards(this.transform.position, this.target, step);
    }
    #endregion

    #region Private Methods
    #endregion
}
