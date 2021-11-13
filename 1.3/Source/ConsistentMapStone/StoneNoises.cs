using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;
using Verse.Noise;

namespace CMS
{
	/// <summary>
	/// Class based on the regular Rimworld RockNoises class but with the map seed taken into account instead of a random seed for consistency.
	/// </summary>
    public static class StoneNoises
    {
		public static void Init(Map map)
		{
			StoneNoises.rockNoises = new List<RockNoises.RockNoise>();
			foreach (ThingDef rockDef in Find.World.NaturalRockTypesIn(map.Tile))
			{
				RockNoises.RockNoise rockNoise = new RockNoises.RockNoise();
				rockNoise.rockDef = rockDef;
				rockNoise.noise = new Perlin(0.004999999888241291, 2.0, 0.5, 6, map.uniqueID, QualityMode.Medium);
				StoneNoises.rockNoises.Add(rockNoise);
				NoiseDebugUI.StoreNoiseRender(rockNoise.noise, rockNoise.rockDef + " score", map.Size.ToIntVec2);
			}
		}

		public static void Reset()
		{
			StoneNoises.rockNoises = null;
		}

		// Token: 0x04000B9D RID: 2973
		public static List<RockNoises.RockNoise> rockNoises;

		// Token: 0x04000B9E RID: 2974
		private const float RockNoiseFreq = 0.005f;
	}
}