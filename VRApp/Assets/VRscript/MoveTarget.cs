/* Code Writen by Edmond BOULET-GILLY, March 2019
 * Contact : edmond.bouletgilly@gmail.com
 * License Open Source, feel free to share and modify
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/* This class is responsible for taget movement
 * And supposes and some PlayerPref are defines like AngleMax ( optionnal )
 */
public class MoveTarget : MonoBehaviour
{

    public float AngleMax;
    public float Radius;
    public int VaAGauche;
    public float theta;
    public float Speed;
    public float debutPause;
    public float PauseTime;
    public int ancienneDir;
    public bool DoTest;
    public int currentlaps;
    public int MaximumLaps;
    public MoveCapture moveCapture;

    // Start is called before the first frame update
    void Start()
    {
        Reset();
        //initialize Capture asset
        moveCapture.Reset();
    }

    /* Perform when required
     */
    void Update()
    {
        if(DoTest == true)
        {
            PerformeTest();
        }
    }

    /* Move the target from left to right for the angle Anglemax for maximumlaps laps
     */
    public void PerformeTest()
    {
        if (Mathf.Abs(theta) > AngleMax && VaAGauche != 0)
        {
            theta = VaAGauche * AngleMax;
            ancienneDir = VaAGauche;
            VaAGauche = 0;
            debutPause = Time.time;

        }
        if (debutPause > 0 && Time.time - debutPause > PauseTime)
        {
            // Increments the number of laps
            currentlaps++;
            // Detects when test is over and capture should end
            if (currentlaps == MaximumLaps+1)
            {
                moveCapture.EndCapture();
                Reset();
            }
            debutPause = -1f;
            VaAGauche = -1 * ancienneDir;

        }
        // Detects when capture should start
        if (currentlaps >= 1)
        {
            moveCapture.StartCapture();
        }
        if (Time.time - debutPause < PauseTime)
        {
            moveCapture.PauseCapture();
        }
        // Computes new teta
        theta = theta + VaAGauche * Time.deltaTime * Speed;
        // Apllies transformation
        transform.position = new Vector3(Radius * Mathf.Cos(theta+ Mathf.PI/2), transform.position.y, -2f + Radius * Mathf.Sin(theta+ Mathf.PI/2));
    }

    /* Reset The parameters of the test and the target Postion
     */
    public void Reset()
    {
        //Variable Parameters
        if(PlayerPrefs.GetFloat("AngleMax") >= Mathf.PI/4 && PlayerPrefs.GetFloat("AngleMax") <= Mathf.PI/2)
        {
            AngleMax = PlayerPrefs.GetFloat("AngleMax");
        }
        else
        {
            AngleMax = Mathf.PI/3;
        }
        if (PlayerPrefs.GetFloat("Radius") >= 0.5 && PlayerPrefs.GetFloat("Radius") <= 4)
        {
            Radius = PlayerPrefs.GetFloat("Radius");
        }
        else
        {
            Radius = 2f;
        }
        if (PlayerPrefs.GetFloat("Speed") >= 0.5 && PlayerPrefs.GetFloat("Speed") <= 4)
        {
            Speed = PlayerPrefs.GetFloat("Speed");
        }
        else
        {
            Speed = 0.5f;
        }
        if (PlayerPrefs.GetInt("MaximumLaps") >= 2 && PlayerPrefs.GetInt("MaximumLaps") <= 8)
        {
            MaximumLaps = PlayerPrefs.GetInt("MaximumLaps");
        }
        else
        {
            MaximumLaps = 4;
        }
        if (PlayerPrefs.GetFloat("PauseTime") >= 1f && PlayerPrefs.GetFloat("PauseTime") <= 4f)
        {
            PauseTime = PlayerPrefs.GetFloat("PauseTime");
        }
        else
        {
            PauseTime = 2f;
        }
        // other Parameters
        theta = 0;
        VaAGauche = 1;
        debutPause = -1f;
        ancienneDir = 0;
        DoTest = false;
        currentlaps = 0;
        transform.position = new Vector3(Radius * Mathf.Cos(theta + Mathf.PI / 2), transform.position.y, -2f + Radius * Mathf.Sin(theta + Mathf.PI / 2));
    }

    /* Start the Test
     */
    public void StartTest()
    {
        DoTest = true;
    }

    /* Interrupt the Test after the beginning of the first lap
     * Cancels it if the function is called before
     */
    public void InterruptTest()
    {
        if ( currentlaps == 0)
        {
            moveCapture.CancelCapture();
        } else
        {
            moveCapture.InterruptCapture();
        }
        Reset();
    }
}
