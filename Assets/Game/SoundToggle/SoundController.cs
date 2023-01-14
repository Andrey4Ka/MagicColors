using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    [SerializeField] private Toggle _soundToggle;
    [SerializeField] private Toggle _musicToggle;
    [SerializeField] private AudioMixer _mixer;

    private const float OffVolume = -80;
    private const float OnVolume = 0;

    private const string SoundVolumeKey = "SoundVolume";
    private const string MusicVolumeKey = "MusicVolume";
    private const string MasterVolumeKey = "MasterVolume";

    private void Start()
    {
        _mixer.GetFloat(SoundVolumeKey, out var soundValue);
        _mixer.GetFloat(MusicVolumeKey, out var musicValue);
        _soundToggle.isOn = soundValue == 0;
        _musicToggle.isOn = musicValue == 0;

        _soundToggle.onValueChanged.AddListener((value) => _mixer.SetFloat(SoundVolumeKey, value ? OnVolume : OffVolume));
        _musicToggle.onValueChanged.AddListener((value) => _mixer.SetFloat(MusicVolumeKey, value ? OnVolume : OffVolume));
    }

    public void HardMute()
    {
        HardSetActive(false);
    }

    public void HardUnmute()
    {
        HardSetActive(true);
    }

    private void HardSetActive(bool active)
    {
        _mixer.SetFloat(MasterVolumeKey, active ? OnVolume : OffVolume);
    }
}
