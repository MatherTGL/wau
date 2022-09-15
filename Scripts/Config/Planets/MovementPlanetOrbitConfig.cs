using UnityEngine;
using Sirenix.OdinInspector;

namespace Planet
{
    [CreateAssetMenu(fileName = "PlanetOrbitMotionNameConfig", menuName = "Config/Planet/Motion/Create Config", order = 51)]
    public sealed class MovementPlanetOrbitConfig : ScriptableObject
    {
        #region Movement

        [Sirenix.OdinInspector.Title("Movement")]
        [MaxValue(1000.0f), BoxGroup("Parameters")]
        public double defaultSpeedPlanet;
        
        [ReadOnly, BoxGroup("Parameters")]
        public double currentSpeedPlanet;

        [BoxGroup("Parameters/Vector3", false), LabelText("Use Offset"), ToggleLeft]
        public bool isUseOffsetCenter;

        [BoxGroup("Parameters/Vector3", false)]
        public Vector3 directionRotate;

        [BoxGroup("Parameters/Vector3", false), Sirenix.OdinInspector.ShowIf("isUseOffsetCenter")]
        public Vector3 offsetCenter;

        [EnumToggleButtons]
        public enum CenterRotation { Zero, Satellite }

        [BoxGroup("Parameters/Center Rotation", false)]
        public CenterRotation centerRotation;

        [BoxGroup("Parameters/Center Rotation", false), Required, Sirenix.OdinInspector.ShowIf("centerRotation", CenterRotation.Satellite)]
        public GameObject pointRotatePlanet;

        [EnumToggleButtons]
        public enum TypeMovementPlanet { NonPhysics, Physics }

        [BoxGroup("Parameters/Type Movement Planet", false) ]
        public TypeMovementPlanet typeMovementPlanet;

        [ReadOnly, BoxGroup("Parameters/Type Movement Planet"), Sirenix.OdinInspector.ShowIf("typeMovementPlanet", TypeMovementPlanet.Physics)]
        public Rigidbody rigidbody;

        [ReadOnly, BoxGroup("Parameters/Type Movement Planet"), Sirenix.OdinInspector.ShowIf("typeMovementPlanet", TypeMovementPlanet.Physics)]
        public Vector3 currentVelocity;

        [Required(), BoxGroup("Parameters/Type Movement Planet"), Sirenix.OdinInspector.ShowIf("typeMovementPlanet", TypeMovementPlanet.Physics)]
        public GameObject parentPhysicsPlanet;

        [BoxGroup("Parameters/Type Movement Planet"), Sirenix.OdinInspector.ShowIf("typeMovementPlanet", TypeMovementPlanet.Physics)]
        public Vector3 startVelocity;
        
        #endregion

        #region Rotation

        [Sirenix.OdinInspector.Title("Rotation")]
        [MinValue(-100.0f), MaxValue(100.0f), BoxGroup("Parameters")]
        public float speedRotation;

        [EnumToggleButtons]
        public enum TypeSpaceRotate
        {
            World, Self
        }

        [BoxGroup("Parameters")]
        public TypeSpaceRotate typeSpaceRotate;

        #endregion
    }
}