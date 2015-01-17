using UnityEngine;
using System.Collections;

public class towerBehaviour : MonoBehaviour {
	public int hp = 3;

	public void Damage(int damageCount)
	{
		hp -= damageCount;
		
		if (hp <= 0)
		{
			// Dead!
			Destroy(gameObject);
		}
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		SingleShot shot = otherCollider.gameObject.GetComponent<SingleShot>();
		if (shot != null)
		{
			Damage(shot.damage);

			// Destroy the shot
			Destroy(shot.gameObject);
		}
	}

}
