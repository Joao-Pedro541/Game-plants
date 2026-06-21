using UnityEngine;

public class bulletControl : MonoBehaviour
{
    public float damage = 25f;
    public float lifeTime = 3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            print("Bullet hit an enemy.");
            collision.GetComponent<enemyControl>().takeDamage(damage);
            Destroy(gameObject);
        }
    }
}
