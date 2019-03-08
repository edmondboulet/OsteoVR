/* Code Writen by Edmond BOULET-GILLY, March 2019
 * Contact : edmond.bouletgilly@gmail.com
 * License Open Source, feel free to share and modify
 */
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

/* This class is responsible for enabling the VR
 */
public class VREnabler : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(ActivatorVR("cardboard"));
    }

    public IEnumerator ActivatorVR(string v)
    {
        XRSettings.LoadDeviceByName(v);
        yield return null;
        XRSettings.enabled = true;
    }
}
