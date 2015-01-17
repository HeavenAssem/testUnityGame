using UnityEngine;

public class WeaponScript : MonoBehaviour
{
	public Transform shotPrefab;

	public float shootingRate = 0.25f;
		
	private float shootCooldown;
	
	void Start()
	{
		shootCooldown = 0f;
	}
	
	void Update()
	{
		if (shootCooldown > 0)
		{
			shootCooldown -= Time.deltaTime;
		}
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
				//shot.direction = this.transform.right; // towards in 2D space is the right of the sprite
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
}
