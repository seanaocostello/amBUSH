using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    Vector3 pos;
    public float speed =5.0f;
    float vMove, hMove;
    public GameObject cam;
    public Tilemap tilemap;
    public GameObject boss;
    public bool vertical = false;

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        cam.transform.position = new Vector3(transform.position.x, 1f, - 10);
        if ((Input.GetAxis("Vertical") != 0) && Close(transform.position, pos))
        {
            if (Input.GetAxis("Vertical") > 0)
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position + Vector3.up, Vector3.up);
                Debug.Log(hit.collider.gameObject.name);
                if (hit.distance != 0 || hit.collider.gameObject.name == "Sightbox" || hit.collider.gameObject.name == "Pots")
                {
                    pos += Vector3.up;
                }
            }
            else
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position + Vector3.down, Vector3.down);
                if (hit.distance != 0 || hit.collider.gameObject.name == "Sightbox" || hit.collider.gameObject.name == "Pots")
                {
                    pos += Vector3.down;
                }
            }
        }
        if ((Input.GetAxis("Horizontal") != 0) && Close(transform.position, pos))
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position + Vector3.right, Vector3.right);
                if (hit.distance != 0 || hit.collider.gameObject.name == "Sightbox" || hit.collider.gameObject.name == "Pots")
                {
                    pos += Vector3.right;
                }
            }
            else
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position + Vector3.left, Vector3.left);
                if (hit.distance != 0 || hit.collider.gameObject.name == "Sightbox" || hit.collider.gameObject.name == "Pots")
                {
                    pos += Vector3.left;
                }
            }
        }
        GetComponent<Rigidbody2D>().position = Vector2.MoveTowards(transform.position, pos, Time.deltaTime * speed);
        if (Input.GetAxis("Submit") != 0)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position + Vector3.up, Vector3.up);
            RaycastHit2D hit1 = Physics2D.Raycast(transform.position + Vector3.right, Vector3.right);
            RaycastHit2D hit2 = Physics2D.Raycast(transform.position + Vector3.down, Vector3.down);
            RaycastHit2D hit3 = Physics2D.Raycast(transform.position + Vector3.left, Vector3.left);
            if (hit.distance == 0 && hit.collider.gameObject.name == "Guard")
            {
                hit.collider.gameObject.SetActive(false);
            }
            if (hit1.distance == 0 && hit1.collider.gameObject.name == "Guard")
            {
                hit1.collider.gameObject.SetActive(false);
            }
            if (hit2.distance == 0 && hit2.collider.gameObject.name == "Guard")
            {
                hit2.collider.gameObject.SetActive(false);

            }
            if (hit3.distance == 0 && hit3.collider.gameObject.name == "Guard")
            {
                hit3.collider.gameObject.SetActive(false);
            }
        }
        Vector3Int gridPos = tilemap.WorldToCell(transform.position);
        if (tilemap.HasTile(gridPos))
        {
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            GetComponent<CircleCollider2D>().enabled = true;
            GetComponent<SpriteRenderer>().enabled = true;
        }
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
