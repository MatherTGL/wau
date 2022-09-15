#if UNITY_EDITOR

using UnityEngine;
using Sirenix.OdinInspector;
using Planet;

public sealed class SettingsEditorScene : MonoBehaviour
{
    [SerializeField, BoxGroup("Parameters")]
    private MovementPlanetOrbit[] _movementPlanetOrbitObjects;

    [EnumToggleButtons]
    private enum SpeedPlanet { Stop = 0, Default = 1, X2 = 2, X4 = 4, X16 = 16, X256 = 256, }

    [SerializeField, BoxGroup("Parameters/Speed"), Sirenix.OdinInspector.HideLabel]
    private SpeedPlanet _speedPlanet;

    [EnumToggleButtons]
    private enum DebugEditor { Enable, Disable }

    [SerializeField, BoxGroup("Parameters/Debug"), Sirenix.OdinInspector.HideLabel]
    private DebugEditor _debugEditor;

    #region Debug

    [SerializeField, BoxGroup("Parameters/Debug"), LabelText("Show Name"), Sirenix.OdinInspector.ShowIf("_debugEditor", DebugEditor.Enable)]
    [ToggleLeft, Sirenix.OdinInspector.HideLabel]
    private bool _isDebugName;

    [SerializeField, BoxGroup("Parameters/Debug"), LabelText("Show Type Move"), Sirenix.OdinInspector.ShowIf("_debugEditor", DebugEditor.Enable)]
    [ToggleLeft, Sirenix.OdinInspector.HideLabel]
    private bool _isDebugTypeMove;

    [SerializeField, BoxGroup("Parameters/Debug"), LabelText("Show Change Planet Zone"), Sirenix.OdinInspector.ShowIf("_debugEditor", DebugEditor.Enable)]
    [ToggleLeft, Sirenix.OdinInspector.HideLabel]
    private bool _isDebugChangePlanetZone;

    #endregion


    private void OnValidate()
    {
        _movementPlanetOrbitObjects = FindObjectsOfType<MovementPlanetOrbit>();
        ChangePlanetScene[] changePlanetZoneObjects = FindObjectsOfType<ChangePlanetScene>();

        SearchPlanetsComponentObject();
        SearchChangePlanetZoneObjects(changePlanetZoneObjects);

        CheckingActivatedDebug();
        

        return;
    }
        
    private void SearchPlanetsComponentObject()
    {
        for (int i = 0; i < _movementPlanetOrbitObjects.Length; i++)
        {
            GameObject planet = _movementPlanetOrbitObjects[i].gameObject;

            planet.GetComponent<MovementPlanetOrbit>().ChangeSpeedPlanet((int)_speedPlanet);
        }
    }

    private void SearchChangePlanetZoneObjects(ChangePlanetScene[] changePlanetScene)
    {
        for (int i = 0; i < changePlanetScene.Length; i++)
        {
            GameObject zone = changePlanetScene[i].gameObject;

            if (_debugEditor == DebugEditor.Enable)
                zone.GetComponent<ChangePlanetScene>().ActiveDebug(_isDebugChangePlanetZone);
            else
                zone.GetComponent<ChangePlanetScene>().ActiveDebug(false);
        }
    }

    private void CheckingActivatedDebug()
    {
        if (_debugEditor == DebugEditor.Enable)
            MovementPlanetOrbit.ActiveDebug(true);
        else
            MovementPlanetOrbit.ActiveDebug(false);

        MovementPlanetOrbit.ActiveDebugTypeMove(_isDebugTypeMove);

        MovementPlanetOrbit.ActiveDebugName(_isDebugName);
    }
}
#endif