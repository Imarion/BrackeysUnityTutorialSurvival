using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioZones : MonoBehaviour
{
    public AudioSource thisAudioSource;

    private string TheCollider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        TheCollider = other.tag;
        if (TheCollider == "Player") {
            thisAudioSource.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        TheCollider = other.tag;
        if (TheCollider == "Player")
        {
            thisAudioSource.Stop();
        }

    }
}
