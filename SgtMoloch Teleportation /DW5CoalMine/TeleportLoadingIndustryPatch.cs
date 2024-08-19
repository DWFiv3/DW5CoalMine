using System.Collections.Generic;
using HarmonyLib;
using Model;
using Model.OpsNew;
using Serilog;
using Track;

namespace DW5CoalMine
{

    [HarmonyPatch(typeof(TeleportLoadingIndustry))]
    [HarmonyPatch("CheckRouteClear")]
    internal class TeleportLoadingIndustryPatch_CheckRouteClear
    {
        static Serilog.ILogger logger = Log.ForContext(typeof(TeleportLoadingIndustryPatch_CheckRouteClear));

        private static bool Prefix(ref Location start, Location end)
        {

            if (end.segment.id.Contains("DW5Seg"))
            {
                if (start.segment.id.Contains("Saqq") || start.segment.id.Contains("S66b") || start.segment.id.Contains("DW5Seg"))
                {
                    logger.Information("DW5CoalMine is present, setting the start location to the end location due to how this method works.");
                    start = end;
                }
            }

            return true;
        }
    }
}
