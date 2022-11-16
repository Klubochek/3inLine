using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    [SerializeField] private PlayTile oldSelectionTile;
    public PlayTile[,] pt;

    private void Awake()
    {
        Instance = this;
    }
    #region CONTOLLER METHODS
    public void CheckSelectedTile(PlayTile pt)
    {
        if (pt.isEmpty)
        {
            return;
        }
        if (pt.isSelected)
        {
            DeselectionTile(pt);
        }
        else
        {
            if (!pt.isSelected && oldSelectionTile == null)
            {
                SelectTile(pt);

            }
            else
            {
                if (MathF.Abs(pt.x - oldSelectionTile.x) <= 1 && Mathf.Abs(pt.y - oldSelectionTile.y) <= 1)
                {
                    SwapTwoTile(pt);
                    DeselectionTile(oldSelectionTile);
                }
            }
        }
    }

    private void SelectTile(PlayTile pt)
    {
        pt.isSelected = true;
        oldSelectionTile = pt;
        StartCoroutine(SelectAnimation(pt));

    }

    private void DeselectionTile(PlayTile pt)
    {
        pt.isSelected = false;
        oldSelectionTile = null;
        StopAllCoroutines();
        pt.transform.DORotate(new Vector3(0, 0, 0), 1f);


    }
    private void SwapTwoTile(PlayTile tile)
    {
        if (tile == oldSelectionTile)
        {
            return;
        }
        Vector3 temp1 = oldSelectionTile.transform.position;
        Vector3 temp2 = tile.transform.position;

        oldSelectionTile.transform.DOMove(temp2, 0.5f);
        tile.transform.DOMove(temp1, 0.5f);

        Sprite temp = oldSelectionTile.image.sprite;
        oldSelectionTile.image.sprite = tile.image.sprite;
        tile.image.sprite = temp;
        oldSelectionTile.transform.position = temp1;
        tile.transform.position = temp2;



    }
    #endregion CONTOLLER METHODS
    #region ANIMATION
    public IEnumerator SelectAnimation(PlayTile pt)
    {
        pt.transform.DORotate(new Vector3(0, 0, 90), 1f);
        yield return new WaitForSeconds(0.5f);
        pt.transform.DORotate(new Vector3(0, 0, -90), 1f);
        yield return new WaitForSeconds(0.5f);

        yield return StartCoroutine(SelectAnimation(pt));
    }
    #endregion ANIMATION
}
