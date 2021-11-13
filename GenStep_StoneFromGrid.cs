using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;
using RimWorld.Planet;

namespace CMS
{
    public class GenStep_StoneFromGrid : GenStep
    {
		public override int SeedPart
		{
			get
			{
				return 1182952823;
			}
		}

		public static ThingDef RockDefAt(IntVec3 c)
		{
			ThingDef thingDef = null;
			float num = -999999f;
			for (int i = 0; i < StoneNoises.rockNoises.Count; i++)
			{
				float value = StoneNoises.rockNoises[i].noise.GetValue(c);
				if (value > num)
				{
					thingDef = StoneNoises.rockNoises[i].rockDef;
					num = value;
				}
			}
			if (thingDef == null)
			{
				Log.ErrorOnce("Did not get rock def to generate at " + c, 50812);
				thingDef = ThingDefOf.Sandstone;
			}
			return thingDef;
		}

		public override void Generate(Map map, GenStepParams parms)
		{
			if (map.TileInfo.WaterCovered)
			{
				return;
			}
			map.regionAndRoomUpdater.Enabled = false;
			float num = 0.7f;
			List<RoofThreshold> list = new List<RoofThreshold>();
			RoofThreshold roofThreshold = new RoofThreshold();
			roofThreshold.roofDef = RoofDefOf.RoofRockThick;
			roofThreshold.minGridVal = num * 1.14f;
			list.Add(roofThreshold);
			RoofThreshold roofThreshold2 = new RoofThreshold();
			roofThreshold2.roofDef = RoofDefOf.RoofRockThin;
			roofThreshold2.minGridVal = num * 1.04f;
			list.Add(roofThreshold2);
			MapGenFloatGrid elevation = MapGenerator.Elevation;
			MapGenFloatGrid caves = MapGenerator.Caves;
			foreach (IntVec3 allCell in map.AllCells)
			{
				float num2 = elevation[allCell];
				if (!(num2 > num))
				{
					continue;
				}
				if (caves[allCell] <= 0f)
				{
					GenSpawn.Spawn(RockDefAt(allCell), allCell, map);
				}
				for (int i = 0; i < list.Count; i++)
				{
					if (num2 > list[i].minGridVal)
					{
						map.roofGrid.SetRoof(allCell, list[i].roofDef);
						break;
					}
				}
			}
			BoolGrid visited = new BoolGrid(map);
			List<IntVec3> toRemove = new List<IntVec3>();
			foreach (IntVec3 allCell2 in map.AllCells)
			{
				if (visited[allCell2] || !IsNaturalRoofAt(allCell2, map))
				{
					continue;
				}
				toRemove.Clear();
				map.floodFiller.FloodFill(allCell2, (IntVec3 x) => IsNaturalRoofAt(x, map), delegate (IntVec3 x)
				{
					visited[x] = true;
					toRemove.Add(x);
				});
				if (toRemove.Count < 20)
				{
					for (int j = 0; j < toRemove.Count; j++)
					{
						map.roofGrid.SetRoof(toRemove[j], null);
					}
				}
			}
			GenStep_ScatterLumpsMineable genStep_ScatterLumpsMineable = new GenStep_ScatterLumpsMineable();
			genStep_ScatterLumpsMineable.maxValue = maxMineableValue;
			float num3 = 10f;
			switch (Find.WorldGrid[map.Tile].hilliness)
			{
				case Hilliness.Flat:
					num3 = 4f;
					break;
				case Hilliness.SmallHills:
					num3 = 8f;
					break;
				case Hilliness.LargeHills:
					num3 = 11f;
					break;
				case Hilliness.Mountainous:
					num3 = 15f;
					break;
				case Hilliness.Impassable:
					num3 = 16f;
					break;
			}
			genStep_ScatterLumpsMineable.countPer10kCellsRange = new FloatRange(num3, num3);
			genStep_ScatterLumpsMineable.Generate(map, parms);
			map.regionAndRoomUpdater.Enabled = true;
		}

		private bool IsNaturalRoofAt(IntVec3 c, Map map)
		{
			return c.Roofed(map) && c.GetRoof(map).isNatural;
		}

		private float maxMineableValue = float.MaxValue;

		private const int MinRoofedCellsPerGroup = 20;

		private class RoofThreshold
		{
			// Token: 0x040083F1 RID: 33777
			public RoofDef roofDef;

			// Token: 0x040083F2 RID: 33778
			public float minGridVal;
		}
	}
}