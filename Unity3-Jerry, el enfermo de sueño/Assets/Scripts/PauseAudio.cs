﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseAudio : MonoBehaviour {

	// Use this for initialization
	void Start () {
		BGSoundScript.Instance.gameObject.GetComponent<AudioSource> ().Pause ();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
