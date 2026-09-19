using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReducePotion
{
    public class ReducePotionPlayer : ModPlayer
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
                float multiplier = ReducePotion.Config?.PotionDelayMultiplier ?? 0.8f;
                float baseMultiplier = Player.pStone
                    ? Player.PhilosopherStoneDurationMultiplier
                    : 1f;

                int newDelay = (int)(Player.potionDelay * baseMultiplier * multiplier);

                int vanillaBuffIndex = Player.FindBuffIndex(BuffID.PotionSickness);
                if (vanillaBuffIndex != -1)
                {
                    Player.buffTime[vanillaBuffIndex] = newDelay;
                }

                if (ModLoader.TryGetMod("CalamityMod", out Mod calamity))
                {
                    ApplyCalamityBuffReduction(calamity, newDelay, multiplier);
                }

                _hasAppliedReduction = true;
            }
        }

        private void ApplyCalamityBuffReduction(Mod calamity, int newDelay, float multiplier)
        {
            for (int i = 0; i < Player.MaxBuffs; i++)
            {
                if (Player.buffType[i] > 0)
                {
                    string buffModName = BuffLoader.GetBuff(Player.buffType[i])?.Mod?.Name;

                    if (buffModName == "CalamityMod")
                    {
                        Player.buffTime[i] = (int)(Player.buffTime[i] * multiplier);
                    }
                }
            }
        }
    }
}
