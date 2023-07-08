using Unity.Entities;
using UnityEngine;

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
                AddComponent<CubeInput>(entity);
            }
        }
    }
}
