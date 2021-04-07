using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text tapCountText;
    public Text gameOverCountText;
    public Text gameOverRecordText;

    public GameObject gameOverMenu;
    public GameObject ballStartPoint;
    public GameObject mainMenu;
    public GameObject gameHUD;
    public GameObject pauseMenu;
    public GameObject optionsMenu;
    public GameObject rulesMenu;
    public GameObject gameCredits;
    public GameObject gameBall;
    public GameObject bonusBall1;
    public GameObject bonusBall2;

    public GameObject ShoeUI;
    public GameObject Shoe2UI;
    public GameObject Shoe3UI;

    public Rigidbody2D gameBallRB2D;

    public AudioSource backgroundAudio;
    SpriteRenderer gameBallSR;

    public ChangeBG changeBGScript;
    public SaveLoad saveLoadScript;
    BonusBall bonusBallScript;
    public Shoe shoeScript;

    public int tapCount;

    int tapRecord;
    bool gamePaused = false;
    bool doneSaving;
    
    void Start()
    {
        gameBallRB2D = gameBall.GetComponent<Rigidbody2D>();
        bonusBallScript = gameObject.GetComponent<BonusBall>();
        tapRecord = saveLoadScript.ReadRecordFromFile();
        changeBGScript.StartBGM();
    }
    void Update()
    {
        CompareCountToRecord();
        tapCountText.text = tapCount.ToString();
    }
    public void CompareCountToRecord()
    {
        if(tapCount >= tapRecord)
        {
            tapRecord = tapCount;
        }
    }
    public void SetNewTapRecord(int newRecord)
    {
        if (newRecord > tapRecord)
        {
            tapRecord = newRecord;
            saveLoadScript.SaveRecordToFile(newRecord);
        }
    }
    public void EnableGameOverMenu()
    {
        Time.timeScale = 0;
        bonusBallScript.ChangeBonusBallState(1, false);
        bonusBallScript.ChangeBonusBallState(2, false);
        changeBGScript.StopBGM();
        gameBallRB2D.gravityScale = 0f;
        gameHUD.SetActive(false);
        gameBall.SetActive(false);
        SetNewTapRecord(tapRecord);

        gameOverCountText.text = tapCount.ToString();
        gameOverRecordText.text = tapRecord.ToString();
        gameOverMenu.SetActive(true);        
    }

    //Menu Buttons    
    public void EnableOptionsMenu()  // Pause / Main Menus to Options Menu
    {
        gameBall.SetActive(false);
        pauseMenu.SetActive(false);
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }    
    public void EnableMainMenu()  // Options Menu to Main Menu
    {
        optionsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
    public void EnableRulesMenu()
    {
        mainMenu.SetActive(false);
        rulesMenu.SetActive(true);
    }
    public void EnableCredits()
    {
        gameCredits.SetActive(true);
    }
    public void DisableCredits()
    {
        gameCredits.SetActive(false);
    }
    public void PlayGame()
    {
        tapCount = 0;
        shoeScript.shoeCount = 3;
        gameBall.transform.position = ballStartPoint.transform.position;
        gameBallRB2D.gravityScale = 0.85f;
        mainMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        rulesMenu.SetActive(false);

        gameHUD.SetActive(true);
        ShoeUI.SetActive(true);
        Shoe2UI.SetActive(true);
        Shoe3UI.SetActive(true);

        gameBall.SetActive(true);
        bonusBallScript.bonus1CanSpawn = true;
        bonusBallScript.bonus2CanSpawn = true;
        
        if(changeBGScript.bgmEnabled == true)
        {
            changeBGScript.StartBGM();
        }
        if (changeBGScript.ambienceEnabled == true)
        {
            changeBGScript.StartBGM();
        }
        Time.timeScale = 1;
    }
    public void PauseGame()
    {
        gamePaused = true;
        Time.timeScale = 0;
        changeBGScript.StopBGM();
        gameBall.SetActive(false);
        if(bonusBall1.activeInHierarchy)
        {
            bonusBallScript.bonusBall1Active = true;
            bonusBallScript.ChangeBonusBallState(1, false);
        }
        if(bonusBall2.activeInHierarchy)
        {
            bonusBallScript.bonusBall2Active = true;
            bonusBallScript.ChangeBonusBallState(2, false);
        }
        gameHUD.SetActive(false);
        pauseMenu.SetActive(true);
    }
    public void UnpauseGame()
    {
        gamePaused = false;
        Time.timeScale = 1;
        if(changeBGScript.CheckBGM() == true)
        {
            changeBGScript.StartBGM();
        }
        if(changeBGScript.CheckAmbience() == true)
        {
            changeBGScript.StartBGM();
        }
        gameBall.SetActive(true);
        if(bonusBallScript.bonusBall1Active == true)
        {
            bonusBallScript.ChangeBonusBallState(1, true);
        }
        if(bonusBallScript.bonusBall2Active == true)
        {
            bonusBallScript.ChangeBonusBallState(2, true);
        }
        gameHUD.SetActive(true);
        pauseMenu.SetActive(false);
    }
    public void QuitGame()
    {
        saveLoadScript.SaveRecordToFile(tapRecord);
        if(saveLoadScript.doneSaving)
        {
            Application.Quit();
        }
    }
    public void PressBackButton()
    {
        // Options Menu to Pause Menu, mid-game
         if (gamePaused == true)
         {
            optionsMenu.GetComponent<OptionsMenu>().SetCurrentBallChoice();
            optionsMenu.SetActive(false);
            pauseMenu.SetActive(true);
         }
        // Options Menu to Main Menu
         else
         {
            optionsMenu.GetComponent<OptionsMenu>().SetCurrentBallChoice();
            optionsMenu.SetActive(false);
            mainMenu.SetActive(true);
         }
    }
    //End Menu Buttons
    public void IncreaseGravity()
    {

    }
}
