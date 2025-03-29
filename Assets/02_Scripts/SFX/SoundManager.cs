using System;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] _BGMAudioClips;
    private AudioSource[] _BGMaudioSources;
    private int _currentBGM;
    private int _totalNumberOfBGMs;
    private float _currentAllBGMVolume = 0.3f;
    
    public void StopBGM(int i)
    {
        i = _currentBGM;
        _BGMaudioSources[i].Stop();
    }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject); // 어떤 씬으로 넘어가던 본 객체가 절대 부서지지 마시오.
        _totalNumberOfBGMs = _BGMAudioClips.Length;
        _BGMaudioSources = new AudioSource[_totalNumberOfBGMs];
        
        //AudioClip[]을 AudioSorce[]로 변환
        for (int i = 0; i < _totalNumberOfBGMs; i++)
        {
            _BGMaudioSources[i] = gameObject.AddComponent<AudioSource>();
            _BGMaudioSources[i].clip = _BGMAudioClips[i];
            _BGMaudioSources[i].playOnAwake = false;
        }
    }

    private void ChangeAllBGMsVolume(float volume)
    {
        _currentAllBGMVolume = volume;
    }
    

    private void PlayBGM(int i)
    {
        if (i >= _totalNumberOfBGMs)
        {
            Debug.Log("BGM Not Found");
            return;
        }

        _BGMaudioSources[i].volume = _currentAllBGMVolume;
        _BGMaudioSources[i].Play();
    }

    private void Start()
    {
        ChangeAllBGMsVolume(_currentAllBGMVolume);
        PlayBGM(0);
    }
}

