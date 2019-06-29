using UnityEngine;

public class Game : MonoBehaviour
{
    public GameObject pieces;

    public void PlacePiece(Piece piece, Transform tile)
    {
        Piece p = Instantiate(piece, tile.transform.position, Quaternion.identity);
        p.transform.SetParent(pieces.transform);
        p.transform.localScale = Vector3.one;
    }
}
