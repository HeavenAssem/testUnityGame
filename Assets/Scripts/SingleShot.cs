using UnityEngine;

public class SingleShot : MonoBehaviour
{

	public int damage = 1;

	public bool isEnemyShot = false;

	public float speed = 4f;
	public float direction = 1f;
	
	void Start()
	{
		// 2 - Limited time to live to avoid any leak
		Destroy(gameObject, 20); // 20sec
	}

	void Update () {
		rigidbody2D.velocity = new Vector2 ( speed * direction, rigidbody2D.velocity.y);
		//transform.localScale.Set(direction*0.5f, transform.localScale.y, transform.localScale.z);
	}

}
