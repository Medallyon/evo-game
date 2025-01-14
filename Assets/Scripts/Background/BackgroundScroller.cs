﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    // Scroll main texture based on time

    public float ScrollSpeed = 1f;
    Renderer rend;

    void Start()
    {
        this.rend = GetComponent<Renderer>();
    }

    void Update()
    {
        float offset = Time.time * (this.ScrollSpeed / 100);
        this.rend.material.SetTextureOffset("_MainTex", new Vector2(0, offset));
    }
}
