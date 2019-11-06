using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;


public class GuardManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GuardScript[] workers = new GuardScript[5];
    public UMovement[] movWorkers = new UMovement[5];
    public int numWorkers = 3;
    //public GameObject[] guard = new GameObject[4];
    public Sprite[] guard = new Sprite[4];
    public Sprite[] office = new Sprite[4];
    public Sprite[] bossS = new Sprite[4];
    public Sprite redCone;
    public GameObject boss;
    public Text numFlowers;
    public Text gameOver;
    public Camera cam;
    public PotRenderer pots;
    public GameObject player;
    public AudioSource timerSound;
    public int level;
    int detection = 0;
    Sprite[] movG = new Sprite[4];
    
    // Update is called once per frame
    void Start()
    {
        //detect.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(false);
        for (int i = numWorkers; i < workers.Length; i++)
        {
            workers[i].gameObject.SetActive(false);
            movWorkers[i].gameObject.SetActive(false);
        }
        movG[0] = guard[0];
        movG[1] = guard[3];
        movG[2] = guard[2];
        movG[3] = guard[1];
    }

    void Update() 
    {
        if (detection != 0)
        {
            if (detection > 90)
            {
                PlayerPrefs.SetInt("EndState", 0);
                UnityEngine.SceneManagement.SceneManager.LoadScene("EndScreen", LoadSceneMode.Single);
                //gameOver.gameObject.SetActive(true);
                //gameOver.text = "Game Over!";
                //counter = 1;
            }
            else
            {
                detection++;
                timerSound.Play();
            }
        }
        else {timerSound.Stop();}
        Color c = cam.backgroundColor;
        c.r = (float)detection / 300 + 0.3f;
        cam.backgroundColor = c;
        numFlowers.text = "Flowers Saved: " + pots.Collected();
        //Debug.Log(boss.gameObject.transform.GetChild(0).gameObject.activeSelf);
        if (!boss.gameObject.transform.GetChild(0).gameObject.activeSelf && boss.activeSelf)
        {
            for (int i = 0; i < numWorkers; i++)
            {
                if (!workers[i].transform.GetChild(0).gameObject.activeSelf)
                {
                    workers[i].transform.GetChild(0).gameObject.SetActive(true);
                    workers[i].workers = guard;
                    workers[i].transform.GetChild(0).GetChild(0).GetComponentInChildren<SpriteRenderer>().sprite = redCone;
                }
                if (!movWorkers[i].transform.GetChild(0).gameObject.activeSelf)
                {
                    movWorkers[i].transform.GetChild(0).gameObject.SetActive(true);
                    movWorkers[i].workers = movG;
                    movWorkers[i].transform.GetChild(0).GetChild(0).GetComponentInChildren<SpriteRenderer>().sprite = redCone;
                }
            }
            for (int i = numWorkers; i < workers.Length; i++)
            {
                workers[i].gameObject.SetActive(true);
                movWorkers[i].gameObject.SetActive(true);
            }
            boss.SetActive(false);
        }
        if (!boss.activeSelf && player.transform.position == new Vector3(-5.5f, 0.5f, 0))
        {
            PlayerPrefs.SetInt("EndState", 1);
            PlayerPrefs.SetInt("FlowersCollected", pots.Collected());
            UnityEngine.SceneManagement.SceneManager.LoadScene("EndScreen", LoadSceneMode.Single);
        }
    }

    public void Detected(int type)
    {
        if (type == 1)
        {
            detection = 1;
        }
        else
        {
            detection = 151;
        }   
    }
    public void NotDetected()
    {
        detection = 0;
    }
}
