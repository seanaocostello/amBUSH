using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardScript : MonoBehaviour
{
    public Sprite[] workers = new Sprite[4];
    public int direction = 0;
    // Start is called before the first frame update

    int counter = 0;
    int killCounter = 0;
    // Update is called once per frame
    void Start()
    {
        counter = 0;
        killCounter = 0;
    }
    void Update()
    {
        if (transform.GetChild(0).gameObject.activeSelf)
        {
            if (counter % 240 == 0)
            {
                transform.GetChild(0).transform.GetChild(0).Rotate(0, 0, -90);
                direction++;
                direction %= 4;
                GetComponentInChildren<SpriteRenderer>().sprite = workers[direction];
            }
            counter++;
        }
        if (killCounter != 0)
        {
            if (killCounter > 120)
            {
                gameObject.SetActive(false);
            }
            GetComponentInChildren<SpriteRenderer>().color = new Color(1, 0, 0);
            GetComponentInChildren<BoxCollider2D>().enabled = false;
            transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
            killCounter++;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Detected");
    }

    public void Kill()
    {
        killCounter = 1;
    }

    public void Revive()
    {
        killCounter = 0;
        gameObject.SetActive(true);
        GetComponentInChildren<SpriteRenderer>().color = new Color(1, 1, 1);
        GetComponentInChildren<BoxCollider2D>().enabled = true;
        transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
        transform.GetChild(0).gameObject.SetActive(true);
    }
}