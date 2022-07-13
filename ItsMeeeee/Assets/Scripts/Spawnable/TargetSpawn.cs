using LowTeeGames;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawn : MonoBehaviour
{
    public AudioSource audioSrc;
    public List<AudioClip> spawnClips;
    public GameObject deathSoundObject;

    private void Awake()
    {
        audioSrc = GetComponent<AudioSource>();
    }


    private void OnClick(OnClickedEvent info)
    {
        if (info.target == TargetType.Target)
        {

            audioSrc.Stop();
            Pool.Instance.GetItemFromPool(deathSoundObject, Vector2.zero, Quaternion.identity);
        }
    }

    private void OnEnable()
    {
        audioSrc.PlayOneShot(spawnClips.GetRandom());
        OnClickedEvent.RegisterListener(OnClick);

        OnTargetAppearedEvent onTargetAppearedEvent = new OnTargetAppearedEvent();
        onTargetAppearedEvent.FireEvent();
    }

    private void OnDisable()
    {
        OnClickedEvent.UnregisterListener(OnClick);
    }
}
