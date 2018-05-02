using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Monogame_Engine.Engine.Shader
{
    internal sealed class ForwardShader : Shader
    {
        private readonly EffectParameter mAlbedoMapParameter;

        public ForwardShader(ContentManager content, string shaderPath) : base(content, shaderPath)
        {
            mAlbedoMapParameter = mShader.Parameters["albedoMap"];
        }

        public override void Apply()
        {
            base.Apply();
        }

        public void ApplyMaterial(Texture2D albedoMap)
        {
            mAlbedoMapParameter.SetValue(albedoMap);
        }
    }
}