using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class EvolutionController : MonoBehaviour
{
    #region Public Fields
    public string NextLevel;
    public GameObject Parent1;
    public GameObject ModelPrefab1;
    public GameObject Parent2;
    public GameObject ModelPrefab2;
    public GameObject EvolutionText;
    #endregion

    private bool confirmedEvolution = false;
    private float nextLevelCooldown = 3f;
    private GameObject model2;

    #region Unity Methods
    void Start()
    {
        Instantiate(ModelPrefab1, this.Parent1.transform);
    }
 
    void Update()
    {
        if (this.Parent1.transform.position.y >= 0f && !this.confirmedEvolution)
        {
        #if UNITY_STANDALONE || UNITY_WEBPLAYER
            if (Input.GetMouseButton(0))
                this.confirmedEvolution = true;
        #else
            if (Input.touchCount > 0)
                this.confirmedEvolution = true;
        #endif
        }

        if (this.Parent1.transform.position.y < 0f)
        {
            this.Parent1.transform.position = new Vector3(this.Parent1.transform.position.x, this.Parent1.transform.position.y + .1f, this.Parent1.transform.position.z);
        }
        else if (this.Parent1.transform.localScale.x >= 0f && this.confirmedEvolution)
        {
            this.Parent1.transform.localScale = new Vector3(this.Parent1.transform.localScale.x - .01f, this.Parent1.transform.localScale.y - .01f, this.Parent1.transform.localScale.z - .01f);
        }

        if (this.Parent1.transform.localScale.x <= 0f)
        {
            if (this.Parent1.transform.localScale.x < 0f)
                this.Parent1.transform.localScale = new Vector3(0f, 0f, 0f);

            if (this.model2 == null)
            {
                this.model2 = Instantiate(this.ModelPrefab2, this.Parent2.transform);
                this.EvolutionText.SetActive(true);
            }

            if (this.nextLevelCooldown > 0f)
                this.nextLevelCooldown -= Time.deltaTime;
            else
                SceneManager.LoadSceneAsync(this.NextLevel);
        }
    }
    #endregion
 
    #region Private Methods
    #endregion
}
