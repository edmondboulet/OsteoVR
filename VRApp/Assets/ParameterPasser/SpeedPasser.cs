/* Code Writen by Edmond BOULET-GILLY, March 2019
 * Contact : edmond.bouletgilly@gmail.com
 * License Open Source, feel free to share and modify
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* This class is resposible for wirting the speed parameter as PlayerPref
 */
public class SpeedPasser : MonoBehaviour
{
    public Text disp;
    public float Speed;

    /* Initiate with default value
     */
    void Start()
    {
        Speed = 5f;
        disp.text = (Speed * 5.6).ToString();
    }

    /* Write the parameter when object is disable
    */
    void OnDisable()
    {
        PlayerPrefs.SetFloat("Speed", Speed/10);
    }

    /* Update the value when function is called
    */
    public void UpdateValue(float newValue)
    {
        Speed = newValue;
        disp.text = (Speed*5.6).ToString();
    }
}
