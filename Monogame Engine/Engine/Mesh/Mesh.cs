using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace Monogame_Engine.Engine.Mesh
{
    class Mesh
    {
        private readonly Model mModel;

        public readonly List<ModelMeshPart> mMeshParts;

        public Mesh(Model model)
        {

            mModel = model;

            mMeshParts = new List<ModelMeshPart>();

            for (ushort i = 0; i < mModel.Meshes.Count; i++)
            {
                var modelMesh = mModel.Meshes[i];

                for (ushort j = 0; j < modelMesh.MeshParts.Count; j++)
                {
                    mMeshParts.Add(modelMesh.MeshParts[j]);
                }
            }

        }

    }
}
