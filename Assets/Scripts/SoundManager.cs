using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public static SoundManager Instance = null;

    public AudioClip goalBloop;
    public AudioClip paddleBloop;
    public AudioClip lossBuzz;
    public AudioClip wallBloop;
    public AudioClip winSound;

    private AudioSource soundEffect;

    // Start is called before the first frame update
    void Start() {
        if (Instance == null) {
            Instance = this;
        } else if (Instance != this) {
            Destroy(gameObject);
        }

        AudioSource[] sources = GetComponents<AudioSource>();

        foreach(AudioSource source in sources) {
            if(source.clip == null) {
                soundEffect = source;
            }
        }
    }

    public void PlayASound(AudioClip clip) {
        soundEffect.PlayOneShot(clip);
    }

}
