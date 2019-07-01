using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInfoDisplay : MonoBehaviour
{
    public Text text;
    public UIInfoDisplayPiece[] pieces;
    public Colour panelColour;

    public UIInfoDisplayPiece Selected
    {
        get; private set;
    }

    public void Start()
    {
        text.text = panelColour + " Pieces";
        foreach (UIInfoDisplayPiece p in pieces)
        {
            p.SetColour(panelColour);
        }

        /*
        foreach (Piece p in piecesTemplates) 
        {
            Texture t = p.gameObject.GetComponentInChildren<MeshRenderer>().sharedMaterial.mainTexture;
            GameObject uiPiece = Instantiate(pieceUITemplate, whiteInfo.transform);
            Image[] images = uiPiece.GetComponentsInChildren<Image>();

            foreach (Image i in images)
            {
                Debug.Log(t.name);
                i.sprite = Resources.Load<Sprite>(t.name);
            }
        }
        */
    }

    public void HandleToggle(bool value, UIInfoDisplayPiece piece)
    {
        if (Selected != null)
        {
            Selected.GetComponentInChildren<Toggle>().isOn = false;
        }

        if (Selected == piece && !value)
        {
            Selected = null;
            return;
        }

        Selected = piece;
        Selected.GetComponentInChildren<Toggle>().isOn = value;
    }
}
