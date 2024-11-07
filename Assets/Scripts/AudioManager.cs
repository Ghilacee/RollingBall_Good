using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AudioSource audioSourceSfx;
    public void ReproducirSonido(AudioClip clip)
    {
        audioSourceSfx.PlayOneShot(clip);

    }
    
}
