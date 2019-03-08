/* Code Writen by Edmond BOULET-GILLY, March 2019
 * Contact : edmond.bouletgilly@gmail.com
 * License Open Source, feel free to share and modify
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* This class is resposible for wirting the angle max parameter as PlayerPref
 */
public class AngleMaxPasser : MonoBehaviour
{
    public Text disp;
    public float angleMax;

    /* Initiate with default value
    */
    void Start()
    {
        angleMax = 60;
        disp.text = angleMax.ToString();
    }

    /* Write the parameter when object is disable
    */
    void OnDisable()
    {
        PlayerPrefs.SetFloat("AngleMax", angleMax * Mathf.Deg2Rad);
    }

    /* Update the value when function is called
    */
    public void UpdateValue(float newValue)
    {
        angleMax = newValue;
        disp.text = angleMax.ToString();
    }
}
