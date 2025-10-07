using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneDialogueNoises : MonoBehaviour
{
    public AudioClip[] phoneWehs;
    public AudioSource phoneSpeaker;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayWeh()
    {
        AudioClip wehToPlay = phoneWehs[Random.Range(0, phoneWehs.Length)];
        phoneSpeaker.clip = wehToPlay;
        phoneSpeaker.Play();
    }
}
