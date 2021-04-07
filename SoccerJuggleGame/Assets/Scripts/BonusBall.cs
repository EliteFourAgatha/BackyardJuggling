using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBall : MonoBehaviour
{
    public RectTransform bonusBall1SpawnArea;    
    public RectTransform bonusBall2SpawnArea;
    public GameObject bonusBall1;
    public GameObject bonusBall2;
    public Rigidbody2D bonusBall1RB2D;
    public Rigidbody2D bonusBall2RB2D;

    public GameController gameContScript;

    public bool bonus1CanSpawn;
    public bool bonus2CanSpawn;
    public bool bonusBall1Active;
    public bool bonusBall2Active;

    void Update()
    {
        SpawnBonusBalls();
    }
    public void SpawnBonusBalls()
    {
        if(gameContScript.tapCount % 10 == 0 && gameContScript.tapCount != 0 && !bonusBall1.activeInHierarchy && bonus1CanSpawn == true)
        {
            bonusBall1.transform.position = new Vector3(Random.Range(bonusBall1SpawnArea.rect.xMin, bonusBall1SpawnArea.rect.xMax), 
                                        Random.Range(bonusBall1SpawnArea.rect.yMin, bonusBall1SpawnArea.rect.yMax), 0);
            bonusBall1.SetActive(true);
            StartCoroutine(WaitForBonus1Respawn());
        }
        else if (gameContScript.tapCount % 20 == 0 && gameContScript.tapCount != 0 && !bonusBall2.activeInHierarchy && bonus2CanSpawn == true)
        {
            bonusBall2.transform.position = new Vector3(Random.Range(bonusBall2SpawnArea.rect.xMin, bonusBall2SpawnArea.rect.xMax), 
                                        Random.Range(bonusBall2SpawnArea.rect.yMin, bonusBall2SpawnArea.rect.yMax), 0);
            bonusBall2.SetActive(true);
            StartCoroutine(WaitForBonus2Respawn());
        }
    }
    public void ChangeBonusBallState(int ballNumber, bool state)
    {
        if(ballNumber == 1)
        {
            bonusBall1.SetActive(state);
        }
        else if(ballNumber == 2)
        {
            bonusBall2.SetActive(state);
        }
    }
    IEnumerator WaitForBonus1Respawn()
    {
        bonus1CanSpawn = false;
        yield return new WaitForSeconds(5f);
        bonus1CanSpawn = true;
    }
    IEnumerator WaitForBonus2Respawn()
    {
        bonus2CanSpawn = false;
        yield return new WaitForSeconds(5f);
        bonus2CanSpawn = true;
    }
}
