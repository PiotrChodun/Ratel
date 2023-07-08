using Unity.Entities;
using UnityEngine;

namespace Ratel
{
    [DisallowMultipleComponent]
    public class CubeSpawnerAuthoring : MonoBehaviour
    {
        public GameObject Cube;

        class Baker : Baker<CubeSpawnerAuthoring>
        {
            public override void Bake(CubeSpawnerAuthoring authoring)
            {
                Entity entity = this.GetEntity(TransformUsageFlags.WorldSpace);

                CubeSpawner component = default(CubeSpawner);
                component.Cube = GetEntity(authoring.Cube, TransformUsageFlags.Dynamic);
                AddComponent(entity, component);
            }
        }
    }
}
