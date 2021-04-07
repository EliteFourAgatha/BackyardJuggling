using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
    public GameObject gameController;
    AudioSource audioSource;
    GameController gameContScript;
    Rigidbody2D ballRB;
    Vector2 circleCenter;
    public float forceValue = 10f;
    public int silverTaps;
    public int goldTaps;

    void Start()
    {
        ballRB = gameObject.GetComponent<Rigidbody2D>();
        gameContScript = gameController.GetComponent<GameController>();
        audioSource = gameObject.GetComponent<AudioSource>();
        circleCenter = transform.position;
        AddForceOnPlay();  //Give game ball upward vector when game starts        
    }
    public void AddForceOnPlay()
    {
        ballRB.AddForce(Vector2.up * forceValue, ForceMode2D.Impulse);
    }  
    
    public void OnMouseDown()  //If user clicks on object this script is attached to
    {
        audioSource.Play();

        float ballRadius = 1;
        Vector3 ballCenter = transform.position;
        
        //Get random angle value in radians, from 2π/3 (60 deg) to π/3 (120 deg)
        //  X value is random between 60 and 120 so the y value is always positive and ball moves upward
        float randAngle = Random.Range((2f*(Mathf.PI)) / 3, Mathf.PI / 3);
        
        //Get X and Y values of point on circle, chosen from the random angle value
        float x = ballCenter.x + ballRadius * Mathf.Cos(randAngle);
        float y = ballCenter.y + ballRadius * Mathf.Sin(randAngle);
        Vector3 pointOnCircle = new Vector3(x, y, 0);

        //Get vector from center to pointoncircle
        Vector3 dirVector = pointOnCircle - ballCenter;
        
        //Normalize keeps direction but sets length to 1
        dirVector.Normalize();

        //Impulse adds instant forceValue in vector direction
        ballRB.AddForce(dirVector * forceValue, ForceMode2D.Impulse);

        if(gameObject.tag == "Bonus1")
        {
            gameContScript.tapCount += 2;
            silverTaps += 1;
        }
        else if (gameObject.tag == "Bonus2")
        {
            gameContScript.tapCount += 5;
            goldTaps += 1;
        }
        else
        {
            gameContScript.tapCount ++;
        }
    }
}
