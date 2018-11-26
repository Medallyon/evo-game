using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class LookForward : MonoBehaviour
{
    #region Public Fields
    #endregion
 
    #region Unity Methods
    void Start()
    {
        this.transform.rotation = Quaternion.LookRotation(-this.transform.forward);
    }
    #endregion
 
    #region Private Methods
    #endregion
}
