using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Music : MonoBehaviour
{
    [SerializeField] private AudioClip[] _clips;

    private AudioSource _source;

    private static Music _instance;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        _source = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
    }

    private IEnumerator Start()
    {
        var i = 0;
        while (true)
        {
            if (i >= _clips.Length)
            {
                i = 0;
            }

            _source.clip = _clips[i];
            _source.Play();
            yield return new WaitForSeconds(_source.clip.length - _source.time);
            i++;
        }
    }
}
