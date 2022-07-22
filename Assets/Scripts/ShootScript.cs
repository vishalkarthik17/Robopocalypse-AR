using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using TMPro;


[RequireComponent(typeof(ARRaycastManager))]

public class ShootScript : MonoBehaviour
{
    public int maxAmmo ;
    public int currentAmmo;
    public int remainingAmmo;
    public float reloadTime = 1f;
    public bool isReloading = false;
    public Camera MainCam;
    public TextMeshProUGUI ammoText;
    
    public Animator animator;
    public GameObject gameBtnManager;
    public bool outOfBullets = false;


    private ARRaycastManager arRaycastManager;
    static List<ARRaycastHit> hitlist = new List<ARRaycastHit>();

    public ParticleSystem muzzleFlash;
    public GameObject impactFX;
    
    void Awake()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();


    }
    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = maxAmmo;
        remainingAmmo -= maxAmmo;

    }

    // Update is called once per frame
    void Update()
    {
        

        ammoText.SetText(currentAmmo.ToString() + "/" + remainingAmmo.ToString()) ;
        if (isReloading) {
            ammoText.SetText("Reloading...");
            return;
        }
        if (currentAmmo <= 0)
        {
            currentAmmo = 0;
            if (remainingAmmo <= 0)
            {
                remainingAmmo = 0;
                outOfBullets = true;
            }
            if(!(currentAmmo<=0 && remainingAmmo<=0))
            StartCoroutine(ReloadGun());
            return;
        }


    }

    IEnumerator ReloadGun () {
        isReloading = true;
        animator.SetBool("Reloading", true);
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        remainingAmmo = remainingAmmo - maxAmmo;
        if (currentAmmo==7 && remainingAmmo < 0) {
            remainingAmmo = 0;
            currentAmmo = 0;
        }
        animator.SetBool("Reloading", false);
        isReloading = false;
        
    }
    public void shootBullet() {
        if (!isReloading && !outOfBullets) 
        {
            muzzleFlash.Play();
            SoundControllerScript.SFXInstance.playGunshot();

            currentAmmo = currentAmmo - 1;
            

            var ray = MainCam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            RaycastHit hitObj;
            if (Physics.Raycast(ray, out hitObj))
            {
                var selection = hitObj.transform;
                
                if (selection.CompareTag("EnemyHead"))
                {
                    //Play particle animation of enemy getting destroyed.
                    AttackPlayer ap= selection.parent.gameObject.GetComponent<AttackPlayer>();
                    int curHealth = ap.health;
                    curHealth -= 20;
                    ap.setHealth(curHealth);

                    Instantiate(impactFX, hitObj.point, Quaternion.LookRotation(hitObj.normal));
                    if (curHealth <= 0)
                    {
                        gameBtnManager.GetComponent<GameButtonManagerScript>().killOneEnemy();
                        SoundControllerScript.SFXInstance.playRobotDead();
                        Destroy(selection.parent.gameObject);
                    }
                        
            

                }
                if (selection.CompareTag("EnemyBody"))
                {
                    AttackPlayer ap = selection.gameObject.GetComponent<AttackPlayer>();
                    int curHealth = ap.health;
                    curHealth -= 10;
                    ap.setHealth(curHealth);
                    Instantiate(impactFX, hitObj.point, Quaternion.LookRotation(hitObj.normal));
                    if (curHealth <= 0)
                    {
                        gameBtnManager.GetComponent<GameButtonManagerScript>().killOneEnemy();
                        SoundControllerScript.SFXInstance.playRobotDead();
                        Destroy(selection.gameObject);
                    }
                }

                
            }
        }
        else
        {
            SoundControllerScript.SFXInstance.playReloading();
        }
        

    }
}
