using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fireControlSystem : MonoBehaviour
{
    public Weapons currentWeapon;
    public GameObject HEshell;
    public GameObject thisPlayer;
    public string faceTowards;
    public float launchDegree;//really degree
    private float launchRad;//radians
    public float launchForce;
    public float maxLaunchForce = 400;
    public AudioSource FireSound;

    //belongs to which player
    public string whose;

    //UI associated
    public Image ForceBar;
    public Text LaunchDegreeShown;


    // Start is called before the first frame update
    void Start()
    {
        launchDegree = 45;
    }

    // Update is called once per frame
    void Update()
    {
        
        int shownDegree = (int)launchDegree;
        LaunchDegreeShown.text = "Aiming Degree:  "+shownDegree.ToString();
        launchRad = launchDegree / 180 * Mathf.PI;
        //be attention!!! MAthf cos sin uses Rad instead of degree
        if (launchDegree < 5)
        {
            launchDegree = 5;
        }
        if (launchDegree > 85)
        {
            launchDegree = 85;
        }
        

        //elevation mechnism
        if (Input.GetAxis("Vertical"+this.thisPlayer.name)>0 ) 
        {
            launchDegree = launchDegree + 0.3f;
            
            //weapon aim up
        }
        if (Input.GetAxis("Vertical" + this.thisPlayer.name) < 0)
        {
            launchDegree = launchDegree - 0.3f;
            //weapon aim down
        }
        //end elevation mechnism


        if (thisPlayer.name == "Player1")
        {
            if (Input.GetKey(KeyCode.Space) == true)
            {
                if (launchForce >= maxLaunchForce)
                {
                    launchForce = maxLaunchForce;
                    ForceBar.fillAmount = 1;
                }
                else
                {
                    launchForce = launchForce + 100 * Time.deltaTime;
                    ForceBar.fillAmount = launchForce / maxLaunchForce;
                }

                //add force for your shell
            }
            if (Input.GetKeyUp(KeyCode.Space) == true)
            {
                float x = Mathf.Cos(launchRad) * launchForce;
                float y = Mathf.Sin(launchRad) * launchForce;
                if (this.gameObject.GetComponent<playerController>().faceRight == false)
                {
                    x = -x;
                }
                Vector2 fireVector = new Vector2(x, y);
                //initial force and where the shell goes


                x = thisPlayer.transform.position.x;
                y = thisPlayer.transform.position.y+0.3f;
                Vector2 firePoint = new Vector2(x, y);
                //calculate the fire point

                Quaternion beforeFire = new Quaternion(0, 0, 0, 0);
                //rotate the shell
                switch (currentWeapon)
                {
                    case Weapons.HE:
                        //instantiate a shell and let it flt
                        GameObject _HE = Instantiate(HEshell, firePoint, beforeFire);
                        _HE.GetComponent<Rigidbody2D>().AddForce(fireVector);

                        //Sound of firing

                        //clear ForceBar
                        ForceBar.fillAmount = 0;

                        //after shell goes out
                        launchForce = 0;
                        break;
                    case Weapons.AP:
                        break;
                    case Weapons.nuclearBomb:
                        break;
                    default:
                        break;
                }
                //Instantiate(HEshell,firePoint,beforeFire);
                //TODO fire!!!
            }
        }

        if (thisPlayer.name == "Player2")
        {
            if (Input.GetKey(KeyCode.Backspace) == true)
                {
                    if (launchForce >= maxLaunchForce)
                    {
                        launchForce = maxLaunchForce;
                        ForceBar.fillAmount = 1;
                    }
                    else
                    {
                        launchForce = launchForce + 100 * Time.deltaTime;
                        ForceBar.fillAmount = launchForce / maxLaunchForce;
                    }

                    //add force for your shell
                }
            if (Input.GetKeyUp(KeyCode.Backspace) == true)
                {
                    float x = Mathf.Cos(launchRad) * launchForce;
                    float y = Mathf.Sin(launchRad) * launchForce;
                    if (this.gameObject.GetComponent<playerController>().faceRight == false)
                    {
                        x = -x;
                    }
                    Vector2 fireVector = new Vector2(x, y);
                    //initial force and where the shell goes

                    
                    x = thisPlayer.transform.position.x;
                    y = thisPlayer.transform.position.y+0.3f;
                    Vector2 firePoint = new Vector2(x, y);
                    //calculate the fire point

                    Quaternion beforeFire = new Quaternion(0, 0, 0, 0);
                    //rotate the shell
                    switch (currentWeapon)
                    {
                        case Weapons.HE:
                            //instantiate a shell and let it flt
                            GameObject _HE = Instantiate(HEshell, firePoint, beforeFire);
                            _HE.GetComponent<Rigidbody2D>().AddForce(fireVector);

                            //Sound of firing

                            //clear ForceBar
                            ForceBar.fillAmount = 0;

                            //after shell goes out
                            launchForce = 0;
                            break;
                        case Weapons.AP:
                            break;
                        case Weapons.nuclearBomb:
                            break;
                        default:
                            break;
                    }
                    //Instantiate(HEshell,firePoint,beforeFire);
                    //TODO fire!!!
                }

            }
        
        

    }




    public enum Weapons
    {
        HE, AP, nuclearBomb
    }
}
