using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControllerScript : MonoBehaviour
{
    
    public static SoundControllerScript SFXInstance;
    public AudioSource ads;
    public AudioClip gunShot;
    public AudioClip reloadGun;
    public AudioClip RobotShoot,RobotDead,GameOver;
    public void Awake()
    {
        if (SFXInstance != null && SFXInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        SFXInstance = this;

        DontDestroyOnLoad(this);
    }


    public void playGunshot() {
        SFXInstance.ads.PlayOneShot(gunShot); 
    }
    public void playReloading() {
        SFXInstance.ads.PlayOneShot(reloadGun);
    }
    public void playRobotShoot()
    {
        SFXInstance.ads.PlayOneShot(RobotShoot);
    }
    public void playRobotDead()
    {
        SFXInstance.ads.PlayOneShot(RobotDead);
    }
    public void playGameOver()
    {
        SFXInstance.ads.PlayOneShot(GameOver);
    }
}
