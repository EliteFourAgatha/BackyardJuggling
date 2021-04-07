using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoe : MonoBehaviour
{
    public GameObject ShoeUI;
    public GameObject Shoe2UI;
    public GameObject Shoe3UI;
    public GameObject actualShoe;

    AudioSource audioSource;

    public GameObject gameBall;

    public GameController gameContScript;

    public int shoeCount;
    bool shoeCanSpawn = true;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        ShoeUI.SetActive(true);
        Shoe2UI.SetActive(true);
        Shoe3UI.SetActive(true);
        shoeCount = 3;
        Debug.Log(shoeCount);
    }

    //Spawn shoe under ball if it enters the shoe zone
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "GameBall")
        {
            if(shoeCount == 3)
            {
                if(shoeCanSpawn == true)
                {
                    ShoeUI.SetActive(false);
                    shoeCount --;
                    Debug.Log(shoeCount);
                    GameObject shoe = Instantiate(actualShoe, other.gameObject.GetComponent<CircleCollider2D>().ClosestPoint(transform.position), 
                                                            Quaternion.identity);
                    audioSource.Play();
                    Destroy(shoe, 1f);
                    StartCoroutine(WaitForShoeRespawn());
                }
            }
            else if(shoeCount == 2)
            {
                if(shoeCanSpawn == true)
                {
                    Shoe2UI.SetActive(false);
                    shoeCount --;
                    Debug.Log(shoeCount);
                    GameObject shoe = Instantiate(actualShoe, other.gameObject.GetComponent<CircleCollider2D>().ClosestPoint(transform.position), 
                                                            Quaternion.identity);
                    audioSource.Play();
                    Destroy(shoe, 1f);
                    StartCoroutine(WaitForShoeRespawn());
                }
            }
            else if(shoeCount == 1)
            {
                if(shoeCanSpawn == true)
                {
                    Shoe3UI.SetActive(false);
                    shoeCount --;
                    Debug.Log(shoeCount);
                    GameObject shoe = Instantiate(actualShoe, other.gameObject.GetComponent<CircleCollider2D>().ClosestPoint(transform.position), 
                                                            Quaternion.identity);
                    audioSource.Play();
                    Destroy(shoe, 1f);
                    StartCoroutine(WaitForShoeRespawn());
                }
            }
        }
    }

    IEnumerator WaitForShoeRespawn()
    {
        shoeCanSpawn = false;
        yield return new WaitForSeconds(3);
        shoeCanSpawn = true;
    }
}
