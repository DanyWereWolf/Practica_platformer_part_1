using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SceneLoader sceneLoader;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void mainMenuOnCklick()
    {
        sceneLoader.MainMenu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
