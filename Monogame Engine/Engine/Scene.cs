using System.Collections.Generic;
using Monogame_Engine.Engine.Mesh;

namespace Monogame_Engine.Engine
{
    class Scene
    {

        public readonly List<ActorBatch> mActorBatches;
        public readonly Light mDirectionalLight;

        public Scene()
        {
            mActorBatches = new List<ActorBatch>();
            mDirectionalLight = new Light();
        }

        public void Add(Actor actor)
        {

            // Search for the ActorBatch
            var actorBatch = mActorBatches.Find(ele => ele.mMesh == actor.mMesh);

            // If there is no ActorBatch which already uses the mesh of the Actor we
            // need to create a new ActorBatch and add it to mActorBatches
            if (actorBatch == null)
            {
                actorBatch = new ActorBatch(actor.mMesh);
                mActorBatches.Add(actorBatch);
            }

            actorBatch.Add(actor);

        }

        public bool? Remove(Actor actor)
        {

            var actorBatch = mActorBatches.Find(ele => ele.mMesh == actor.mMesh);

            return actorBatch?.Remove(actor);

        }

    }
}