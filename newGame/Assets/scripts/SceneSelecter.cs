using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Selects the scene we want to play 
public class SceneSelecter : MonoBehaviour
{
    
    public static void Level1(){
        SceneManager.LoadScene("Level1");
    }
    public static void Level2()
    {
        SceneManager.LoadScene("Level2");
    }
    public static void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
    
}
