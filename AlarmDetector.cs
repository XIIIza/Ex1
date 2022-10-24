using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmDetector : MonoBehaviour
{
    private AlarmSoundController _alarmSoundController;

    private void Start()
    {
        _alarmSoundController = GetComponent<AlarmSoundController>();
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
