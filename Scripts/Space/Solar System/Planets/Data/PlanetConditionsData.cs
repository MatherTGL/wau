using UnityEngine;
using Sirenix.OdinInspector;

namespace Planet
{
    //[RequireComponent(typeof(PlanetResourcesData))]
    public sealed class PlanetConditionsData : MonoBehaviour
    {
        [SerializeField, BoxGroup("Parameters"), ToggleLeft, LabelText("Atmosphere")]
        private bool _isAtmosphere;

        [SerializeField, BoxGroup("Parameters"), ToggleLeft, LabelText("Weather Conditions")]
        private bool _isWeatherConditions;

        [SerializeField, BoxGroup("Parameters"), ToggleLeft, LabelText("Magnetic Field")]
        private bool _isMagneticField;

        [SerializeField, BoxGroup("Parameters/Atmosphere"), Sirenix.OdinInspector.ShowIf("_isAtmosphere")]
        private uint _atmospherePressure;

        [SerializeField, BoxGroup("Parameters"), Space(5.0f)]
        private int _minTemperature;

        [SerializeField, BoxGroup("Parameters")]
        private int _maxTemperature;

        [SerializeField, BoxGroup("Parameters"), MinValue(0.0f)]
        private float _atmosphereHumidity;

        [SerializeField, BoxGroup("Parameters"), MinValue(0.0f)]
        private float _accelerationGravity;

        [SerializeField, BoxGroup("Parameters"), MinValue(0.0f)]
        private float _radiationBackground;

        [SerializeField, BoxGroup("Parameters/Cosmic Speed"), MinValue(0.0f)]
        private float _firstCosmicSpeed;

        [SerializeField, BoxGroup("Parameters/Cosmic Speed"), MinValue(0.0f)]
        private float _secondCosmicSpeed;


        #region Composition of the Atmosphere

        [SerializeField, BoxGroup("Parameters/Composition of the Atmosphere in %"), MinValue(0.0f), MaxValue(100.0f)]
        private float _atmosphereOxygen;

        [SerializeField, BoxGroup("Parameters/Composition of the Atmosphere in %"), MinValue(0.0f), MaxValue(100.0f)]
        private float _atmosphereSodium;

        [SerializeField, BoxGroup("Parameters/Composition of the Atmosphere in %"), MinValue(0.0f), MaxValue(100.0f)]
        private float _atmosphereHydrogen;

        [SerializeField, BoxGroup("Parameters/Composition of the Atmosphere in %"), MinValue(0.0f), MaxValue(100.0f)]
        private float _atmosphereHelium;

        [SerializeField, BoxGroup("Parameters/Composition of the Atmosphere in %"), MinValue(0.0f), MaxValue(100.0f)]
        private float _atmospherePotassium;

        [SerializeField, BoxGroup("Parameters/Composition of the Atmosphere in %"), MinValue(0.0f), MaxValue(100.0f)]
        private float _atmosphereRest;

        #endregion
    }
}