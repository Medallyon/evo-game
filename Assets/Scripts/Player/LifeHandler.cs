using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class LifeHandler : MonoBehaviour
{
    #region Public Fields
    public int Lives = 5;
    public GameObject Canvas;
    public Text TextPrefab;
    #endregion

    private Text textLives;

    #region Unity Methods
    void Start()
    {
        GameObject TextBox = new GameObject("Text_Score");
        TextBox.transform.parent = this.Canvas.transform;
        this.textLives = TextBox.AddComponent<Text>();

        Rect dims = this.GetCameraDimensions();
        RectTransform BoxTransform = TextBox.GetComponent<RectTransform>();
        BoxTransform.sizeDelta = new Vector2(200, 28);
        TextBox.transform.localPosition = new Vector3(-((dims.width * Screen.width) / 2) + (BoxTransform.sizeDelta.x / 2) + 10, ((dims.height * Screen.height) / 2) - (BoxTransform.sizeDelta.y / 2) - 10);

        this.textLives.color = this.TextPrefab.color;
        this.textLives.font = this.TextPrefab.font;
        this.textLives.fontSize = this.TextPrefab.fontSize;
        this.textLives.fontStyle = this.TextPrefab.fontStyle;
        this.textLives.lineSpacing = this.TextPrefab.lineSpacing;

        Outline outline = this.textLives.gameObject.AddComponent<Outline>();
        outline = this.TextPrefab.GetComponent<Outline>();

        this.textLives.text = "Lives: " + this.Lives;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Obstacle")
            return;

        this.DecreaseLives();
    }
    #endregion

    #region Private Methods
    private void DecreaseLives()
    {
        this.Lives--;

        // Implement UI-specific code (i.e. 5 -> 4 hearts)
        this.textLives.text = "Lives: " + this.Lives;

        if (this.Lives <= 0)
        {
            // End level and display Score
            Destroy(this.gameObject);
        }
    }

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
