using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_Button : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] GameObject confirmation;
    [SerializeField] GameObject confirmationToMenu;
    private bool isActive = false;
    private bool onConfirmation = false;
    private bool onConfirmationToMenu = false;
    
    public void changeState()
    {
        isActive = !isActive;
        hideConfirmation();
        hideConfirmationToMenu();
    }

    public void showConfirmation()
    {
        confirmation.SetActive(true);
        isActive = false;
        onConfirmation = true;
    }
    public void hideConfirmation()
    {
        confirmation.SetActive(false);
        onConfirmation = false;
    }

    public void showConfirmationToMenu()
    {
        confirmationToMenu.SetActive(true);
        isActive = false;
        onConfirmationToMenu = true;
    }
        
    public void hideConfirmationToMenu()
    {
        confirmationToMenu.SetActive(false);
        onConfirmationToMenu = false;
    }

    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Escape))
        {
           changeState();
           hideConfirmation();
           hideConfirmationToMenu();
        }


       if(isActive == true || onConfirmation == true || onConfirmationToMenu == true)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
       menu.SetActive(isActive);
    }

}
