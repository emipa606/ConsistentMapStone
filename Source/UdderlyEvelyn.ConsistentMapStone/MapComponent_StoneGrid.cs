using RimWorld;
using Verse;

namespace CMS;

public class MapComponent_StoneGrid(Map map) : MapComponent(map)
{
    private ThingDef[] stoneGrid;

    public ThingDef StoneChunkAt(IntVec3 c)
    {
        return stoneTypeAt(c).building.mineableThing;
    }

    public TerrainDef StoneTerrainAt(IntVec3 c)
    {
        return stoneTypeAt(c).building.naturalTerrain;
    }

    private ThingDef stoneTypeAt(IntVec3 c)
    {
        if (stoneGrid == null)
        {
            initialize();
        }

        return stoneGrid?[map.cellIndices.CellToIndex(c)];
    }

    public override void MapGenerated()
    {
        initialize();
    }

    private void initialize()
    {
        RockNoises.Init(map);
        stoneGrid = new ThingDef[map.cellIndices.NumGridCells];
        for (var i = 0; i < map.cellIndices.NumGridCells; i++)
        {
            var thingDef = GenStep_RocksFromGrid.RockDefAt(map.cellIndices.IndexToCell(i));
            stoneGrid[i] = thingDef;
        }

        RockNoises.Reset();
    }

    public ThingDef ChunkFor(ThingDef rockDef)
    {
        Log.Message($"Getting chunk name for {rockDef.defName}.");
        return DefDatabase<ThingDef>.GetNamed($"{rockDef.defName}Chunk");
    }
}