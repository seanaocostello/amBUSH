using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingGuardScript4 : MonoBehaviour
{
    // Start is called before the first frame update

    public float[] coord = new float[8];
    public float[,] turns = { { 15.5f, 2.5f }, { 15.5f, 4.5f }, { 11.5f, 4.5f }, { 15.5f, 4.5f } };
    int counter = 0;
    int delay = 121;
    public Sprite[] workers = new Sprite[4];
    public int direction = 0;
    public int turnDir = 1;
    // Update is called once per frame

    void Update()
    {
        if (delay > 120)
        {
            Vector3 pos = new Vector3(turns[counter, 0], turns[counter, 1], 0);//new Vector3(coord[counter*2], coord[counter*2+1], 0);
            transform.position = Vector2.MoveTowards(transform.position, pos, Time.deltaTime * .5f);
            if (transform.position == pos && counter % 4 == 1 && turnDir != 0)
            {
                counter++;
                counter %= 4;
                transform.GetChild(0).transform.GetChild(0).Rotate(0, 0, 90*turnDir);
                direction++;
                direction %= 4;
                GetComponentInChildren<SpriteRenderer>().sprite = workers[direction];
            }

            else if (transform.position == pos && counter % 4 == 3 && turnDir != 0)
            {
                counter++;
                counter %= 4;
                transform.GetChild(0).transform.GetChild(0).Rotate(0, 0, -90*turnDir);
                direction += 3;
                direction %= 4;
                GetComponentInChildren<SpriteRenderer>().sprite = workers[direction];
            }

            else if (transform.position == pos)
            {
                delay = 0;
                counter++;
                counter %= 4;
            }
        }
        if (delay == 119)
        {
            direction += 2;
            direction %= 4;
            GetComponentInChildren<SpriteRenderer>().sprite = workers[direction];
            transform.GetChild(0).transform.GetChild(0).Rotate(0, 0, 180);
        }
        delay++;
    }
}
