using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayTile : MonoBehaviour
{
    public bool isSelected;
    public int x;
    public int y;
    public Image image;
    public bool isEmpty
    {
        get
        {
            return image.sprite == null ? true : false;
        }
    }
    public void OnTileClick()
    {
        GameController.Instance.CheckSelectedTile(this);
    }
}
