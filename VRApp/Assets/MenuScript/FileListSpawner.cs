/* Code Writen by Edmond BOULET-GILLY, March 2019
 * Contact : edmond.bouletgilly@gmail.com
 * License Open Source, feel free to share and modify
 */
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

/* This class is reponsible for creating a new item in the File Menu
 * For each file in the Applicaion Directory
 */
public class FileListSpawner : MonoBehaviour
{
    public DirectoryInfo dataDir;
    public string path;
    public FileInfo[] fileinfo;
    // Start is called before the first frame update
    void Start()
    {
        path = Application.persistentDataPath;
        dataDir = new DirectoryInfo(path);
        fileinfo = dataDir.GetFiles();
        foreach (FileInfo f in fileinfo)
        {
            GameObject dataItem = Instantiate(Resources.Load("DataItem", typeof(GameObject))) as GameObject;
            dataItem.transform.SetParent(transform);
            dataItem.transform.localScale = new Vector3(1F, 1F, 1F);
            DataTool dataTool = dataItem.GetComponent(typeof(DataTool)) as DataTool;
            dataTool.file = f;
            dataTool.Initiate();
        }
    }
}
