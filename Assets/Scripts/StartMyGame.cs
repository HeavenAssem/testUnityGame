﻿using UnityEngine;
using System.Collections;

public class StartMyGame : MonoBehaviour {
	
	public void LoadScene(int level) {
		Application.LoadLevel(level);
	}
}
