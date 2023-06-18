using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    private float startposition; // Startposition des Sprites
    private float length;
    private float currentSpritePositionX;
    public GameObject cam;

    [SerializeField][Range(0f, 1f)] float parallaxEffect;

    // Start is called before the first frame update
    void Start()
    {
        startposition = transform.position.x;
        //length = GetComponent<SpriteRenderer>().bounds.size.x; // Endlänge von unsererem Sprite
    }

    // Update is called once per frame
    void Update()
    {
        float dist = (cam.transform.position.x * -parallaxEffect); // Berechnung, wie weit wir von unserem Startpunkt entfernt sind in negativer Richtung (x=5 * 0.2 = 1)

        transform.position = new Vector3(startposition + dist, transform.position.y, transform.position.z); // Bewegung der Kamerera
    }
}