using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    public TileManager tileManager;

    private void OnMouseDown()
    {
        tileManager.TilePressed(gameObject, false);
    }
}