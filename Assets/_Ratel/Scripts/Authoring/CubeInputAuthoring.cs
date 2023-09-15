using Unity.Entities;
using UnityEngine;

using Ratel.CharacterController;

namespace Ratel
{
    [DisallowMultipleComponent]
    public class CubeInputAuthoring : MonoBehaviour
    {
        class Baking : Baker<CubeInputAuthoring>
        {
            public override void Bake(CubeInputAuthoring authoring)
            {
                Entity entity = this.GetEntity(TransformUsageFlags.Dynamic);
                AddComponent<CharacterControllerInput>(entity);
                AddComponent<CubeInput>(entity);
            }
        }
    }
}
