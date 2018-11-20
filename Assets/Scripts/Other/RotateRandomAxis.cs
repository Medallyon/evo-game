using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRandomAxis : MonoBehaviour
{
    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        this.rb = this.GetComponent<Rigidbody>();

        this.rb.angularVelocity = Random.insideUnitSphere;
	}
	
	// Update is called once per frame
	void Update()
    {
		
	}
}
