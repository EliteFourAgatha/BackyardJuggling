using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Sprite[] ballArray = new Sprite[8];
    public Sprite[] flagArray = new Sprite[8];

    public GameObject ballMenuSpawnPoint;
    public GameObject flagSpawnPoint;
    public GameObject gameBall;
    public GameObject background;

    public AudioSource gameBallAudio;
    public AudioSource bonusBall1Audio;
    public AudioSource bonusBall2Audio;
    public AudioSource backgroundAudio;

    public Image mainMenuBallImage;

    GameObject bonusBall1;
    GameObject bonusBall2;

    public GameController gameController;
    public ChangeBG changeBGScript;

    Image optionsMenuBallImage;
    Image flagImage;

    SpriteRenderer gameBallSR;
    public SpriteRenderer bonusBall1SR;
    public SpriteRenderer bonusBall2SR;

    //ballMenuImage array index
    int i = 0;
    //flatImage array index
    int j = 0;
    void Start()
    {
        optionsMenuBallImage = ballMenuSpawnPoint.GetComponent<Image>();
        flagImage = flagSpawnPoint.GetComponent<Image>();
        gameBallSR = gameBall.GetComponent<SpriteRenderer>();
        bonusBall1 = GameObject.FindGameObjectWithTag("Bonus1");
        bonusBall2 = GameObject.FindGameObjectWithTag("Bonus2");

        optionsMenuBallImage.color = new Color(255, 255, 255, 1f);
        flagImage.color = new Color(255, 255, 255, 1f);
        optionsMenuBallImage.sprite = ballArray[0];
        flagImage.sprite = flagArray[0];
    }    
    void Update()
    {
        optionsMenuBallImage.sprite = ballArray[i];
        flagImage.sprite = flagArray[j];
    }
    public void PressRightArrow()
    {
        //Keep index in bounds of array
        if(i < 7)
        {
            i++;
        }
        if(j < 7)
        {
            j++;
        }
    }
    public void PressLeftArrow()
    {
        //Keep index in bounds of array
        if (i > 0)
        {
            i--;
        }
        if (j > 0)
        {
            j--;
        }
    }
    public void SetCurrentBallChoice()
    {
        gameBallSR.sprite = ballArray[i];
        if(bonusBall1SR != null)
        {
            bonusBall1SR.sprite = ballArray[i];
        }
        if(bonusBall2SR != null)
        {
            bonusBall2SR.sprite = ballArray[i];
        }
        if(mainMenuBallImage != null)
        {
            mainMenuBallImage.sprite = ballArray[i];
        }
    }
    public void SFXSliderChanged(bool newValue)
    {
        gameBallAudio.enabled = newValue;
        bonusBall1Audio.enabled = newValue;
        bonusBall2Audio.enabled = newValue;
        //enable for other sfx here if you add them (coin sound, whistle, kick for saved by shoe, etc.)
    }
    public void BGMSliderChanged(bool newValue)
    {
        if(newValue == true)
        {
            changeBGScript.SetBGM(true);
            changeBGScript.SetAmbience(false);
        }
        else
        {
            changeBGScript.SetBGM(false);
        }
    }
    public void AmbienceSliderChange(bool newValue)
    {
        if(newValue == true)
        {
            changeBGScript.SetAmbience(true);
            changeBGScript.SetBGM(false);
        }
        else
        {
            changeBGScript.SetAmbience(false);
        }
    }
}
