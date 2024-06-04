using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;

public class Buttons : MonoBehaviour
{ 
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayButtonOnClick()
    {
       SceneManager.LoadScene("ChangeCharacter");
    }
    public void ChangeSkeletonButtonOnClick()
    {
        SceneManager.LoadScene("House");
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Creator()
    {
        SceneManager.LoadScene("Creators");
    }
    public void BackToMenuButtonOnClick()
    {
        SceneManager.LoadScene("Menu");
    }
    

}
