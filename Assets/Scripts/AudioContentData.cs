using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "AudioContentData", menuName = "Audio/Content Data")]

public class AudioContentData : ScriptableObject
{
    [SerializeField]
    [Tooltip("Уникальный идентификатор этого объекта")]
    private string id;

    [SerializeField]
    private AudioContentType contentType;

    [SerializeField]
    private List<AudioEntry> dangerousAudio = new List<AudioEntry>();

    [SerializeField]
    private List<AudioEntry> friendlyAudio = new List<AudioEntry>();

    [SerializeField]
    private List<AudioEntry> neutralAudio = new List<AudioEntry>();

    [SerializeField]
    [TextArea(5, 12)]
    [Tooltip("Длинный текст для панели")]
    private string panelText;

    public string Id => id;
    public AudioContentType ContentType => contentType;
    public string PanelText => panelText;
}