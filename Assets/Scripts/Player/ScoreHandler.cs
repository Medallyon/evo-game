using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
 
public class ScoreHandler : MonoBehaviour
{
    #region Public Fields
    public float ScoreToWin = 1000;
    public GameObject Canvas;
    public Text TextPrefab;
    #endregion

    private float currentScore = 0;
    private Text textScore;
 
    #region Unity Methods
    void Start()
    {
        GameObject TextBox = new GameObject("Text_Score");
        TextBox.transform.parent = this.Canvas.transform;
        this.textScore = TextBox.AddComponent<Text>();

        Rect dims = this.GetCameraDimensions();
        RectTransform BoxTransform = TextBox.GetComponent<RectTransform>();
        BoxTransform.sizeDelta = new Vector2(200, 28);
        TextBox.transform.localPosition = new Vector3(-((dims.width * Screen.width) / 2) + (BoxTransform.sizeDelta.x / 2) + 10, ((dims.height * Screen.height) / 2) - (BoxTransform.sizeDelta.y * 1.5f) - 10);

        this.textScore.color = this.TextPrefab.color;
        this.textScore.font = this.TextPrefab.font;
        this.textScore.fontSize = this.TextPrefab.fontSize;
        this.textScore.fontStyle = this.TextPrefab.fontStyle;
        this.textScore.lineSpacing = this.TextPrefab.lineSpacing;

        Outline outline = this.textScore.gameObject.AddComponent<Outline>();
        outline = this.TextPrefab.GetComponent<Outline>();

        this.textScore.text = "Score: " + this.currentScore;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Edible")
            return;
        
        List<ObstacleMover> movingObjects = FindObjectsOfType<ObstacleMover>().ToList();
        ObstacleMover wantedObject = movingObjects.Find(x => x.GetComponent<Collider>() == other);
        this.currentScore += wantedObject.Score;

        this.textScore.text = "Score: " + (int)this.currentScore;
    }
    #endregion

    #region Private Methods
    private Rect GetCameraDimensions()
    {
        // determine the game window's current aspect ratio
        float windowaspect = (float)Screen.width / (float)Screen.height;

        // current viewport height should be scaled by this amount
        float scaleheight = windowaspect / (9f / 16f);

        Rect rect = new Rect();

        // if scaled height is less than current height, add letterbox
        if (scaleheight < 1.0f)
        {
            rect.width = 1.0f;
            rect.height = scaleheight;
            rect.x = 0;
            rect.y = (1.0f - scaleheight) / 2.0f;
        }
        else // add pillarbox
        {
            float scalewidth = 1.0f / scaleheight;

            rect.width = scalewidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scalewidth) / 2.0f;
            rect.y = 0;
        }

        Debug.Log(rect.x + ", " + rect.y);
        return rect;
    }
    #endregion
}
