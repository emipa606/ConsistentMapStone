using HarmonyLib;
using Verse;
using Verse.Noise;

namespace CMS;

[HarmonyPatch(typeof(RockNoises), nameof(RockNoises.Init))]
internal class RockNoises_Init
{
    private static bool Prefix(Map map)
    {
        RockNoises.rockNoises = [];
        foreach (var item in Find.World.NaturalRockTypesIn(map.Tile))
        {
            var rockNoise = new RockNoises.RockNoise
            {
                rockDef = item,
                noise = new Perlin(0.004999999888241291, 2.0, 0.5, 6,
                    map.ConstantRandSeed + (item.GetHashCode() / 2), QualityMode.Medium)
            };
            RockNoises.rockNoises.Add(rockNoise);
            NoiseDebugUI.StoreNoiseRender(rockNoise.noise, $"{rockNoise.rockDef} score", map.Size.ToIntVec2);
        }

        return false;
    }
}