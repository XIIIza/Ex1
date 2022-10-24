using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmSoundController : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private float _target;
    private float _scale = 0.1f;
    private Coroutine _changeVolume;

    public void PlaySound()
    {
        _target = 1f;

        _audioSource.Play();

        _changeVolume = StartCoroutine(ChangeVolume(_target));
    }

    public void StopSound()
    {
        _target = 0f;

        StopCoroutine(_changeVolume);

        _changeVolume = StartCoroutine(ChangeVolume(_target));        
    }

    private IEnumerator ChangeVolume(float target)
    {
        var waitForSeconds = new WaitForSeconds(0.3f);

        while (_audioSource.volume != _target)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, target, _scale);

            yield return waitForSeconds;
        }

        if (_audioSource.volume <= 0)
        {
            _audioSource.Stop();
        }
    }
}