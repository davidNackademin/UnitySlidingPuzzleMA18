using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    public TileManager tileManager;
   // public bool empty = false;

    private void OnMouseDown()
    {
        tileManager.TilePressed(gameObject);
    }
}