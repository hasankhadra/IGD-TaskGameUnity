using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class backToMenu : MonoBehaviour
{
    
    // If the player hits escape, he goes back to the main menu
    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            SceneManager.LoadScene("Menu");
        }
    }
    
}
