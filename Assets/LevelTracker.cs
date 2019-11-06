using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTracker : MonoBehaviour
{
    // Start is called before the first frame update
    public int level;
    void Start()
    {
        level = 1;
    }

    // Update is called once per frame
    public void IncrementLevel()
    {
        level++;
    }
}
