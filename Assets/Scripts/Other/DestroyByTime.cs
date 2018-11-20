using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Destroys this object after an amount of seconds
public class DestroyByTime : MonoBehaviour
{
    public float LifeTime;

	// Use this for initialization
	void Start()
    {
        Destroy(this.gameObject, this.LifeTime);
	}
}
