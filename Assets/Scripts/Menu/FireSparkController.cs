using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class FireSparkController : MonoBehaviour
{
    #region Public Fields
    public GameObject ParentCanvas;
    public GameObject SparkPrefab;
    public Vector2 SpawnPosition;
    #endregion
 
    #region Unity Methods
    IEnumerator Start()
    {
        while (true)
        {
            this.SpawnSpark();
            yield return new WaitForSeconds(Random.Range(.2f, .6f));
        }
    }
    #endregion
 
    #region Private Methods
    private void SpawnSpark()
    {
        GameObject spark = Instantiate(this.SparkPrefab, new Vector3(this.ParentCanvas.transform.position.x + Random.Range(-this.SpawnPosition.x, this.SpawnPosition.x), this.SpawnPosition.y, -.1f), Quaternion.identity);
        spark.transform.SetParent(this.ParentCanvas.transform);
    }
    #endregion
}
