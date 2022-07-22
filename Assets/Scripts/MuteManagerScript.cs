using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteManagerScript : MonoBehaviour
{
    bool SFXVolume, MusicVolume;
    public Toggle sToggle, mToggle;
    int flag = 420;
    // Start is called before the first frame update
    void Start()
    {

        if (PlayerPrefs.HasKey("issfxmuted"))
        {
            int pp = PlayerPrefs.GetInt("issfxmuted");
            if (pp == 0)
            {
                SFXVolume = true;
                sToggle.isOn = true;
            }
            else
            {
                SFXVolume = false;
                sToggle.isOn = false;
            }


        }
        else
        {
            PlayerPrefs.SetInt("issfxmuted", 0);
            SFXVolume = true;
            sToggle.isOn = true;
        }
        //-----------------------------------------------------------------------
        if (PlayerPrefs.HasKey("ismusicmuted"))
        {
            int pp = PlayerPrefs.GetInt("ismusicmuted");
            if (pp == 0)
            {
                MusicVolume = true;
                mToggle.isOn = true;
            }

            else
            {
                MusicVolume = false;
                mToggle.isOn = false;
            }

        }
        else
        {
            PlayerPrefs.SetInt("ismusicmuted", 0);
            MusicVolume = true;
            mToggle.isOn = true;
        }

        //----------------------------------------------------------------------
        flag = 69;

        SoundControllerScript.SFXInstance.ads.mute = !SFXVolume;
        MusicControlScript.BGMusicInstance.musiq.mute = !MusicVolume;

        // Debug.Log("PP"+PlayerPrefs.GetInt("issfxmuted"));
        //Debug.Log(SFXVolume);
    }

    public void sTogglePress()
    {
        if (flag == 69)
        {
            //Debug.Log("PressCalled");

            SoundControllerScript.SFXInstance.ads.mute = SFXVolume;
            SFXVolume = !SFXVolume;
            if (SFXVolume == true)
            {
                PlayerPrefs.SetInt("issfxmuted", 0);
                //Debug.Log("Unmuted");
            }
            else
            {
                PlayerPrefs.SetInt("issfxmuted", 1);
                // Debug.Log("muted");
            }

        }

    }

    public void mTogglePress()
    {
        if (flag == 69)
        {
            // Debug.Log("PressCalled");

            MusicControlScript.BGMusicInstance.musiq.mute = MusicVolume;
            MusicVolume = !MusicVolume;
            if (MusicVolume == true)
            {
                PlayerPrefs.SetInt("ismusicmuted", 0);
                // Debug.Log("Unmuted");
            }
            else
            {
                PlayerPrefs.SetInt("ismusicmuted", 1);
                //Debug.Log("muted");
            }

        }

    }

    public void resetPPmusicSound()
    {
        PlayerPrefs.SetInt("issfxmuted", 0);
        PlayerPrefs.SetInt("ismusicmuted", 0);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
