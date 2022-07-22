using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicControlScript : MonoBehaviour
{

    public static MusicControlScript BGMusicInstance;
    public  AudioSource musiq;
    public void Awake()
    {
        if (BGMusicInstance != null && BGMusicInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        BGMusicInstance = this;
        DontDestroyOnLoad(this);
    }



}
