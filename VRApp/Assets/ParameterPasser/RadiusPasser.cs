/* Code Writen by Edmond BOULET-GILLY, March 2019
 * Contact : edmond.bouletgilly@gmail.com
 * License Open Source, feel free to share and modify
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* This class is resposible for wirting the radius parameter as PlayerPref
 */
public class RadiusPasser : MonoBehaviour
{
    public Text disp;
    public float radius;

    /* Initiate with default value
    */
    void Start()
    {
        radius = 2f;
        disp.text = radius.ToString();
    }

    /* Write the parameter when object is disable
    */
    void OnDisable()
    {
        PlayerPrefs.SetFloat("Radius", radius);
    }

    /* Update the value when function is called
    */
    public void UpdateValue(float newValue)
    {
        radius = newValue;
        disp.text = radius.ToString();
    }
}
