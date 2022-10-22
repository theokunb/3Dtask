using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Signaling : MonoBehaviour
{
    [SerializeField] float _volumePerSecond;

    private AudioSource _audioSource;
    private readonly int minVolume = 0;
    private readonly int maxVolume = 1;
    private Coroutine _startPlay;
    private Coroutine _stopPlay;


    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0;
    }

    public void StartPlay()
    {
        if(_stopPlay != null)
        {
            StopCoroutine(_stopPlay);
        }
        
        _startPlay = StartCoroutine(ChangeVolume(_audioSource.volume, maxVolume));
        _audioSource.Play();
    }

    public void StopPlay()
    {
        if(_startPlay != null)
        {
            StopCoroutine(_startPlay);
        }
        
        _stopPlay = StartCoroutine(ChangeVolume(_audioSource.volume, minVolume));

        if(_audioSource.volume == minVolume)
        {
            _audioSource.Stop();
        }
    }

    private IEnumerator ChangeVolume(float from, float to)
    {
        for(float i = minVolume; i <= maxVolume; i += _volumePerSecond * Time.deltaTime)
        {
            _audioSource.volume = Mathf.MoveTowards(from, to, i);
            yield return null;
        }
    }
}