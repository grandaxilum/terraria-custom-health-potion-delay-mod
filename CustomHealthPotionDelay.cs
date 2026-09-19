using Terraria.ModLoader;

namespace CustomHealthPotionDelay
{
    public class CustomHealthPotionDelay : Mod
    {
        public static CustomHealthPotionDelayConfig Config =>
            ModContent.GetInstance<CustomHealthPotionDelayConfig>();
    }
}
