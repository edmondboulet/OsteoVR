/* Code Writen by Edmond BOULET-GILLY, March 2019
 * Contact : edmond.bouletgilly@gmail.com
 * License Open Source, feel free to share and modify
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using System;


/* This Class is responsible for Capturing head movement and write it in local file
 * It requires access to the MoveTarget Script
 * And supposes and some PlayerPref are defines like YearBirth ( optionnal )
 * The file Writen end up in the local application directory ( depends on the platform )
 */
public class MoveCapture : MonoBehaviour
{
    public GameObject playerObject;
    public Vector3 playerRot;
    public string path;
    public string filename;
    public bool captureData;
    public MoveTarget moveTarget;

    void Start()
    {
        captureData = false;
        // Initialization has been moved to moveTarget.Reset() to ensure right order of spawn
    }

    /* Update the of the player Rotation
     * And  wirte it if required
     */
    void Update()
    {
        playerRot = playerObject.transform.rotation.eulerAngles;
        if (captureData == true)
        {
            WriteRot();
        }
    }

    public void WriteRot()
    {
        float yaw = playerRot[1];
        if (yaw > 180)
        {
            yaw = yaw - 360;
        }
        float pitch = playerRot[0];
        if (pitch > 180)
        {
            pitch = pitch - 360;
        }
        float roll = playerRot[2];
        if (roll > 180)
        {
            roll = roll - 360;
        }
        System.IO.File.AppendAllText(path + filename, yaw.ToString("0.00") + " " + pitch.ToString("0.00") + " " + roll.ToString("0.00") + "\n");
    }

    public void Reset()
    {
        path = Application.persistentDataPath + "/";
        string date = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss").Replace("/", "-").Replace(" ","_").Replace(":", "_");
        filename = date + ".txt";
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        int now = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
        string age;
        if(PlayerPrefs.GetString("YearBirth") != "" && PlayerPrefs.GetString("MonthBirth") != "" && PlayerPrefs.GetString("DayBirth") != "")
        {
            int dob = CheckBDateFormat();
            int ageInt = (now - dob) / 10000;
            age = ageInt.ToString();
        }
        else
        {
            age = null;
        }

        string HashID = PlayerPrefs.GetString("FirstName") + PlayerPrefs.GetString("LastName");
        HashID += PlayerPrefs.GetString("DayBirth") + PlayerPrefs.GetString("MonthBirth") + PlayerPrefs.GetString("YearBirth");

        System.IO.File.WriteAllText(path + filename, "== PARAMETERS ==\n");
        System.IO.File.AppendAllText(path + filename, "movement:Lacet\n");
        System.IO.File.AppendAllText(path + filename, "angle:"+ moveTarget.AngleMax * Mathf.Rad2Deg +"\n");
        System.IO.File.AppendAllText(path + filename, "speed:" + moveTarget.Speed*56 + "\n");
        System.IO.File.AppendAllText(path + filename, "nb_return:" + moveTarget.MaximumLaps + "\n");
        System.IO.File.AppendAllText(path + filename, "wait_time:" + moveTarget.PauseTime + "\n");
        System.IO.File.AppendAllText(path + filename, "Hash_ID:" + HashUserData(HashID) + "\n");
        System.IO.File.AppendAllText(path + filename, "Age:" + age + "\n");
        System.IO.File.AppendAllText(path + filename, "Gender:" + PlayerPrefs.GetString("Gender") + "\n");
        System.IO.File.AppendAllText(path + filename, "Pathology:" + PlayerPrefs.GetString("Phatology") + "\n");
        System.IO.File.AppendAllText(path + filename, "Other:\n");


        System.IO.File.AppendAllText(path + filename, "== COMMENTS ==\n");
        System.IO.File.AppendAllText(path + filename, "\n");
        System.IO.File.AppendAllText(path + filename, "== VALUES ==\n");
    }

    /* Make sure the date was Wruttent as DD and MM
     * and returns an int as YYYYMMDD
     */
    private int CheckBDateFormat()
    {
        string day;
        string month;
        if (PlayerPrefs.GetString("DayBirth").Length == 1)
        {
            day = "0" + PlayerPrefs.GetString("DayBirth");
        } else
        {
            day = PlayerPrefs.GetString("DayBirth");
        }
        if (PlayerPrefs.GetString("MonthBirth").Length == 1)
        {
            month = "0" + PlayerPrefs.GetString("MonthBirth");
        }
        else
        {
            month = PlayerPrefs.GetString("MonthBirth");
        }
        return int.Parse(PlayerPrefs.GetString("YearBirth") + month + day);
    }

    /* Starts the capture
     */
    public void StartCapture()
    {
        captureData = true;
    }

    /* End the capture when it was completed
     */
    public void EndCapture()
    {
        captureData = false;
        Reset();
    }

    /* Interrupt the Capture ( but keeps the file )
     */
    public void InterruptCapture()
    {
        System.IO.File.Move(path + filename, path + "I "+ filename);
        captureData = false;
        Reset();
    }

    /* Cancel th Capture ( and delete the file )
     */
    public void CancelCapture()
    {
        System.IO.File.Delete(path + filename);
        captureData = false;
        Reset();
    }

    /* Pause the Capture
     */
    public void PauseCapture()
    {
        captureData = false;
    }

    /* If the object is destroyed Delete the current file
     */
    public void OnDestroy()
    {
        System.IO.File.Delete(path + filename);
    }

    /* Hash User Data with name, forname and age
     */
    public string HashUserData(string text)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(text);
        SHA256Managed hashstring = new SHA256Managed();
        byte[] hash = hashstring.ComputeHash(bytes);
        string hashString = string.Empty;
        foreach (byte x in hash)
        {
            hashString += String.Format("{0:x2}", x);
        }
        return hashString;
    }
}
