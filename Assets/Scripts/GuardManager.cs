using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;


public class GuardManager : MonoBehaviour
{

    public GuardScript[] workers = new GuardScript[5];
    public UMovement[] movWorkers = new UMovement[5];
    public int numWorkers = 3;
    public int numMovWorkers = 3;
    public Sprite[] guard = new Sprite[4];
    public Sprite[] office = new Sprite[4];
    public Sprite[] bossS = new Sprite[4];
    public Sprite redCone;
    public GameObject boss;
    public GameObject door;
    public GameObject door1;
    public Camera cam;
    public PotRenderer pots;
    public GameObject player;
    public AudioSource timerSound;
    public Text objectiveText;
    public int level;
    int detection = 0;
    bool respawn = true;
    Sprite[] movG = new Sprite[4];
    
    void Start()
    {
        for (int i = numWorkers; i < workers.Length; i++)
        {
            workers[i].gameObject.SetActive(false);
        }
        for (int i = numMovWorkers; i < movWorkers.Length; i++)
        {
            movWorkers[i].gameObject.SetActive(false);
        }
        movG[0] = guard[0];
        movG[1] = guard[3];
        movG[2] = guard[2];
        movG[3] = guard[1];
        PlayerPrefs.SetInt("LastLevel", level);
    }

    void Update() 
    {
        if (detection != 0)
        {
            if (detection > 60)
            {
                int currLives = PlayerPrefs.GetInt("LivesLeft");
                PlayerPrefs.SetInt("EndState", 0);
                PlayerPrefs.SetInt("LivesLeft", currLives-1);
                UnityEngine.SceneManagement.SceneManager.LoadScene("EndScreen", LoadSceneMode.Single);
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
        if (door) {if (pots.KeyCollected() == 1){door.SetActive(false);}}
        if(door1) { if (pots.KeyCollected() >= 2) { door1.SetActive(false); } }
        if (!boss.activeSelf && respawn)
        {
            respawn = false;
            for (int i = 0; i < numWorkers; i++)
            {
                if (!workers[i].gameObject.activeSelf)
                {
                    workers[i].GetComponent<GuardScript>().Revive();
                    workers[i].transform.GetChild(0).gameObject.SetActive(true);
                    workers[i].workers = guard;
                    workers[i].transform.GetChild(0).GetChild(0).GetComponentInChildren<SpriteRenderer>().sprite = redCone;
                }
            }
            for (int i = 0; i < numMovWorkers; i++)
            {
                if (!movWorkers[i].gameObject.activeSelf)
                {
                    movWorkers[i].GetComponent<UMovement>().Revive();
                    movWorkers[i].transform.GetChild(0).gameObject.SetActive(true);
                    movWorkers[i].workers = movG;
                    movWorkers[i].transform.GetChild(0).GetChild(0).GetComponentInChildren<SpriteRenderer>().sprite = redCone;
                }
            }
            for (int i = numWorkers; i < workers.Length; i++)
            {
                workers[i].gameObject.SetActive(true);
            }
            for (int i = numMovWorkers; i < movWorkers.Length; i++)
            {
                movWorkers[i].gameObject.SetActive(true);
            }
            objectiveText.text = "Objective: Escape";
        }
        if (!boss.activeSelf && Close(player.transform.position, new Vector3(-5.5f, 0.5f, 0)) && level == 1)
        {
            PlayerPrefs.SetInt("EndState", 1);
            PlayerPrefs.SetInt("FlowersCollected", pots.Collected());
            UnityEngine.SceneManagement.SceneManager.LoadScene("EndScreen", LoadSceneMode.Single);
        }
        if (!boss.activeSelf && Close(player.transform.position, new Vector3(-13.5f, -0.5f, 0)) && level == 2)
        {
            PlayerPrefs.SetInt("EndState", 1);
            PlayerPrefs.SetInt("FlowersCollected", pots.Collected());
            UnityEngine.SceneManagement.SceneManager.LoadScene("EndScreen", LoadSceneMode.Single);
        }
        if (!boss.activeSelf && Close(player.transform.position, new Vector3(-18.5f, -0.5f, 0)) && level == 3)
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

    bool Close(Vector3 a, Vector3 b)
    {
        if (Mathf.Abs(a.x - b.x) > 0.1)
        {
            return false;
        }
        if (Mathf.Abs(a.y - b.y) > 0.1)
        {
            return false;
        }
        if (Mathf.Abs(a.z - b.z) > 0.1)
        {
            return false;
        }
        return true;
    }
}
