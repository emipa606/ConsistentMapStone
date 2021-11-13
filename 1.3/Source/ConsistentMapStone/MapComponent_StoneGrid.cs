using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;

namespace CMS
{
    public class MapComponent_StoneGrid : MapComponent
    {
        public TerrainDef[] StoneGrid;

        public MapComponent_StoneGrid(Map map) : base(map)
        {
            StoneNoises.Init(map);
            StoneGrid = new TerrainDef[map.cellIndices.NumGridCells];
            for (int i = 0; i < map.cellIndices.NumGridCells; i++)
            {
                StoneGrid[i] = GenStep_StoneFromGrid.RockDefAt(map.cellIndices.IndexToCell(i)).building.naturalTerrain;
            }
            StoneNoises.Reset();
        }

        public TerrainDef StoneTypeAt(IntVec3 c)
        {
            return StoneGrid[map.cellIndices.CellToIndex(c)];
        }
    }
}