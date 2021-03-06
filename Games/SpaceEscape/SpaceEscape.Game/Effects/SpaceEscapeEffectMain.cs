﻿// <auto-generated>
// Do not edit this file yourself!
//
// This code was generated by Paradox Shader Mixin Code Generator.
// To generate it yourself, please install SiliconStudio.Paradox.VisualStudio.Package .vsix
// and re-save the associated .pdxfx.
// </auto-generated>

using System;
using SiliconStudio.Core;
using SiliconStudio.Paradox.Effects;
using SiliconStudio.Paradox.Graphics;
using SiliconStudio.Paradox.Shaders;
using SiliconStudio.Core.Mathematics;
using Buffer = SiliconStudio.Paradox.Graphics.Buffer;

using SiliconStudio.Paradox.Effects.Data;
namespace SpaceEscape.Effects
{
    [DataContract]public partial class GameParameters : ShaderMixinParameters
    {
        public static readonly ParameterKey<bool> EnableFog = ParameterKeys.New<bool>(true);
        public static readonly ParameterKey<bool> EnableBend = ParameterKeys.New<bool>(true);
        public static readonly ParameterKey<bool> EnableOnflyTextureUVChange = ParameterKeys.New<bool>(false);
    };
    internal static partial class ShaderMixins
    {
        internal partial class SpaceEscapeEffectMain  : IShaderMixinBuilder
        {
            public void Generate(ShaderMixinSourceTree mixin, ShaderMixinContext context)
            {
                context.Mixin(mixin, "ShaderBase");
                context.Mixin(mixin, "TransformationWAndVP");
                context.Mixin(mixin, "BRDFDiffuseBase");
                context.Mixin(mixin, "BRDFSpecularBase");
                context.Mixin(mixin, "AlbedoFlatShading");
                if (context.GetParam(MaterialParameters.AlbedoDiffuse) != null)

                    {
                        var __subMixin = new ShaderMixinSourceTree() { Parent = mixin };
                        context.PushComposition(mixin, "albedoDiffuse", __subMixin);
                        context.Mixin(__subMixin, context.GetParam(MaterialParameters.AlbedoDiffuse));
                        context.PopComposition();
                    }
                if (context.GetParam(GameParameters.EnableOnflyTextureUVChange))
                    context.Mixin(mixin, "TransformationTextureUV");
                if (context.GetParam(MaterialParameters.HasSkinningPosition))
                {
                    mixin.Mixin.AddMacro("SkinningMaxBones", context.GetParam(MaterialParameters.SkinningMaxBones));
                    context.Mixin(mixin, "TransformationSkinning");
                }
                if (context.GetParam(GameParameters.EnableBend))
                {
                    context.Mixin(mixin, "TransformationBendWorld");
                }
                if (context.GetParam(GameParameters.EnableFog))
                {
                    context.Mixin(mixin, "FogEffect");
                }
            }

            [ModuleInitializer]
            internal static void __Initialize__()

            {
                ShaderMixinManager.Register("SpaceEscapeEffectMain", new SpaceEscapeEffectMain());
            }
        }
    }
}
