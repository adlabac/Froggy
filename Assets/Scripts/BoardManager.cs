using UnityEngine;
using UnityEngine.Tilemaps;

public class BoardManager : MonoBehaviour
{
    public int width;    // Broj polja po širini
    public int height;    // Broj polja po visini
    public AnimatedTile waterTile;    // Referenca ka animiranom sprajtu vode
    public FrogController frog;    // Referenca ka FrogController skripti
    public GameObject icePrefab;    // Referenca ka prefabu leda
    public float displayDelay = 0.1f;    // Vrijeme između pojavljivanja dva ledena polja

    private Tilemap tilemap;    // Referenca ka tilemapi
    private Grid grid;    // Referenca ka gridu tilemape

    private int level = 0;    // Broj trenutnog nivoa
    private IceController[,] iceFields;    // Reference ka kontrolerima svakog polja leda na tabli

    private bool initialized = false;    // Da li je završena inicijalizacija
    private float time = 0f;    // Proteklo vrijeme
    private int numberOfFields;    // Ukupan broj polja
    private int currentField = 0;    // Redni broj polja koje se trenutno prikazuje

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

        numberOfFields = Levels.icePositions[level].Length;
    }

    void Update()
    {
        if (initialized)    // Ako je inicijalizacija završena ne nastavljaj dalje
        {
            return;
        }

        time += Time.deltaTime;    // Uvećaj vrijeme za proteklo vrijeme
        if (time < displayDelay)    // Ako je proteklo manje vremena od definisanog ne nastavljaj dalje
        {
            return;
        }

        if (currentField >= numberOfFields)
        {
            var pos = Levels.startPositions[level];    // Preuzmi startnu poziciju žabe
            frog.Spawn(this, new Vector2Int(pos.x, pos.y));    // Pozicioniraj žabu na datu poziciju
            frog.gameObject.SetActive(true);    // Prikaži žabu
            initialized = true;    // Inicijalizacija je završena
            return;    // Ne nastavljaj dalje
        }

        var position = Levels.icePositions[level][currentField];    // Preuzmi poziciju tekućeg polja
        iceFields[position.x, position.y].Show();    // Prikaži polje na datoj poziciji

        time -= displayDelay;    // Umanji proteklo vrijeme za sljedeće polje
        currentField++;    // Pređi na sljedeće polje
    }
}
