using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey("1"))
        {
            SceneManager.LoadScene("Fibonacci");
        }
        else if (Input.GetKey("2"))
        {
            SceneManager.LoadScene("LinkedList");
        }
        else if (Input.GetKey("3"))
        {
            //SceneManager.LoadScene("");
        }
        else if (Input.GetKey("4"))
        {
            //SceneManager.LoadScene("");
        }
        else if (Input.GetKey ("5")) {
			SceneManager.LoadScene ("Arcanoid");			
		} else if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
	}
}
