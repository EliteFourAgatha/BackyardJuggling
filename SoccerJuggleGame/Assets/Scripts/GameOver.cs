using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject gameController;
    public GameObject shoeUI;
    public GameObject shoe2UI;
    public GameObject shoe3UI;

    GameController gameContScript;
    public Shoe shoeScript;

    string shoeString;
    void Start()
    {
        gameContScript = gameController.GetComponent<GameController>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "GameBall")
        {
            if(shoeUI.activeInHierarchy || shoe2UI.activeInHierarchy || shoe3UI.activeInHierarchy)
            {
                shoeUI.SetActive(false);
                shoe2UI.SetActive(false);
                shoe3UI.SetActive(false);
                gameContScript.EnableGameOverMenu();              
            }
            else
            {
                gameContScript.EnableGameOverMenu();
            }

        }
        else if (other.tag == "Bonus1")
        {
            other.gameObject.GetComponent<TouchInput>().silverTaps = 0;
            other.gameObject.SetActive(false);
        }
        else if (other.tag == "Bonus2")
        {
            other.gameObject.GetComponent<TouchInput>().goldTaps = 0;
            other.gameObject.SetActive(false);
        }
    }
}
