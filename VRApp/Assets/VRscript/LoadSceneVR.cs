/* Code Writen by Edmond BOULET-GILLY, March 2019
 * Contact : edmond.bouletgilly@gmail.com
 * License Open Source, feel free to share and modify
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* This class is responsible for loading a scene by looking at it for countMax secodnes
 */
public class LoadSceneVR : MonoBehaviour
{
    public TextMesh CD;
    public int countMax = 3;
    public bool startCount = false;
    public int currentCount = 3;
    public float ts;
    public MoveTarget moveTarget;
    public string NextScene;

    /* Execute the countdown and call scene loader when completed
     */
    void Update()
    {
        if (startCount == true)
            if (currentCount == 3)
            {
                CD.text = currentCount.ToString();
                currentCount--;
                ts = Time.time + 1f;
            }
            else if (ts < Time.time)
            {
                if (currentCount == 0)
                {
                    Reset();
                    SceneManager.LoadScene(NextScene);
                }
                else
                {
                    CD.text = currentCount.ToString();
                    currentCount--;
                    ts = Time.time + 1f;
                }
            }
    }

    /*
    * Reset The parameters of the test and the target Postion
    */
    public void Reset()
    {
        startCount = false;
        CD.text = "";
        currentCount = 3;
    }

    /* Start the CountDown
     */
    public void StartCD()
    {
        startCount = true;
    }

    /* Stop the Count Down
     */
    public void Stop()
    {
        Reset();
    }
}
