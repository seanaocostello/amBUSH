using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public float[] coord = new float[12];
    public int[] turnDir = new int[6];
    public Sprite[] workers = new Sprite[4];
    public int direction = 0;
    int counter = 0;
    int delay = 121;
    int killCounter = 0;
    public int turns;
    bool go = true;
    // Update is called once per frame
    void Update()
    {
        if (transform.GetChild(0).gameObject.activeSelf)
        {
            if (delay > 120)
            {
                Vector3 pos = new Vector3(coord[counter * 2], coord[counter * 2 + 1], 0);
                if (go)
                {
                    transform.position = Vector2.MoveTowards(transform.position, pos, Time.deltaTime * .5f);
                }
                if (transform.position == pos && turnDir[counter] != 0)
                {
                    transform.GetChild(0).transform.GetChild(0).Rotate(0, 0, -turnDir[counter]*90);
                    direction += 2 + turnDir[counter];
                    direction %= 4;
                    GetComponentInChildren<SpriteRenderer>().sprite = workers[direction];
                    counter++;
                    counter %= turns;
                }
                else if (transform.position == pos)
                {
                    delay = 0;
                }
            }
            if (delay == 119)
            {
                transform.GetChild(0).transform.GetChild(0).Rotate(0, 0, 180);
                direction += 2;
                direction %= 4;
                GetComponentInChildren<SpriteRenderer>().sprite = workers[direction];
                counter++;
                counter %= turns;
            }
            delay++;
            if (killCounter != 0)
            {
                if (killCounter > 120)
                {
                    gameObject.SetActive(false);
                }
                GetComponentInChildren<SpriteRenderer>().color = new Color(1, 0, 0);
                GetComponentInChildren<BoxCollider2D>().enabled = false;
                transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
                go = false;
                killCounter++;
            }
        }
    }
    public void Stop() { go = false; }
    public void Go() { go = true; }
    public void Kill() { killCounter = 1; }
    public void Revive()
    {
        killCounter = 0;
        gameObject.SetActive(true);
        GetComponentInChildren<SpriteRenderer>().color = new Color(1, 1, 1);
        GetComponentInChildren<BoxCollider2D>().enabled = true;
        transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
        transform.GetChild(0).gameObject.SetActive(true);
        Go();
    }
}
