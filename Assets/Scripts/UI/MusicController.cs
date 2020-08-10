using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private AudioSource audiosrc;

    private float musicVolume = 1f;
    // Start is called before the first frame update
    void Start()
    {
        audiosrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        audiosrc.volume = musicVolume;
        
    }
    public void setVolume(float vol)
    {
        musicVolume = vol;
    }
}
