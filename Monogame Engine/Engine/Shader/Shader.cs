using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Monogame_Engine.Engine.Shader
{
    internal class Shader
    {

        protected readonly Effect mShader;
        private readonly EffectPass mMainPass;

        private readonly EffectParameter mModelMatrixParameter;
        private readonly EffectParameter mViewMatrixParameter;
        private readonly EffectParameter mProjectionMatrixParameter;

        public Matrix mViewMatrix;
        public Matrix mProjectionMatrix;

        protected Shader(ContentManager content, string shaderPath)
        {
            mShader = content.Load<Effect>(shaderPath);

            mModelMatrixParameter = mShader.Parameters["modelMatrix"];
            mViewMatrixParameter = mShader.Parameters["viewMatrix"];
            mProjectionMatrixParameter = mShader.Parameters["projectionMatrix"];

            // We could have different techniques and passes in our shaders but we
            // will use the Main part, which means we have to call it Main in the shaders too.
            mMainPass = mShader.Techniques["Main"].Passes[0];

        }

        public virtual void Apply()
        {

            mMainPass.Apply();

            // TODO: We should check whether the matrices are not null
            mViewMatrixParameter.SetValue(mViewMatrix);
            mProjectionMatrixParameter.SetValue(mProjectionMatrix);
          
        }

        public void ApplyModelMatrix(Matrix modelMatrix)
        {
            mModelMatrixParameter.SetValue(modelMatrix);
            mMainPass.Apply();
        }
    }
}