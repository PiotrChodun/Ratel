using Unity.Entities;
using UnityEngine;

namespace Ratel
{

    [DisallowMultipleComponent]
    public class CubeAuthoring : MonoBehaviour
    {
        class Baker : Baker<CubeAuthoring>
        {
            public override void Bake(CubeAuthoring authoring)
            {
                Entity entity = this.GetEntity(TransformUsageFlags.Dynamic);

                AddComponent<Cube>(entity);
            }
        }
    }
}
