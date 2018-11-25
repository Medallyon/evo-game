using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Axis { X, Y, Z };

public class RotateAroundAxis : MonoBehaviour
{
    #region Public Fields
    public Axis Axis = Axis.X;
    public float Speed = 1;
    #endregion

    private Dictionary<Axis, float> velocities = new Dictionary<Axis, float>()
    {
        { Axis.X, 0 },
        { Axis.Y, 0 },
        { Axis.Z, 0 }
    };
    private Rigidbody rb;
    private Vector3 eulerAngleVelocity;
 
    #region Unity Methods
    void Start()
    {
        this.velocities[this.Axis] = 100;
        this.eulerAngleVelocity = new Vector3(this.velocities[Axis.X], this.velocities[Axis.Y], this.velocities[Axis.Z]);

        this.rb = this.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Quaternion deltaRotation = Quaternion.Euler(this.eulerAngleVelocity * Time.deltaTime * this.Speed);
        this.rb.MoveRotation(this.rb.rotation * deltaRotation);
    }
    #endregion

    #region Private Methods
    #endregion
}
