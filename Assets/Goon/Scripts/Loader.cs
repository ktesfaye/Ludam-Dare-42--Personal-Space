﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour {

    public GameObject gameManager;

	// Use this for initialization
	void Awake ()
    {
        if (GameManager3.instance == null)
            Instantiate(gameManager);
	}

}
