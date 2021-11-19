using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// spawns asteroids
/// </summary>
public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject prefabAsteroid;

    // Start is called before the first frame update
    void Start()
    {
        GameObject asteroid = Instantiate<GameObject>(prefabAsteroid);
        float colliderRadius = asteroid.GetComponent<CircleCollider2D>().radius;
        Destroy(asteroid);

        GameObject astLeft = Instantiate<GameObject>(prefabAsteroid);
        Asteroid astscriptLeft = astLeft.GetComponent<Asteroid>();
        Vector3 spawnLeft = new Vector3(ScreenUtils.ScreenLeft - colliderRadius, 0);
        astscriptLeft.Initialize(Direction.Right, spawnLeft);
        astscriptLeft.GetComponent<Rigidbody2D>().AddForce(Vector2.right, ForceMode2D.Force);

        GameObject astRight = Instantiate<GameObject>(prefabAsteroid);
        Asteroid astscriptRight = astRight.GetComponent<Asteroid>();
        Vector3 spawnRight = new Vector3(ScreenUtils.ScreenRight + colliderRadius, 0);
        astscriptRight.Initialize(Direction.Left, spawnRight);
        astscriptRight.GetComponent<Rigidbody2D>().AddForce(Vector2.left, ForceMode2D.Force);

        GameObject astTop = Instantiate<GameObject>(prefabAsteroid);
        Asteroid astscriptTop = astTop.GetComponent<Asteroid>();
        Vector3 spawnTop = new Vector3(0, ScreenUtils.ScreenTop + colliderRadius);
        astscriptTop.Initialize(Direction.Down, spawnTop);
        astscriptTop.GetComponent<Rigidbody2D>().AddForce(Vector2.down, ForceMode2D.Force);

        GameObject astBottom = Instantiate<GameObject>(prefabAsteroid);
        Asteroid astscriptBottom = astBottom.GetComponent<Asteroid>();
        Vector3 spawnBottom = new Vector3(0, ScreenUtils.ScreenBottom - colliderRadius);
        astscriptBottom.Initialize(Direction.Up, spawnBottom);
        astscriptBottom.GetComponent<Rigidbody2D>().AddForce(Vector2.up, ForceMode2D.Force);
    }
}
