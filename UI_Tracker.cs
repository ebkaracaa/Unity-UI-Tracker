using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class UITrackerWindow : EditorWindow
{
    private const int MaxChangeCount = 50;
    private readonly List<string> _changes = new List<string>();
    private Vector2 _scrollPosition;

    [MenuItem("Window/UI Tracker")] // Add a menu item to Unity Editor to display the UI Tracker window.

    public static void ShowWindow()
    {
        GetWindow<UITrackerWindow>("UI Tracker");
    }

    private void OnEnable()
    {
        Undo.undoRedoPerformed += OnUndoRedoPerformed;
    }
    private void OnDisable()
    {
        Undo.undoRedoPerformed -= OnUndoRedoPerformed;
    }

    private void OnUndoRedoPerformed() // Add the current change description to the list of changes and update the UI.
    {
        string changeDescription = Undo.GetCurrentGroupName();
        if (string.IsNullOrEmpty(changeDescription))
        {
            return;
        }

      
        if (_changes.Count > 0 && _changes[_changes.Count - 1] == changeDescription)   // Check if the current change description is the same as the last one.
        {
            return;
        }

        if (_changes.Count >= MaxChangeCount)         // Remove the oldest change if the maximum number of changes has been reached.
        {
            _changes.RemoveAt(0);
        }

        _changes.Add(changeDescription);         // Add the new change description to the list of changes and update the UI.
        Repaint();
    }
    // Draw the UI Tracker window.
    private void OnGUI()
    {
        GUILayout.Label("UI Tracker", EditorStyles.boldLabel);
        _scrollPosition = EditorGUILayout.BeginScrollView(_scrollPosition, GUILayout.ExpandHeight(true));         // Add a scrollable list of change descriptions.

        for (int i = _changes.Count - 1; i >= 0; i--)
        {
            EditorGUILayout.LabelField($"{i + 1}. {_changes[i]}");
        }

        EditorGUILayout.EndScrollView();
        var clearButtonRect = new Rect(position.width - 110f, 5f, 100f, 20f);

        if (GUI.Button(clearButtonRect, "Clear History"))
        {
            if (EditorUtility.DisplayDialog("Clear History", "Bak emin misin? Gidecek her þey", "Sil gitsin", "Dur bakiym lazým olur"))
            {
                _changes.Clear();
            }
        }
    }

}
