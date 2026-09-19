using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace CustomHealthPotionDelay
{
    public class CustomHealthPotionDelayConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Range(0.1f, 2f)]
        [Increment(0.1f)]
        [DefaultValue(0.8f)]
        public float PotionDelayMultiplier;
    }
}
