using System;
using UnityEngine;

[Serializable]
public class AudioEntry
{
    [SerializeField]
    [Tooltip("Аудиоклип для воспроизведения.")]
    private AudioClip _clip;

    [SerializeField]
    [Range(0f, 1f)]
    [Tooltip("Громкость: 0 - тишина, 1 - максимальная.")]
    private float _volume = 1f;

    public AudioClip Clip => _clip;
    public float Volume => _volume;
}