using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Board : MonoBehaviour
{
    private int sizeX;
    private int sizeY;
    private PlayTile playTile;
    private List<Sprite> playStipte;
    private int sizeXPt;
    private int sizeYPt;
    public PlayTile[,] ptArray;


    public static Board Instance;


    private void Awake()
    {
        Instance = this;
    }

    public void SetVaule(int xSize, int ySize, PlayTile pt, List<Sprite> list)
    {
        sizeX = xSize;
        sizeY = xSize;
        playTile = pt;
        playStipte = list;
    }
    public PlayTile [,] CreateBoard()
    {
        ptArray = new PlayTile[sizeX, sizeY];
        sizeXPt = sizeX * 50;
        sizeYPt = sizeY * 50;

        float posX = sizeXPt / 2 - 25;
        float posY = sizeYPt / 2 - 25;
        for (int y = 0; y < sizeX; y++)
        {
            for (int x=0; x < sizeY; x++)
            {
                
                PlayTile newPt = Instantiate(playTile,transform,false );
                
                newPt.image.sprite = playStipte[Random.Range(0, playStipte.Count)];
                StartCoroutine(RespawnAnimation(x,y, posX, posY, newPt));
                newPt.x = x;
                newPt.y = y;
                
                ptArray[x, y] = newPt;              
            }
        }
        return ptArray;

    }
    public IEnumerator RespawnAnimation(int x,int y,float posx,float posy,PlayTile newpt)
    {
        yield return new WaitForSeconds(0.005f);
        Vector3 posFrom = new Vector3(-posx + (50 * x), posy + 100);
        newpt.transform.localPosition = posFrom;
        newpt.transform.DOLocalMove(new Vector3(-posx + (50 * x), -posy + (50 * y), 0), 1f);
        yield break;
    }
}
