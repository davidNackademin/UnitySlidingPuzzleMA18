using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    private int rowSize;

    public List<GameObject> tiles = new List<GameObject>();

    private void Start()
    {
        rowSize = (int) Mathf.Sqrt(tiles.Count);
    }


    public void TilePressed(GameObject tile)
    {
        GameObject emptyNeighbour = EmptyNeighbour(tile);

        if (emptyNeighbour == null)
            return;

        SwitchTiles(tile, emptyNeighbour);
    }

    private void SwitchTiles(GameObject tile1, GameObject tile2)
    {

        Vector3 pos = tile1.transform.position;

        tile1.transform.position = tile2.transform.position;
        tile2.transform.position = pos;

        int index1 = TileIndex(tile1);
        int index2 = TileIndex(tile2);

        tiles[index1] = tile2;
        tiles[index2] = tile1;

    }

    private int TileIndex(GameObject tile)
    {
        return tiles.IndexOf(tile);
    }

    GameObject EmptyNeighbour (GameObject tile)
    {
        foreach (GameObject gameObject in Neighbours(tile))
        {
            if(gameObject.tag == "Empty")
            {
                return gameObject;
            }
        }

        return null;
    }

    private List<GameObject> Neighbours(GameObject tile)
    {
        int index = TileIndex(tile);

        List<GameObject> neighbours = new List<GameObject>();

        //right
        int right = index + 1;
        if(InRange(right) && (index + 1) % rowSize != 0)
            neighbours.Add(tiles[right]);

        //left
        int left = index - 1;
        if(InRange(left) && index % rowSize != 0 )
            neighbours.Add(tiles[left]);

        //over
        int over = index - rowSize;
        if (InRange(over))
            neighbours.Add(tiles[over]);

        //under
        int under = index + rowSize;
        if (InRange(under))
            neighbours.Add(tiles[under]);

        return neighbours;
    }

    private bool InRange(int index)
    {
        return (index >= 0 && index < tiles.Count);
    }


}
