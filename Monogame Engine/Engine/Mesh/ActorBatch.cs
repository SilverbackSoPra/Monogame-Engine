using System.Collections.Generic;

namespace Monogame_Engine.Engine.Mesh
{
    internal sealed class ActorBatch
    {
        public readonly List<Actor> mActors;

        public readonly Mesh mMesh;

        public ActorBatch(Mesh mesh)
        {
            mMesh = mesh;
            mActors = new List<Actor>();
        }

        public void Add(Actor actor)
        {
            mActors.Add(actor);
        }

        public bool Remove(Actor actor)
        {
            return mActors.Remove(actor);
        }
    }
}