using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pdebut : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void EnterJam()
    {
        SceneManager.LoadScene("main");
    }

    public void QuitJam()
    {
        Application.Quit();
    }
}
