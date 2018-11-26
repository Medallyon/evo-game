using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextHoverFade : MonoBehaviour
{
    #region Public Fields
    public float Speed = 1;
    #endregion

    private Text textComponent;
 
    #region Unity Methods
    void Start()
    {
        this.textComponent = this.GetComponent<Text>();
    }
 
    void Update()
    {
        // Float transform upward
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + (1f * this.Speed), this.transform.position.z);

        // Gradually reduce localScale
        this.transform.localScale = new Vector3(this.transform.localScale.x - (.005f * this.Speed), this.transform.localScale.y - (.005f * this.Speed), this.transform.localScale.z - (.005f * this.Speed));
        
        // Fade the Alpha component of this colour
        this.textComponent.color = new Color(this.textComponent.color.r, this.textComponent.color.g, this.textComponent.color.b, this.textComponent.color.a - (.02f * this.Speed));
        
        // Destroy the object when it's completely transparent
        if (this.textComponent.color.a <= 0f)
            Destroy(this.gameObject);
    }
    #endregion
 
    #region Private Methods
    #endregion
}
