using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Sighted : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
    }

    // Update is called once per frame
    public GameObject guardManager;

    public Transform tileMap;
    void Start()
    {
        guardManager = GameObject.Find("GuardManager");
        GameObject grid = GameObject.Find("Grid");
        tileMap = grid.transform.GetChild(0);
    }

    void Update()
    {
        if (transform.localRotation.z == 0)
        {
            if (tileMap.gameObject.GetComponent<Tilemap>().GetTile(Vector3Int.RoundToInt(transform.position + Vector3.up)) != null)
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
            }
        }
        else if (transform.localRotation.z == 90)
        {
            if (tileMap.gameObject.GetComponent<Tilemap>().GetTile(Vector3Int.RoundToInt(transform.position + Vector3.left)) != null)
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
            }
        }
        else if (transform.localRotation.z == 180)
        {
            if (tileMap.gameObject.GetComponent<Tilemap>().GetTile(Vector3Int.RoundToInt(transform.position + Vector3.down)) != null)
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
            }
        }
        else if (transform.localRotation.z == -90)
        {
            if (tileMap.gameObject.GetComponent<Tilemap>().GetTile(Vector3Int.RoundToInt(transform.position + Vector3.right)) != null)
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col) {

        if (GetComponent<SpriteRenderer>().sprite.name == "coneofvisionwide")
        {
            guardManager.GetComponent<GuardManager>().Detected(1);
            GetComponentInParent<UMovement>().Stop();
        }
        else
        {
            guardManager.GetComponent<GuardManager>().Detected(0);
            //GetComponentInParent<LMovement>().Stop();
        }
        /* if (col.gameObject.tag == "Player") {
            Debug.Log("Player sighted!!!");
        }*/
    }
    void OnTriggerExit2D(Collider2D col)
    {
        guardManager.GetComponent<GuardManager>().NotDetected();
        GetComponentInParent<UMovement>().Go();
    }



}
