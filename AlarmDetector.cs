using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Collider2D), typeof(AlarmSound))]

public class AlarmDetector : MonoBehaviour
{
    private AlarmSound _alarmSoundController;

    private void Start()
    {
        _alarmSoundController = GetComponent<AlarmSound>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Movement>(out Movement movement))
        {
            _alarmSoundController.PlaySound();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Movement>(out Movement movement))
        {
            _alarmSoundController.StopSound();
        }
    }
}
