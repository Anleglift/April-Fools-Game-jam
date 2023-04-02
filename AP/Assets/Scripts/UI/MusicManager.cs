using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource Music;
    // Start is called before the first frame update
    void Start()
    {
        Music.Play();
    }
}
