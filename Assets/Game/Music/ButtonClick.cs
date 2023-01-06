using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Button), typeof(AudioSource))]
public class ButtonClick : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;
    [SerializeField] private AudioMixerGroup _mixerGroup;

    private Button _button;
    private AudioSource _source;

    private void Start()
    {
        _button = GetComponent<Button>();
        _source = GetComponent<AudioSource>();
        _button.onClick.AddListener(Play);
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
