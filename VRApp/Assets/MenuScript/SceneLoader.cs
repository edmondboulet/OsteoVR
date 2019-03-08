/* Code Writen by Edmond BOULET-GILLY, March 2019
 * Contact : edmond.bouletgilly@gmail.com
 * License Open Source, feel free to share and modify
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* This class load a scene
 * Scene is called by her name
 */
public class SceneLoader : MonoBehaviour
{
    public string NextScene;
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene(NextScene);
    }
}
