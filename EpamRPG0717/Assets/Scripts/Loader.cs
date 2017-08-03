using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour {

    [SerializeField]
    private GameObject gameManager;

	// Use this for initialization
	void Awake  () {
		if (GameManager.Instance == null) {
            Instantiate(gameManager);
        }
	}
	
}
