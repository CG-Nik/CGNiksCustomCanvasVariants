using Alta.Caves;
using MelonLoader;
using UnityEngine;
using MateriaLib;
using DifferentCanvasMaterials;
using CustomDistributionAPI;

[assembly: MelonInfo(typeof(CGNiksCustomCanvasVariants.Core), "CGNiksCustomCanvasVariants", "1.0.0", "CGNik", null)]
[assembly: MelonGame("Alta", "A Township Tale")]

namespace CGNiksCustomCanvasVariants
{
    public class Core : MelonMod
    {
        public override void OnInitializeMelon()
        {
            LoggerInstance.Msg("Initialized.");
            MateriaLib.Main.SetupMaterial += SetupMaterial;
        }

        private static LibMaterial AddCanvas(string name, int hash, MaterialConfig materialConfig, Vector4 colorA_worn, Vector4 color_worn, Vector4 colorA_cutout, Vector4 color_cutout, bool addToDistribution, float baseValue = 1f, float noAttributeValue = 1f, AttributeCurveRange[] multipliers = null)
        {
            LibMaterial libMaterial = new LibMaterial(name, hash, LibMaterial.MaterialType.canvas);

            LibMaterial.NewMaterials.Add(libMaterial);

            libMaterial.Configure(materialConfig);

            Material worn = UnityEngine.Object.Instantiate(libMaterial.physicalMaterial.GetMaterial(PhysicalMaterialChannel.A));
            Material cutout = UnityEngine.Object.Instantiate(libMaterial.physicalMaterial.GetMaterial(PhysicalMaterialChannel.B));

            worn.name = name + " Worn";
            cutout.name = name + " Cutout";

            worn.SetVector("_ColorA", colorA_worn);
            worn.SetVector("_Color", color_worn);
            cutout.SetVector("_ColorA", colorA_cutout);
            cutout.SetVector("_Color", color_cutout);

            libMaterial.ReplaceAllMaterials(worn, cutout);

            if (addToDistribution)
            {
                CustomDistributionAPI.Core.AddToDistribution(DifferentCanvasMaterials.Core.canvasMaterialDistribution, libMaterial.physicalMaterial, baseValue, noAttributeValue, multipliers);
            }

            return libMaterial;
        }

