using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour
{
    public Image content;
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
            this.content.fillAmount = this.sh.currentScore / 500;
        else
            this.content.fillAmount = this.sh.currentScore / 1000;
	}
}
