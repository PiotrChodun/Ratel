using Unity.NetCode;

namespace Ratel
{
    [GhostComponent(PrefabType = GhostPrefabType.AllPredicted)]
    public struct CubeInput : IInputComponentData
    {
        public int Horizontal;
        public int Vertical;
    }
}
