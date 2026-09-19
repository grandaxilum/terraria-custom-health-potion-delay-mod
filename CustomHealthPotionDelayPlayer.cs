using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CustomHealthPotionDelay
{
    public class CustomHealthPotionDelayPlayer : ModPlayer
    {
        private bool _hasAppliedReduction = false;

        public override void ResetEffects()
        {
            if (Player.potionDelay <= 0)
            {
                _hasAppliedReduction = false;
            }
        }

        public override void PostUpdateBuffs()
        {
            if (Player.potionDelay > 0 && !_hasAppliedReduction)
            {
                float multiplier = CustomHealthPotionDelay.Config?.PotionDelayMultiplier ?? 0.8f;

                int newDelay = (int)(Player.potionDelay * multiplier);

                // Reduce Vanilla Potion Sickness
                int vanillaBuffIndex = Player.FindBuffIndex(BuffID.PotionSickness);
                if (vanillaBuffIndex != -1)
                {
                    Player.buffTime[vanillaBuffIndex] = newDelay;
                }

                // Reduce Modded Potion Sickness (Mod-Agnostic for Calamity, Thorium, etc.)
                ApplyModdedBuffReduction(multiplier);

                _hasAppliedReduction = true;
            }
        }

        /// <summary>
        /// Dynamically reduces duration for active modded debuffs/buffs across any loaded mod.
        /// </summary>
        private void ApplyModdedBuffReduction(float multiplier)
        {
            for (int i = 0; i < Player.buffType.Length; i++)
            {
                int buffType = Player.buffType[i];
                if (buffType <= 0)
                    continue;

                // Mod is non-null for any modded buff registered through tModLoader
                Mod buffMod = BuffLoader.GetBuff(buffType)?.Mod;
                if (buffMod != null)
                {
                    Player.buffTime[i] = (int)(Player.buffTime[i] * multiplier);
                }
            }
        }
    }
}
