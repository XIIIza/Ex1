using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class AlarmSound : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] [Range(0f, 0.9f)] private float _minimumVolume;
    [SerializeField] [Range(0.1f, 1f)] private float _maximumVolume;
    [SerializeField] [Range (0.01f , 1f)] private float _scale;
    [SerializeField] private float _waitForSecond;

    private float _volume;
    private Coroutine _changeVolume;

    public void PlaySound()
    {
        if(_changeVolume != null)
        {
            StopCoroutine(_changeVolume);
        }

        _volume = _maximumVolume;

        _audioSource.Play();

        _changeVolume = StartCoroutine(ChangeVolume(_volume));
    }

    public void StopSound()
    {
        if (_changeVolume != null)
        {
            StopCoroutine(_changeVolume);
        }

        _volume = _minimumVolume;

        _changeVolume = StartCoroutine(ChangeVolume(_volume));        
    }

    private IEnumerator ChangeVolume(float target)
    {
        var waitForSeconds = new WaitForSeconds(_waitForSecond);

        while (_audioSource.volume != _volume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, target, _scale);

            yield return waitForSeconds;
        }

        if (_audioSource.volume <= _minimumVolume)
        {
            _audioSource.Stop();
        }
    }
}