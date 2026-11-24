using UnityEngine;
using UnityEngine.Tilemaps;

public class BoardManager : MonoBehaviour
{
    public int width;    // Broj polja po širini
    public int height;    // Broj polja po visini
    public AnimatedTile waterTile;    // Referenca ka animiranom sprajtu vode
    public FrogController frog;    // Referenca ka FrogController skripti


    private Tilemap tilemap;    // Referenca ka tilemapi
    private Grid grid;    // Referenca ka gridu tilemape

    public Vector3 CellToWorld(Vector2Int cellIndex)    // Metoda koja vraća poziciju sredine polja na osnovu broja njegove vrste i kolone
    {
        return grid.GetCellCenterWorld((Vector3Int)cellIndex);
    }

    void Start()
    {
        tilemap = GetComponentInChildren<Tilemap>();    // Preuzimanje Tilemap komponente iz "djeteta" komponente
        grid = GetComponent<Grid>();    // Preuzimanje Grid komponente

        for (int y = 0; y < height; y++)    // Prolazak kroz sve vrste
        {
            for (int x = 0; x < height; x++)    // Prolazak kroz sve kolona
            {
                tilemap.SetTile(new Vector3Int(x, y, 0), waterTile);    // Dodijeli sprajt vode polju na koordinati (x, y)
            }
        }

        frog.Spawn(this, new Vector2Int(2, 3));    // Pozicioniraj žabu u polje (2, 3)
    }
}
