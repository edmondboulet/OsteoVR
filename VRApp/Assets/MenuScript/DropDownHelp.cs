/* Code Writen by Edmond BOULET-GILLY, March 2019
 * Contact : edmond.bouletgilly@gmail.com
 * License Open Source, feel free to share and modify
 */
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/* This class is reponsible for traslating the dropdown menu parameter selected as string
 */
public class DropDownHelp : MonoBehaviour
{
    public TMP_Dropdown dropDown;
    public StringScenePasser stringScenePasser;

    public void PassToPasser( int value)
    {
        stringScenePasser.UpdateValue(dropDown.options[dropDown.value].text);
    }
}
