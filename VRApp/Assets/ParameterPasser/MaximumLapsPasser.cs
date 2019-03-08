/* Code Writen by Edmond BOULET-GILLY, March 2019
 * Contact : edmond.bouletgilly@gmail.com
 * License Open Source, feel free to share and modify
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* This class is resposible for wirting the maximum laps parameter as PlayerPref
 */
public class MaximumLapsPasser : MonoBehaviour
{
    public Text disp;
    public int maximumLaps;

    /* Initiate with default value
    */
    void Start()
    {
        maximumLaps = 4;
        disp.text = maximumLaps.ToString();
    }

    /* Write the parameter when object is disable
    */
    void OnDisable()
    {
        PlayerPrefs.SetInt("MaximumLaps", maximumLaps);
    }

    /* Update the value when function is called
    */
    public void UpdateValue(float newValue)
    {
        maximumLaps = Mathf.RoundToInt(newValue);
        disp.text = maximumLaps.ToString();
    }
}
