using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource music;
    void Start()
    {

        DontDestroyOnLoad(transform.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayMusic()
    {
        if (music.isPlaying) return;
        music.Play();
    }

    public void StopMusic()
    {
        music.Stop();
    }
}
