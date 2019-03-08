/* Code Writen by Edmond BOULET-GILLY, March 2019
 * Contact : edmond.bouletgilly@gmail.com
 * License Open Source, feel free to share and modify
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* This class is responsible to pass string argument between scene
 */
public class StringScenePasser : MonoBehaviour
{
    public string value;
    public string parameteToPass;

    void Start()
    {
        value = null;
    }

    /* Write the parameter when object is disable
     */
    void OnDisable()
    {
        PlayerPrefs.SetString(parameteToPass, value);
    }

    /* Update the value when function is called
     */
    public void UpdateValue(string newValue)
    {
        value = newValue;
    }
}
