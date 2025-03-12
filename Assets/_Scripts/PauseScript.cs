using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{
    public Canvas pauseCanvas;
    public Canvas hudCanvas;
    bool canEsc;

    private void Start()
    {
        canEsc = true;
        pauseCanvas.enabled = false;
        hudCanvas.enabled = true;
    }

    // Update is called once per frame
    void Update()
    { // order matters
        if (Input.GetKeyUp(KeyCode.P) && !pauseCanvas.enabled) { Pause(); }
        if (Input.GetKeyDown(KeyCode.O) && pauseCanvas.enabled) { ExitPause(); }

    }

    public void Pause()
    {
        if (canEsc)
        {
            Debug.Log("esc");

            pauseCanvas.enabled = true;
            hudCanvas.enabled = false;
        }

    }

    public void ExitPause()
    {
        Debug.Log("Esc esc");
        pauseCanvas.enabled = false;
        Time.timeScale = 1;
        hudCanvas.enabled = true;

    }

    public void ExitGame() 
    {
        Application.Quit(); 
    }

}
