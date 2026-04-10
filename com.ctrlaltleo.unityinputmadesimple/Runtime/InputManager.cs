using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class InputManager : MonoBehaviour
{
    private static InputManager _instance;

    [Header("Configurações de Asset")]
    public InputActionAsset inputAsset;
    [HideInInspector] public string defaultActionMap;

    // Dicionários para armazenar a velocidade persistente do SmoothDamp por Action
    private Dictionary<string, Vector2> _v2Velocities = new Dictionary<string, Vector2>();
    private Dictionary<string, Vector2> _v2CurrentValues = new Dictionary<string, Vector2>();
    
    private Dictionary<string, Vector3> _v3Velocities = new Dictionary<string, Vector3>();
    private Dictionary<string, Vector3> _v3CurrentValues = new Dictionary<string, Vector3>();

    private void Awake()
    {
        if (_instance != null && _instance != this) { Destroy(gameObject); return; }
        _instance = this;
        DontDestroyOnLoad(gameObject);

        if (inputAsset != null)
            inputAsset.FindActionMap(defaultActionMap)?.Enable();
    }

    #region Vector2 Getters

    public static Vector2 GetVector2(string actionName)
    {
        var action = _instance.inputAsset.FindAction(actionName);
        return action != null ? action.ReadValue<Vector2>() : Vector2.zero;
    }

    /// <summary>
    /// Retorna o Vector2 suavizado usando SmoothDamp.
    /// </summary>
    /// <param name="smoothTime">Tempo aproximado para atingir o valor alvo.</param>
    public static Vector2 GetVector2(string actionName, float smoothTime)
    {
        var action = _instance.inputAsset.FindAction(actionName);
        if (action == null) return Vector2.zero;

        Vector2 target = action.ReadValue<Vector2>();

        // Inicializa entradas no dicionário se não existirem
        if (!_instance._v2Velocities.ContainsKey(actionName))
        {
            _instance._v2Velocities[actionName] = Vector2.zero;
            _instance._v2CurrentValues[actionName] = Vector2.zero;
        }

        Vector2 velocity = _instance._v2Velocities[actionName];
        
        // Aplica a suavização
        _instance._v2CurrentValues[actionName] = Vector2.SmoothDamp(
            _instance._v2CurrentValues[actionName], 
            target, 
            ref velocity, 
            smoothTime
        );

        // Salva a velocidade de volta para o próximo frame
        _instance._v2Velocities[actionName] = velocity;

        return _instance._v2CurrentValues[actionName];
    }

    #endregion

    #region Vector3 Getters

    public static Vector3 GetVector3(string actionName)
    {
        var action = _instance.inputAsset.FindAction(actionName);
        return action != null ? action.ReadValue<Vector3>() : Vector3.zero;
    }

    public static Vector3 GetVector3(string actionName, float smoothTime)
    {
        var action = _instance.inputAsset.FindAction(actionName);
        if (action == null) return Vector3.zero;

        Vector3 target = action.ReadValue<Vector3>();

        if (!_instance._v3Velocities.ContainsKey(actionName))
        {
            _instance._v3Velocities[actionName] = Vector3.zero;
            _instance._v3CurrentValues[actionName] = Vector3.zero;
        }

        Vector3 velocity = _instance._v3Velocities[actionName];
        
        _instance._v3CurrentValues[actionName] = Vector3.SmoothDamp(
            _instance._v3CurrentValues[actionName], 
            target, 
            ref velocity, 
            smoothTime
        );

        _instance._v3Velocities[actionName] = velocity;

        return _instance._v3CurrentValues[actionName];
    }

    #endregion

    #region Button States & Action Maps
    public static bool GetButton(string actionName) => _instance.inputAsset.FindAction(actionName)?.IsPressed() ?? false;
    public static bool GetButtonDown(string actionName) => _instance.inputAsset.FindAction(actionName)?.triggered ?? false;
    public static bool GetButtonUp(string actionName) => _instance.inputAsset.FindAction(actionName)?.WasReleasedThisFrame() ?? false;

    public static void SwitchActionMap(string mapName)
    {
        foreach (var map in _instance.inputAsset.actionMaps) map.Disable();
        _instance.inputAsset.FindActionMap(mapName)?.Enable();
    }
    #endregion
}