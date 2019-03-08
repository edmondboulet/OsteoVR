/* Code Writen by Edmond BOULET-GILLY, March 2019
 * Contact : edmond.bouletgilly@gmail.com
 * License Open Source, feel free to share and modify
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

/* This call is responsible for deleting and sending data from the File Menu
 */
public class DataTool : MonoBehaviour
{
    public string nameFile;
    public Text disp; 
    public string path;
    public FileInfo[] fileinfo;
    public FileInfo file;

    /* Initiate the nameFile Parameter
     *  and display the name as text
     */
    public void Initiate()
    {
        nameFile = file.Name.ToString();
        disp.text = nameFile.Replace("_", " ").Replace(".txt", "");
    }

    /* Send he data by creating a new email
     */
    public void SendData()
    {
        string text ="";
        string line;
        StreamReader streamReader =  file.OpenText();
        while ((line = streamReader.ReadLine()) != null)
        {
            text += line;
            text += "%0D%0A";
        }
        Application.OpenURL("mailto:?subject="+ "Cervical Data : " + file.Name +"&body=" + text );
    }

    /* Deletes the File
     */
    public void DeleteData()
    {
        file.Delete();
        Destroy(gameObject);
    }
}
