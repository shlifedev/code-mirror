using UnityEngine; 

namespace LD
{
    public struct BasePlacerPlacementInfo
    {
        public Vector3 Position { get; set; }
        public Quaternion Rotation { get; set; }
        public Vector3 Scale { get; set; } 
        public Vector3 EulerRotation => Rotation.eulerAngles;
    }
}