﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class aud : MonoBehaviour
{
    // Start is called before the first frame update
    
    
    
    void Start()
    {
        Invoke("LoadFirstScene", 3f);

        
        
    }
    void LoadFirstScene()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene(1);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
