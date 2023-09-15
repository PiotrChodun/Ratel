using Unity.Entities;
using Unity.Mathematics;

namespace Ratel.CharacterController
{
    public struct CharacterControllerInput : IComponentData
    {
        public float2 Movement;
    }
}
