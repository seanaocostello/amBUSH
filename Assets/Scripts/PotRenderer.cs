using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PotRenderer : MonoBehaviour
{
    public bool flowers;
    public Sprite flower, pot;
    public GameObject player;
    int counter = 0, keys=0;

    void Update()
    {
        Tilemap grid = GetComponent<Tilemap>();
        Vector3Int pos = grid.WorldToCell(player.transform.position);
        if (grid.HasTile(pos))
        {
            if (grid.GetSprite(pos).name == "pink pot")
            {
                Tile t = ScriptableObject.CreateInstance<Tile>();
                t.sprite = pot;
                grid.SetTile(pos, t);
                counter++;
            }

            if (grid.GetSprite(pos).name == "key")
            {
                /*Tile t = ScriptableObject.CreateInstance<Tile>();
                t.sprite = floor;
                grid.SetTile(pos, t);*/
                grid.SetTile(pos, null);
                keys++;
            }
        }
    }

    public int Collected()
    {
        return counter;
    }

    public int KeyCollected()
    {
        return keys;
    }
}
