using GalaSoft.MvvmLight.Messaging;
using Game.Events;
using HarmonyLib;
using Railloader;
using Serilog;


namespace DW5CoalMine
{
    public class DW5CoalMine : PluginBase
    {
        ILogger logger = Log.ForContext<DW5CoalMine>();
        private readonly IModdingContext ctx;
        private readonly IModDefinition self;

        public DW5CoalMine(IModdingContext ctx, IModDefinition self)
        {
            this.ctx = ctx;
            this.self = self;
            new Harmony(self.Id).PatchAll(GetType().Assembly);
        }
    }
}
