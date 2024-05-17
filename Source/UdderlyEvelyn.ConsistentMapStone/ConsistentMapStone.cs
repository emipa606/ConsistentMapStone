using System.Reflection;
using HarmonyLib;
using Verse;

namespace CMS;

[StaticConstructorOnStartup]
public static class ConsistentMapStone
{
    static ConsistentMapStone()
    {
        new Harmony("UdderlyEvelyn.ConsistentMapStone").PatchAll(Assembly.GetExecutingAssembly());
    }
}