using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingGuardScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    float[,] turns = { { 15.5f, 2.5f }, { 15.5f, 4.5f }, { 11.5f, 4.5f }, { 15.5f, 4.5f } };
    int counter = 0;

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = new Vector3(turns[counter, 0], turns[counter, 1], 0);
        transform.position = Vector2.MoveTowards(transform.position, pos, Time.deltaTime * .5f);

        if (transform.position == pos && counter%4 == 1) 
        {
            counter++;
            counter %= 4;
            transform.Rotate(0, 0, 90);
        }

        else if (transform.position == pos && counter%4 == 3)
        {
            counter++;
            counter %= 4;
            transform.Rotate(0, 0, -90);
        }

        else if (transform.position == pos)
        {
            counter++;
            counter %= 4;
            transform.Rotate(0, 0, 180);
        }
    }
}
