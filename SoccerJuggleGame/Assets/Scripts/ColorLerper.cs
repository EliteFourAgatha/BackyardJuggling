using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorLerper : MonoBehaviour
{
    public float lerpSpeed = 3f;
    public Color lerpedColor = Color.white;
    float startTime;
    float t;
    public SpriteRenderer ringRenderer;
    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        lerpedColor = Color.Lerp(Color.red, Color.green, Mathf.PingPong(Time.time, lerpSpeed));
        ringRenderer.color = lerpedColor;
    }
    public void DisableRing()
    {
        gameObject.SetActive(false);
    }
}
