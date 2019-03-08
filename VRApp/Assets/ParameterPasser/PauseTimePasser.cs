/* Code Writen by Edmond BOULET-GILLY, March 2019
 * Contact : edmond.bouletgilly@gmail.com
 * License Open Source, feel free to share and modify
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* This class is resposible for wirting the pause time parameter as PlayerPref
 */
public class PauseTimePasser : MonoBehaviour
{
    public Text disp;
    public float pauseTime;

    /* Initiate with default value
    */
    void Start()
    {
        pauseTime = 2f;
        disp.text = pauseTime.ToString();
    }

    /* Write the parameter when object is disable
    */
    void OnDisable()
    {
        PlayerPrefs.SetFloat("PauseTime", pauseTime);
    }

    /* Update the value when function is called
    */
    public void UpdateValue(float newValue)
    {
        pauseTime = newValue;
        disp.text = pauseTime.ToString();
    }
}
