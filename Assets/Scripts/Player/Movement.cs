using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	// Use this for initialization
	void Start()
    {
		
	}
	
	// Update is called once per frame
	void FixedUpdate()
    {
        float horizontal = 0;

#if UNITY_STANDALONE || UNITY_WEBPLAYER

        horizontal = Input.GetAxisRaw("Horizontal");

#else

        if (Input.touchCount > 0)
        {
            Touch myTouch = Input.touches[0];

            if (myTouch.phase == TouchPhase.Began || myTouch.phase == TouchPhase.Moved)
                horizontal = myTouch.rawPosition.x;
        }

#endif

        var currentPosition = this.gameObject.transform.position;
        if (horizontal != 0)
            this.gameObject.transform.position = new Vector3(currentPosition.x + horizontal, currentPosition.y, currentPosition.z);
    }
}
