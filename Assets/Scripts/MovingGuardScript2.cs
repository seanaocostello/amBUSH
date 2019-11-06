using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingGuardScript2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    float[,] turns = { { 15.5f, .5f }, { 15.5f, -3.5f }, { 11.5f, -3.5f }, { 15.5f, -3.5f } };
    int counter = 0;
    int delay = 121;
    public Sprite[] workers = new Sprite[4];
    public int direction = 0;
    // Update is called once per frame
    void Update()
    {
        if (delay > 120)
        {
            Vector3 pos = new Vector3(turns[counter, 0], turns[counter, 1], 0);
            RaycastHit2D hit = Physics2D.Raycast(transform.position + (pos - transform.position).normalized / 2, (pos - transform.position).normalized);

            //Debug.Log(hit.collider.gameObject.name);
            if (hit.distance != 0 || hit.collider.gameObject.name != "Player")
            {
                transform.position = Vector2.MoveTowards(transform.position, pos, Time.deltaTime * .5f);
            }
            if (transform.position == pos && counter % 4 == 3)
            {
                counter++;
                counter %= 4;
                transform.GetChild(0).transform.GetChild(0).Rotate(0, 0, 90);
                direction++;
                direction %= 4;
                GetComponentInChildren<SpriteRenderer>().sprite = workers[direction];
            }

            else if (transform.position == pos && counter % 4 == 1)
            {
                counter++;
                counter %= 4;
                transform.GetChild(0).transform.GetChild(0).Rotate(0, 0, -90);
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
        Debug.Log("P");
    }
}
