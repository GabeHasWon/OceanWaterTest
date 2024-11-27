using Terraria;
using Terraria.ModLoader;

namespace OceanWaterTest;

public class OceanWaterTest : Mod
{
}

public class OceanScene : ModSceneEffect
{
    public override SceneEffectPriority Priority => SceneEffectPriority.BiomeHigh;
    public override ModSurfaceBackgroundStyle SurfaceBackgroundStyle => Mod.Find<ModSurfaceBackgroundStyle>("OceanBackgroundStyle");

    // If the mouse is above the player, and the player is in the beach, this is active
    public override bool IsSceneEffectActive(Player player) => player.ZoneBeach && player.Center.Y > Main.MouseWorld.Y;
}

internal class OceanBackgroundStyle : ModSurfaceBackgroundStyle
{
    // Textures copied from SpiritMod for testing
    public override int ChooseFarTexture() => BackgroundTextureLoader.GetBackgroundSlot(Mod, "Backgrounds/OceanUnderwaterBG3");
    public override int ChooseMiddleTexture() => BackgroundTextureLoader.GetBackgroundSlot(Mod, "Backgrounds/OceanUnderwaterBG2");

    public override int ChooseCloseTexture(ref float scale, ref double parallax, ref float a, ref float b)
    {
        // Specific values irrelevant
        scale *= .86f;
        b -= 300;
        return BackgroundTextureLoader.GetBackgroundSlot(Mod, "Backgrounds/OceanUnderwaterBG2");
    }

    // Specific values irrelevant
    public override void ModifyFarFades(float[] fades, float transitionSpeed)
    {
        for (int i = 0; i < fades.Length; i++)
        {
            if (i == Slot)
            {
                fades[i] += transitionSpeed;
                if (fades[i] > 1f)
                    fades[i] = 1f;
            }
            else
            {
                fades[i] -= transitionSpeed;
                if (fades[i] < 0f)
                    fades[i] = 0f;
            }
        }
    }
}
