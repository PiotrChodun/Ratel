using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Transforms;
using Unity.Burst;

using Ratel.CharacterController;

namespace Ratel
{

    [UpdateInGroup(typeof(PredictedSimulationSystemGroup))]
    [BurstCompile]
    public partial struct CubeMovementSystem : ISystem
    {
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var speed = SystemAPI.Time.DeltaTime * 4;
            
            foreach (var (input, trans) in SystemAPI.Query<RefRO<CharacterControllerInput>, RefRW<LocalTransform>>().WithAll<Simulate>())
            {
                float2 moveInput = input.ValueRO.Movement * speed;
                trans.ValueRW.Position += new float3(moveInput.x, 0, moveInput.y);
            }
            /*
            foreach (var (input, trans) in SystemAPI.Query<RefRO<CubeInput>, RefRW<LocalTransform>>().WithAll<Simulate>())
            {
                var moveInput = new float2(input.ValueRO.Horizontal, input.ValueRO.Vertical);
                moveInput = math.normalizesafe(moveInput) * speed;
                trans.ValueRW.Position += new float3(moveInput.x, 0, moveInput.y);
            }
            */
            
        }
    }
}