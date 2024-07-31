using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public GameObject optionsMenu;

    
    public void JugarYa()
    {
        
        SceneManager.LoadScene("map-1");
    }

    public void Options()
    {
        optionsMenu.SetActive(true); 
    }

    public void Salir()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}