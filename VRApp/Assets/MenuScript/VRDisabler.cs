/* Code Writen by Edmond BOULET-GILLY, March 2019
 * Contact : edmond.bouletgilly@gmail.com
 * License Open Source, feel free to share and modify
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

/* This Class is reponsible for Disabling VR and switching in portrait mode
 */
public class VRDisabler : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(DeactivatorVR("none"));
    }

    public IEnumerator DeactivatorVR(string v)
    {
        XRSettings.LoadDeviceByName(v);
        yield return null;
        XRSettings.enabled = false;
        Screen.orientation = ScreenOrientation.Portrait;
    }
}