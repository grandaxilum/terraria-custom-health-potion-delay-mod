# Reduce Potion

A [tModLoader](https://github.com/tModLoader/tModLoader) mod for [Terraria](https://terraria.org/) that reduces the **Potion Sickness** (healing potion cooldown) duration after drinking a healing potion.

- Works with vanilla and Calamity potions (Calamity is an optional weak reference)
- Multiplier configurable in the mod config (default: `0.8x`, range: `0.1x` - `2.0x`)
- Server-side config, so it applies in multiplayer too

## Requirements

| Dependency  | Version                              |
| ----------- | ------------------------------------ |
| Terraria    | 1.4.4.9                              |
| tModLoader  | 1.4.4 branch (latest stable, .NET 8) |
| .NET SDK    | 8.0                                  |
| CalamityMod | optional (weak reference)            |

## How to Run / Build

1. Install tModLoader and place this folder in your mod sources directory:
   - Windows: `%USERPROFILE%\Documents\My Games\Terraria\tModLoader\ModSources\ReducePotion`
   - Linux: `~/.local/share/Terraria/tModLoader/ModSources/ReducePotion`
   - macOS: `~/Library/Application Support/Terraria/tModLoader/ModSources/ReducePotion`

2. Build the mod:

   ```sh
   dotnet build -c Release
   ```

   (Or open the folder in an IDE with the tModLoader targets available and build from there.)

3. Launch tModLoader, open **Workshop > Mod Sources**, select **Reduce Potion** and click **Develop > Reload** (or just enable it if freshly built).

4. In-game, adjust the multiplier under **Settings > Mod Configs > Reduce Potion Config** if needed.
