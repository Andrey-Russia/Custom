using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AudioContentData))]
[CanEditMultipleObjects]
public class AudioContentDataEditor : Editor
{
    private SerializedProperty _idProperty;
    private SerializedProperty _contentTypeProperty;

    private SerializedProperty _dangerousAudioProperty;
    private SerializedProperty _friendlyAudioProperty;
    private SerializedProperty _neutralAudioProperty;

    private SerializedProperty _panelTextProperty;

    private enum ViewMode
    {
        Hidden,
        AudioList,
        Text
    }

    private ViewMode _viewMode = ViewMode.Hidden;

    private void OnEnable()
    {
        _idProperty = serializedObject.FindProperty("id");
        _contentTypeProperty = serializedObject.FindProperty("contentType");

        _dangerousAudioProperty = serializedObject.FindProperty("dangerousAudio");

        _friendlyAudioProperty = serializedObject.FindProperty("friendlyAudio");

        _neutralAudioProperty = serializedObject.FindProperty("neutralAudio");

        _panelTextProperty = serializedObject.FindProperty("panelText");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.LabelField("Настройки аудиоконтента.", EditorStyles.boldLabel);

        EditorGUILayout.PropertyField(_idProperty, new GUIContent("ID"));

        EditorGUILayout.Space();

        DrawButtons();

        EditorGUILayout.Space();

        switch (_viewMode)
        {
            case ViewMode.AudioList: 
                DrawAudioList();
                break;

            case ViewMode.Text:
                EditorGUILayout.PropertyField(_panelTextProperty, new GUIContent("Текст панели"));
                break;
        }

        serializedObject.ApplyModifiedProperties();
    }

    private void DrawButtons()
    {
        EditorGUILayout.BeginHorizontal();

        if (GUILayout.Button("Показать список."))
        {
            _viewMode = ViewMode.AudioList;

            _dangerousAudioProperty.isExpanded = true;
            _friendlyAudioProperty.isExpanded = true;
            _neutralAudioProperty.isExpanded = true;
        }

        if (GUILayout.Button("Показать текст."))
        {
            _viewMode = ViewMode.Text;
        }

        if (GUILayout.Button("Скрыть всё."))
        {
            _viewMode = ViewMode.Hidden;
        }

        EditorGUILayout.EndHorizontal();
    }

    private void DrawAudioList()
    {
        EditorGUILayout.PropertyField(_contentTypeProperty, new GUIContent("Тип аудиоконтента"));

        if (_contentTypeProperty.hasMultipleDifferentValues)
        {
            EditorGUILayout.HelpBox("Выберите одинаковый тип для выделенных объектов, " + "чтобы редактировать соответствующий список.", MessageType.Info);

            return;
        }

        AudioContentType selectedType = (AudioContentType)_contentTypeProperty.enumValueIndex;

        switch (selectedType)
        {
            case AudioContentType.Dangerous:
                DrawList(_dangerousAudioProperty, "Опасный контент");
                break;

            case AudioContentType.Friendly:
                DrawList(_friendlyAudioProperty, "Дружелюбный контент");
                break;

            case AudioContentType.Neutral:
                DrawList(_neutralAudioProperty, "Нейтральный контент");
                break;
        }
    }

    private void DrawList(SerializedProperty list, string label)
    {
        EditorGUILayout.PropertyField(list, new GUIContent(label), true);
    }
}