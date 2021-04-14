using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorLerper : MonoBehaviour
{
    public float lerpSpeed = 3f;
    Color lerpedColor;
    public SpriteRenderer ringRenderer;

    void Update()
    {
        LerpRingColor();
    }
    public void LerpRingColor()
    {
        //Lerp color between red and green on timer using PingPong
        lerpedColor = Color.Lerp(Color.red, Color.green, Mathf.PingPong(Time.time, lerpSpeed));
        ringRenderer.color = lerpedColor;
    }
}