using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] _BGMAudioClips;
    private AudioSource[] _BGMaudioSources;
    private int _totalNumberOfBGMs;
    private float _currentBGMVolume = 0.3f;
    private AudioSource _currentBGM;
    
    public void ChangeVolumeSlowly()
    {
        
        StartCoroutine(ChangeVolumeCoroutine(_currentBGM, 0.05f));
    }
    
    public void StopBGM(int i)
    {
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

    private void ChangeBGMVolume(float volume)
    {
        _currentBGMVolume = volume;
    }
    

    private void PlayBGM(int i)
    {
        if (i >= _totalNumberOfBGMs)
        {
            Debug.Log("BGM Not Found");
            return;
        }

        _BGMaudioSources[i].volume = _currentBGMVolume;
        _BGMaudioSources[i].loop = true;
        _BGMaudioSources[i].Play();
        _currentBGM = _BGMaudioSources[i];
    }

    private void Start()
    {
        ChangeBGMVolume(_currentBGMVolume);
        PlayBGM(0);
    }

    private IEnumerator ChangeVolumeCoroutine(AudioSource currentBGM, float targetVolume)
    {
        for (float i = currentBGM.volume; currentBGM.volume >= targetVolume ; i -= Time.deltaTime)
        {
            Debug.Log($"Current Volume : {i}");
            Debug.Log($"Target Volume : {targetVolume}");
            currentBGM.volume = i;
            if (Mathf.Approximately(currentBGM.volume, 0f))
            {
                currentBGM.volume = 0f;
                Debug.Log("ChageVolumeCoroutine : Deactivate");
                yield break;
                Debug.Log("ERROR");
            }
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}

