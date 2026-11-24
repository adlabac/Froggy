using UnityEngine;
using UnityEngine.Tilemaps;

public class BoardManager : MonoBehaviour
{
    public int width;    // Broj polja po širini
    public int height;    // Broj polja po visini
    public AnimatedTile waterTile;    // Referenca ka animiranom sprajtu vode

    private Tilemap tilemap;    // Referenca ka tilemapi

    void Start()
    {
        tilemap = GetComponentInChildren<Tilemap>();    // Preuzimanje Tilemap komponente iz "djeteta" komponente

        for (int y = 0; y < height; y++)    // Prolazak kroz sve vrste
        {
            for (int x = 0; x < height; x++)    // Prolazak kroz sve kolona
            {
                tilemap.SetTile(new Vector3Int(x, y, 0), waterTile);    // Dodijeli sprajt vode polju na koordinati (x, y)
            }
        }
    }
}
