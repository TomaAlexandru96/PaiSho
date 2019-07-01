using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public readonly Game game = new Game(Colour.White);
    public Transform piecesRoot;
    public UIPiece pieceTemplate;

    public void Start()
    {
        Screen.SetResolution(1920, 1080, true);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Exit();
        }
    }

    private void Exit()
    {
        Application.Quit();
    }

    public void HanldeSelect(Transform tile, UIInfoDisplayPiece piece)
    {
        UIPiece p = Instantiate(pieceTemplate, tile.transform.position, Quaternion.identity, piecesRoot);
        p.SetupPiece(piece.name, this, game.PlayerColour);
    }
}
