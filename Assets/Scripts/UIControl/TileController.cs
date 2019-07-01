using UnityEngine;

public class TileController : MonoBehaviour
{
    public GameObject tiles;
    public GameController gameController;
    public UIInfoDisplay activePlayerInfoDisplay;

    private Transform hoveringTile;

    void Update()
    {
        Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(r, out RaycastHit hit, Mathf.Infinity, LayerMask.GetMask(new string[] { "Tiles" })))
        {
            if (hoveringTile)
            {
                UnhighlightTile(hoveringTile);
                hoveringTile = null;
            }

            if (hit.transform.tag != "Background")
            {
                hoveringTile = hit.transform;
                HighlightTile(hoveringTile);

                if (Input.GetMouseButtonDown(0))
                {
                    UIInfoDisplayPiece piece = activePlayerInfoDisplay.Selected;
                    if (!piece)
                    {
                        return;
                    }
                    gameController.HanldeSelect(hoveringTile, piece);
                }
            }
        }
    }

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

    public void HighlightTile(Transform tile)
    {
        if (!tile)
        {
            return;
        }
        tile.gameObject.GetComponent<MeshRenderer>().enabled = true;
    }

    public void UnhighlightTile(Transform tile)
    {
        if (!tile)
        {
            return;
        }
        tile.gameObject.GetComponent<MeshRenderer>().enabled = false;
    }
}
