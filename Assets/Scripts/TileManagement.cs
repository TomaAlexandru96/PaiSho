using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManagement : MonoBehaviour
{
    public Game game;
    public GameObject tiles;

    public Rose rosePiece;
    public Chrysanthemum chrysanthemumPiece;
    public Rhododendron rhododendronPiece;

    public Transform GetTile(Vector2Int pos)
    {
        pos = new Vector2Int(tiles.transform.childCount / 2, tiles.transform.childCount / 2) + pos;
        if (!(pos[0] >= 0 && pos[0] < tiles.transform.childCount &&
                pos[1] >= 0 && pos[1] < tiles.transform.childCount))
        {
            return null;
        }
        return tiles.transform.GetChild(pos[0]).GetChild(pos[1]).transform;
    }

    public Vector2Int GetTileCoordinates(Transform tile)
    {
        return new Vector2Int(int.Parse(tile.parent.name), int.Parse(tile.name));
    }

    public bool IsTileValid(Transform tile)
    {
        return tile?.gameObject.activeSelf ?? false;
    }

    public bool IsTileValid(Vector2Int pos)
    {
        return GetTile(pos)?.gameObject.activeSelf ?? false;
    }
}
