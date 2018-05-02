using Microsoft.Xna.Framework;

namespace Monogame_Engine.Engine.Mesh
{
    class Actor
    {

        public Mesh mMesh;
        public Matrix mModelMatrix;

        public Actor(Mesh mesh)
        {

            mMesh = mesh;
            mModelMatrix = new Matrix();

        }
    }
}
