using UnityEngine;
using UnityEditor;
using UnityEngine.InputSystem;
using System.Linq;

[CustomEditor(typeof(InputManager))]
public class InputManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // Desenha os campos padrão (como o slot do Asset)
        DrawDefaultInspector();

        InputManager script = (InputManager)target;

        if (script.inputAsset == null)
        {
            EditorGUILayout.HelpBox("Arraste um InputActionAsset para selecionar o Action Map.", MessageType.Info);
            return;
        }

        // Obtém todos os nomes de Action Maps do Asset
        string[] mapNames = script.inputAsset.actionMaps.Select(m => m.name).ToArray();

        if (mapNames.Length > 0)
        {
            // Encontra o índice atual para o Popup
            int currentIndex = Mathf.Max(0, System.Array.IndexOf(mapNames, script.defaultActionMap));

            // Desenha o Dropdown (Popup)
            int newIndex = EditorGUILayout.Popup("Default Action Map", currentIndex, mapNames);

            // Salva a escolha de volta no script
            script.defaultActionMap = mapNames[newIndex];

            // Marca o objeto como "sujo" para o Unity salvar a alteração na cena
            if (GUI.changed)
            {
                EditorUtility.SetDirty(script);
            }
        }
    }
}