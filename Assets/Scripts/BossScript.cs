using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    float [,] turns = { { 22.5f, -2.5f }, { 20.5f, -2.5f }, { 20.5f, 3.5f }, { 22.5f, 3.5f } };
    int counter = 0;
    public Sprite[] workers = new Sprite[4];
    public int direction = 0;
    // Update is called once per frame
    void Update()
    {
        if (transform.GetChild(0).gameObject.activeSelf)
        {
            Vector3 pos = new Vector3(turns[counter, 0], turns[counter, 1], 0);
            transform.position = Vector2.MoveTowards(transform.position, pos, Time.deltaTime * 2);
            if (transform.position == pos)
            {
                counter++;
                counter %= 4;
                transform.GetChild(0).transform.GetChild(0).Rotate(0, 0, -90);
                direction++;
                direction %= 4;
                GetComponentInChildren<SpriteRenderer>().sprite = workers[direction];
            }
        }
    }
}
