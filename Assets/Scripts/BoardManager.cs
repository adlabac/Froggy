using UnityEngine;
using UnityEngine.Tilemaps;

public class BoardManager : MonoBehaviour
{
    public int width;    // Broj polja po širini
    public int height;    // Broj polja po visini
    public AnimatedTile waterTile;    // Referenca ka animiranom sprajtu vode
    public FrogController frog;    // Referenca ka FrogController skripti
    public GameObject icePrefab;    // Referenca ka prefabu leda


    private Tilemap tilemap;    // Referenca ka tilemapi
    private Grid grid;    // Referenca ka gridu tilemape

    private int level = 0;    // Broj trenutnog nivoa
    private IceController[,] iceFields;    // Reference ka kontrolerima svakog polja leda na tabli

    public Vector3 CellToWorld(Vector2Int cellIndex)    // Metoda koja vraća poziciju sredine polja na osnovu broja njegove vrste i kolone
    {
        return grid.GetCellCenterWorld((Vector3Int)cellIndex);
    }

    void Start()
    {
        tilemap = GetComponentInChildren<Tilemap>();    // Preuzimanje Tilemap komponente iz "djeteta" komponente
        grid = GetComponent<Grid>();    // Preuzimanje Grid komponente

        iceFields = new IceController[width, height];    // Kreiranje dvodimenzionalnog niza odgovarajuće veličine

        for (int y = 0; y < height; y++)    // Prolazak kroz sve vrste
        {
            for (int x = 0; x < height; x++)    // Prolazak kroz sve kolona
            {
                tilemap.SetTile(new Vector3Int(x, y, 0), waterTile);    // Dodijeli sprajt vode polju na koordinati (x, y)
                GameObject ice = Instantiate(icePrefab, CellToWorld(new Vector2Int(x, y)), Quaternion.identity);    // Kreiranje nove instance leda na osnovu prefaba
                iceFields[x, y] = ice.GetComponent<IceController>();    // Preuzmi referencu ka controller skripti datog polja
            }
        }

        foreach(var position in Levels.icePositions[level])    // Prođi kroz sve elemente niza sa pozicijama leda
        {
            iceFields[position.x, position.y].Show();    // Prikaži led na datoj poziciji
        }

        var pos = Levels.startPositions[level];    // Preuymi startnu poziciju žabe
        frog.Spawn(this, new Vector2Int(pos.x, pos.y));    // Pozicioniraj žabu na datu poziciju
    }
}
