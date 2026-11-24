using UnityEngine;

public class FrogController : MonoBehaviour
{
    private BoardManager board;    // Referenca ka BoardManager skripti
    private Vector2Int cell;    // Vrsta i kolona polja na kom se nalazi žaba

    public void Spawn(BoardManager boardManager, Vector2Int cellPosition)    // Metoda koja pozicionira žabu na dato polje
    {
        board = boardManager;    // Preuzimanje reference ka BoardManager skripti
        cell = cellPosition;    // Preuzimanje koordinate polja

        transform.position = board.CellToWorld(cell);    // Pozicioniraj žaabu na sredinu traženog polja
    }
}
