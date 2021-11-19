using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// asteroid behaviour
/// </summary>
public class Asteroid : MonoBehaviour
{
    [SerializeField]
    Sprite Square;
    [SerializeField]
    Sprite Triangle;
    [SerializeField]
    Sprite Circle;

    //random inpulse force constants
    const float MinImpulseForce = 3f;
    const float MaxImpulseForce = 4f;

    // Start is called before the first frame update
    void Start()
    {
        switch (Random.Range(0, 2))
        {
            case 0:
                gameObject.GetComponent<SpriteRenderer>().sprite = Square;
                break;
            case 1:
                gameObject.GetComponent<SpriteRenderer>().sprite = Triangle;
                break;
            case 2:
                gameObject.GetComponent<SpriteRenderer>().sprite = Circle;
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// random impulse force
    /// </summary>
    /// <param name="angle"></param>
    public void StartMoving(float angle)
    {
        Vector2 moveDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
        GetComponent<Rigidbody2D>().AddForce(moveDirection * magnitude, ForceMode2D.Impulse);
    }

    /// <summary>
    /// sets angle constraints for the Direction properties
    /// </summary>
    /// <param name="direction"></param>
    /// <param name="location"></param>
    public void Initialize(Direction direction, Vector3 location)
    {
        float angle = Random.Range(0, 30 * Mathf.Deg2Rad);
        switch (direction)
        {
            case Direction.Right:
                angle -= 15 * Mathf.Deg2Rad;
                break;
            case Direction.Up:
                angle += 75 * Mathf.Deg2Rad;
                break;
            case Direction.Left:
                angle += 165 * Mathf.Deg2Rad;
                break;
            case Direction.Down:
                angle += 255 * Mathf.Deg2Rad;
                break;
            default:
                break;
        }
        gameObject.transform.position = location;
        StartMoving(angle);

    }

    /// <summary>
    /// destroy the Asteroid if it collides with a Bullet
    /// </summary>
    /// <param name="collision"></param>
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            AudioManager.Play(AudioClipName.AsteroidHit);
            // destroy bullet
            Destroy(collision.gameObject);
            if (gameObject.transform.localScale.x >= 0.5)
            {
                Vector3 newSize = new Vector3();
                newSize = gameObject.transform.localScale;
                newSize.x /= 2;
                newSize.y /= 2;
                gameObject.transform.localScale = newSize;
                gameObject.GetComponent<CircleCollider2D>().radius /= 2;
                // instantiate and move 2 smaller pieces
                GameObject piece1 = Instantiate<GameObject>(gameObject);
                piece1.GetComponent<Asteroid>().StartMoving(Random.Range(0, 2 * Mathf.PI));
                GameObject piece2 = Instantiate<GameObject>(gameObject);
                piece2.GetComponent<Asteroid>().StartMoving(Random.Range(0, 2 * Mathf.PI));
            }
            // destroy big asteroid
            Destroy(gameObject);
        }
    }
}
