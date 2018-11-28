using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour {
    [SerializeField]
    private float fillAmount;

    [SerializeField]
    private Image content;

    private ScoreHandler sh;

	// Use this for initialization
	void Start ()
    {
        this.sh = FindObjectOfType<ScoreHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        var currentLevel = this.gameObject.scene.name;
        if (currentLevel.EndsWith("1"))
            this.fillAmount = this.sh.currentScore / 500;
        else
            this.fillAmount = this.sh.currentScore / 1000;
        HandleBar();
	}
    private void HandleBar()
    {
        content.fillAmount = fillAmount;
    }
}
