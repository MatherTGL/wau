using UnityEngine;
using UnityEngine.SceneManagement;
using Sirenix.OdinInspector;

[AddComponentMenu("Planet/Change Scene")]
public sealed class ChangePlanetScene : MonoBehaviour
{
    [SerializeField, SceneDetails, BoxGroup("Parameters")]
    private SerializedScene _loadingScene;


    private void OnMouseDown()
    {
        try
        {
            SceneManager.LoadScene(_loadingScene.ToString(), LoadSceneMode.Single);
        }
        catch
        {
            Debug.LogError($"Unable to load planet scene. Missing. { gameObject.name }");
        }          
    }

#if UNITY_EDITOR
    #region Debug

    [SerializeField, BoxGroup("Parameters/Debug")]
    private float _debugRadiusSphere = 1.0f;

    private bool _isUseDebug;
    

    public void ActiveDebug(in bool state) => _isUseDebug = state;

    private void OnDrawGizmos()
    {
        if (_isUseDebug)
        {
            Gizmos.DrawWireSphere(transform.position, transform.lossyScale.x * _debugRadiusSphere);
        }
    }

    #endregion
#endif
}
