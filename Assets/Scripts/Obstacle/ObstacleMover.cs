using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    public float Speed;
    public float Score = 100;
    
    private Transform target;
    private int frames = 0;
    private Queue<Vector3> previousTargetPositions = new Queue<Vector3>();

    void Start()
    {
        this.target = GameObject.Find("Player").transform;
        this.Score = Random.value * this.Score;
    }

    void Update()
    {
        this.previousTargetPositions.Enqueue(this.target.position);

        float step = this.Speed * Time.deltaTime;
        Vector3 targetPos = this.previousTargetPositions.Peek();

        if (this.transform.position.z < this.target.position.z + 1)
            targetPos = new Vector3(this.target.position.x, 1, this.target.position.z - 10);
        this.transform.position = Vector3.MoveTowards(this.transform.position, targetPos, step);

        this.frames++;
        if (this.frames == 2)
        {
            this.previousTargetPositions.Dequeue();
            this.frames = 0;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
            return;

        Destroy(this.gameObject);
    }
}
