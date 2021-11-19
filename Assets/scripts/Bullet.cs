using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// bullet behaviour script
/// </summary>
public class Bullet : MonoBehaviour
{
    // bullet firing force
    const int firingForce = 10;
    
    // bullet life parameters
    const float BulletLife = 2f;
    Timer deathTimer;

    /// <summary>
    /// direction in which to fire the bullet
    /// </summary>
    /// <param name="direction"></param>
    public void ApplyForce(Vector2 direction)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(direction * firingForce, ForceMode2D.Impulse);
    }

    // Start is called before the first frame update
    void Start()
    {
        deathTimer = gameObject.AddComponent<Timer>();
        deathTimer.Duration = BulletLife;
        deathTimer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (deathTimer.Finished)
        {
            Destroy(gameObject);
        }
    }
}
