using UnityEngine;

public class GameManager : MonoBehaviour
{
    public BoardSettigns boardSettigns;

    private void Start()
    {
        Board.Instance.SetVaule(boardSettigns.xSize, boardSettigns.ySize, boardSettigns.prefb, boardSettigns.images);
        GameController.Instance.pt=Board.Instance.CreateBoard();
    }
}
