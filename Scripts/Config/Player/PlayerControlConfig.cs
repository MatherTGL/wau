using UnityEngine;
using Sirenix.OdinInspector;

namespace ControlPlayer
{
    [CreateAssetMenu(fileName = "PlayerControlConfig", menuName = "Config/Player/Control/Create Config", order = 51)]
    public sealed class PlayerControlConfig : ScriptableObject
    {
        [SerializeField, BoxGroup("Parameters"), MinValue(1.0f)]
        public float speedMove = 1.0f;

        [SerializeField, BoxGroup("Parameters"), MinValue(1.0f)]
        public float speedRotation = 1.0f;

        [SerializeField, BoxGroup("Parameters"), MinValue(1.0f)]
        public float speedZoom = 1.0f;

        [SerializeField, BoxGroup("Parameters"), MinValue(-100.0f), MaxValue(-1.0f)]
        public float minVerticalAngle = -60.0f;

        [BoxGroup("Parameters"), MaxValue(100.0f), MinValue(1.0f)]
        public float maxVerticalAngle = 70.0f;

        [BoxGroup("Parameters"), MaxValue(1.0f), MinValue(0.1f)]
        public float timeSpeedRotation = 0.1f;

        [EnumToggleButtons]
        public enum MovementType
        {
            Base, Planet, Space, Object
        }

        [BoxGroup("Parameters")]
        public MovementType TypeMovement;
    }
}