﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusic : MonoBehaviour {

    public AudioSource m_audioSource;

	void Start () {
        m_audioSource = GetComponent<AudioSource>();
        m_audioSource.Play();
	}

    private void OnDestroy()
    {
        m_audioSource.Stop();
    }

    void Update () {
		
	}
}
