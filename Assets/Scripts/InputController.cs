using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputController : MonoBehaviour
{
    public Game game;
    public ToggleGroup pieces;
    public Text[] piecesCount;
    public TileManagement tileManagement;

    private Transform hoveringTile;
    private Piece selection;

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
                    PlaceTile(hit.transform);
                }
            }
        }
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

    public void RoseToggled(Toggle toggle)
    {
        Selected(toggle, tileManagement.rosePiece);
    }

    public void ChrysanthemumToggled(Toggle toggle)
    {
        Selected(toggle, tileManagement.chrysanthemumPiece);
    }

    public void RhododendronToggled(Toggle toggle)
    {
        Selected(toggle, tileManagement.rhododendronPiece);
    }

    public void Selected(Toggle toggle, Piece piece)
    {
        selection = null;
        if (toggle.isOn)
        {
            selection = piece;
        }
    }

    public void PlaceTile(Transform tile)
    {
        if (!selection)
        {
            return;
        }

        game.PlacePiece(selection, tile);
    }
}
