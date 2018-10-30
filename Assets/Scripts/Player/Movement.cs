using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Create a shorthand for the player's current position
    private Vector3 currentPosition
    {
        get
        {
            return this.gameObject.transform.position;
        }
        set
        {
            this.gameObject.transform.position = new Vector3(value.x, this.currentPosition.y, this.currentPosition.z);
        }
    }
    
    public LayerMask hitLayers;
    private Vector3 targetPosition;
    private Camera cam;

	// Use this for initialization
	void Start()
    {
        this.cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update()
    {
        Ray castPoint;
        RaycastHit hit;

#if UNITY_STANDALONE || UNITY_WEBPLAYER

        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Input.mousePosition;
            castPoint = this.cam.ScreenPointToRay(mousePos);
            if (Physics.Raycast(castPoint, out hit, Mathf.Infinity, hitLayers))
                this.targetPosition = hit.point;
        }
#else

        if (Input.touchCount > 0)
        {
            Touch myTouch = Input.touches[0];
            Vector2 touchPos = myTouch.position;

            castPoint = this.cam.ScreenPointToRay(touchPos);
            if (Physics.Raycast(castPoint, out hit, Mathf.Infinity, hitLayers))
                this.targetPosition = hit.point;
        }

#endif

        if (this.currentPosition.x != this.targetPosition.x)
            this.currentPosition = this.targetPosition;
    }
}