        public static void SetupMaterial()
        {
            AddCanvas(
                "Light Gray Canvas",
                61791,
                new MaterialConfig() { WeightMultiplier = 0.95f, NailHealthMultiplier = 0.9f, MaxCraftingDamageMultiplier = 1.1f },
                new Vector4(0.6f, 0.6f, 0.6f, 1f),
                new Vector4(0.7f, 0.7f, 0.7f, 1f),
                new Vector4(0.65f, 0.65f, 0.65f, 1f),
                new Vector4(0.7f, 0.7f, 0.7f, 1f),
                true,
                0.5f,
                0.5f,
                new AttributeCurveRange[]
                {
                    new AttributeCurveRange(
                        (BiomeAttribute)Resources.FindObjectsOfTypeAll(typeof(BiomeAttribute)).Where(attribute => attribute.name == "_Depth").First(),
                        new AnimationCurve(new Keyframe[]
                        {
                            new Keyframe(0f, 0f),
                            new Keyframe(1f, 1f)
                        }),
                        0f,
                        20f
                    )
                }
            );

            AddCanvas(
                "Dark Gray Canvas",
                61792,
                new MaterialConfig() { WeightMultiplier = 0.8f, NailHealthMultiplier = 1.2f, MaxCraftingDamageMultiplier = 0.8f },
                new Vector4(0.35f, 0.35f, 0.35f, 1f),
                new Vector4(0.4f, 0.4f, 0.4f, 1f),
                new Vector4(0.375f, 0.375f, 0.375f, 1f),
                new Vector4(0.4f, 0.4f, 0.4f, 1f),
                true,
                0.5f,
                0.5f,
                new AttributeCurveRange[]
                {
                    new AttributeCurveRange(
                        (BiomeAttribute)Resources.FindObjectsOfTypeAll(typeof(BiomeAttribute)).Where(attribute => attribute.name == "_Depth").First(),
                        new AnimationCurve(new Keyframe[]
                        {
                            new Keyframe(0f, 0f),
                            new Keyframe(1f, 1f)
                        }),
                        20f,
                        40f
                    )
                }
            );

            AddCanvas(
                "White Canvas",
                61793,
                new MaterialConfig() { },
                new Vector4(0.8f, 0.8f, 0.7f, 1f),
                new Vector4(0.9f, 0.9f, 0.8f, 1f),
                new Vector4(0.85f, 0.85f, 0.75f, 1f),
                new Vector4(0.9f, 0.9f, 0.8f, 1f),
                true,
                0.5f,
                0.5f,
                new AttributeCurveRange[]
                {
                    new AttributeCurveRange(
                        (BiomeAttribute)Resources.FindObjectsOfTypeAll(typeof(BiomeAttribute)).Where(attribute => attribute.name == "_Depth").First(),
                        new AnimationCurve(new Keyframe[]
                        {
                            new Keyframe(0f, 1f),
                            new Keyframe(1f, 0f)
                        }),
                        0f,
                        40f
                    )
                }
            );

            AddCanvas(
                "Light Brown Canvas",
                61794,
                new MaterialConfig() { WeightMultiplier = 1.1f, NailHealthMultiplier = 0.6f, MaxCraftingDamageMultiplier = 0.6f },
                new Vector4(0.5f, 0.333f, 0f, 1f),
                new Vector4(0.6f, 0.4f, 0f, 1f),
                new Vector4(0.55f, 0.366f, 0f, 1f),
                new Vector4(0.6f, 0.4f, 0f, 1f),
                true,
                0.5f,
                0.5f,
                new AttributeCurveRange[]
                {
                    new AttributeCurveRange(
                        (BiomeAttribute)Resources.FindObjectsOfTypeAll(typeof(BiomeAttribute)).Where(attribute => attribute.name == "_Depth").First(),
                        new AnimationCurve(new Keyframe[]
                        {
                            new Keyframe(0f, 0.5f),
                            new Keyframe(1f, 0.3f)
                        }),
                        0f,
                        100f
                    )
                }
            );

            AddCanvas(
                "Dark Brown Canvas",
                61795,
                new MaterialConfig() { WeightMultiplier = 1.2f, NailHealthMultiplier = 0.8f, MaxCraftingDamageMultiplier = 0.8f },
                new Vector4(0.5f * 0.7f, 0.333f * 0.7f, 0f, 1f),
                new Vector4(0.6f * 0.7f, 0.4f * 0.7f, 0f, 1f),
                new Vector4(0.55f * 0.7f, 0.366f * 0.7f, 0f, 1f),
                new Vector4(0.6f * 0.7f, 0.4f * 0.7f, 0f, 1f),
                true,
                0.5f,
                0.5f,
                new AttributeCurveRange[]
                {
                    new AttributeCurveRange(
                        (BiomeAttribute)Resources.FindObjectsOfTypeAll(typeof(BiomeAttribute)).Where(attribute => attribute.name == "_Depth").First(),
                        new AnimationCurve(new Keyframe[]
                        {
                            new Keyframe(0f, 0.1f),
                            new Keyframe(1f, 0.7f)
                        }),
                        0f,
                        100f
                    )
                }
            );

            AddCanvas(
                "Black Canvas",
                61796,
                new MaterialConfig() { NailHealthMultiplier = 1.2f },
                new Vector4(0.15f, 0.15f, 0.15f, 1f),
                new Vector4(0.2f, 0.2f, 0.2f, 1f),
                new Vector4(0.175f, 0.175f, 0.175f, 1f),
                new Vector4(0.2f, 0.2f, 0.2f, 1f),
                true,
                0.5f,
                0.5f,
                new AttributeCurveRange[]
                {
                    new AttributeCurveRange(
                        (BiomeAttribute)Resources.FindObjectsOfTypeAll(typeof(BiomeAttribute)).Where(attribute => attribute.name == "_Depth").First(),
                        new AnimationCurve(new Keyframe[]
                        {
                            new Keyframe(0f, 0f),
                            new Keyframe(1f, 1f)
                        }),
                        0f,
                        100f
                    )
                }
            );
        }
    }
}