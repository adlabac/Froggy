public static class Levels
{
    public static readonly (int x, int y)[][] icePositions =    // Koordinate svih ledenih polja na počecima nivoa
    {
        new [] {(4, 2), (1, 3), (2, 1), (2, 3), (2, 5), (3, 3), (3, 5), (4, 1), (4, 4), (5, 2), (5, 4), (6, 2)}
    };

	public static readonly (int x, int y)[] startPositions = {(4, 2)};    // Početne koordinate žabe na nivoima
}
