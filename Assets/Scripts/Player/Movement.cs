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
    private Rect boundary;

	// Use this for initialization
	void Start()
    {
        this.cam = Camera.main;

        Vector3 boundaryPosition = GameObject.Find("BackgroundPlane").transform.position;
        Vector3 boundarySize = GameObject.Find("BackgroundPlane").GetComponent<Renderer>().bounds.size;
        this.boundary = new Rect(boundaryPosition.x, boundaryPosition.z, boundarySize.x, boundarySize.z);
        Debug.Log(this.boundary);
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

        // Return and don't move if player touch is too far from current position to prevent cheating
        if (this.targetPosition.x > this.currentPosition.x + 3f || this.targetPosition.x < this.currentPosition.x - 3f)
            return;

        // Return and don't move if target position / finger is outside of play bounds
        if (this.targetPosition.x < this.boundary.x - (this.boundary.width / 4) || this.targetPosition.x > (this.boundary.x + this.boundary.width / 4))
            return;

        // Move if the target position is different from the current position
        if (this.currentPosition.x != this.targetPosition.x)
            this.currentPosition = this.targetPosition;
    }
}
