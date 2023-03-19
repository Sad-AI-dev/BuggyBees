using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DevKit;

public class OnStart : MonoBehaviour
{
    public UnityEvent onStart;

    void Start()
    {
        onStart?.Invoke();
    }

    public void PlaySound(string sound)
    {
        AudioManager.instance.PlayOneShot(sound);
    }
}
