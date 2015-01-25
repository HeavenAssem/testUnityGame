using UnityEngine;
using System.Collections;

public class BaseUnit : MonoBehaviour {
    private int HealthPoints;
    private int ArmorPoints;

	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	virtual void Update () {
		if (HealthPoints <= 0) {
			Destroy(gameObject);
		}
	}
}
