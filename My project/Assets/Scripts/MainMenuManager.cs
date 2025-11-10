using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Accessibility;

public class MainMenuManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject mainMenu;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwapToSettings()
    {
        pauseMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void SwapToMainMenu()
    {
        pauseMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
}
