using UnityEngine;
using System.Collections;

public class enemyMove : MonoBehaviour {
	public float speed = 2f;
	public Transform shotPrefab;
	public float shootingRate = 1f;
	private float shootCooldown;

	float direction = 1f;

	// Use this for initialization
	void Start () {
		shootCooldown = 0f;

		transform.localScale = new Vector3 (direction*0.5f, 0.5f, 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
		rigidbody2D.velocity = new Vector2 ( speed * direction, rigidbody2D.velocity.y);
		if (shootCooldown > 0)
		{
			shootCooldown -= Time.deltaTime;
		}
		Attack (true);
		//transform.localScale.Set(direction*0.5f, transform.localScale.y, transform.localScale.z);
	}

	public void Attack(bool isEnemy)
	{
		if (CanAttack)
		{
			shootCooldown = shootingRate;
			
			// Create a new shot
			var shotTransform = Instantiate(shotPrefab) as Transform;
			
			// Assign position
			shotTransform.position = transform.position;
			
			// The is enemy property
			SingleShot shot = shotTransform.gameObject.GetComponent<SingleShot>();
			if (shot != null)
			{
				shot.isEnemyShot = isEnemy;
				//shot.direction = 1f; // towards in 2D space is the right of the sprite
			}
			
		}
	}

	public bool CanAttack
	{
		get
		{
			return shootCooldown <= 0f;
		}
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "tower1") {
			direction = 0;//-1f * direction;
			//transform.localScale = new Vector3 (direction*0.5f, 0.5f, 0.5f);
		}
	}
}
