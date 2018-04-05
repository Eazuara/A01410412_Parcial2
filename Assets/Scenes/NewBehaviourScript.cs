using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class NewBehaviourScript : MonoBehaviour {

    public MovieTexture movie;
    private AudioSource audio;

    // Use this for initialization
    void Start () {
        GetComponent<UnityEngine.UI.RawImage>().texture = movie as MovieTexture;
            audio = GetComponent<AudioSource>();
        audio.clip = movie.audioClip;
        movie.Play();
        audio.Play();
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Space) && movie.isPlaying)
        {
            movie.Pause();
        }else if (Input.GetKeyDown(KeyCode.Space) && !movie.isPlaying)
        {
            movie.Play();
        }

		
	}
}
