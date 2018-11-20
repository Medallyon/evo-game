using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    public float Speed;

    private Rigidbody rb;
    private Transform target;

    void Start()
    {
        this.rb = this.GetComponent<Rigidbody>();
        this.target = GameObject.Find("Player").transform;

        this.transform.LookAt(this.target.transform);
        this.rb.AddRelativeForce(Vector3.forward * this.Speed, ForceMode.Impulse);
    }

    //void Update()
    //{
    //    float step = this.Speed * Time.deltaTime;
    //    this.transform.position = Vector3.MoveTowards(this.transform.position, this.target.position, step);
    //}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
            return;

        Destroy(this.gameObject);
    }
}
