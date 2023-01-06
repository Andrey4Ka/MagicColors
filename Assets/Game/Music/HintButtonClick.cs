using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(HintButton), typeof(AudioSource))]
public class HintButtonClick : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;
    [SerializeField] private AudioMixerGroup _mixerGroup;

    private HintButton _button;
    private AudioSource _source;

    private void Awake()
    {
        _button = GetComponent<HintButton>();
        _source = GetComponent<AudioSource>();

        _button.OnDown += Play;
    }

    private void Play()
    {
        _source.Play();
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        var source = GetComponent<AudioSource>();
        source.outputAudioMixerGroup = _mixerGroup;
        source.clip = _clip;
        source.playOnAwake = false;
    }
#endif
}