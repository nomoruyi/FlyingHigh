using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    private float length;
    private float currentSpritePositionX;
    public GameObject cam;

    [SerializeField][Range(0f, 1f)] float parallaxEffect;

    // Start is called before the first frame update
    void Start()
    {
        currentSpritePositionX = transform.position.x;
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        length = renderer.bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        //Faktor, um den sich das Sprite in die entgegengesetzte Richtung bewegt 
        float dist = (cam.transform.position.x * -parallaxEffect);

        transform.position = new Vector3(currentSpritePositionX + dist, transform.position.y, transform.position.z);

        if (temp > currentSpritePositionX + length) currentSpritePositionX += length;
        else if (temp < currentSpritePositionX - length) currentSpritePositionX -= length;
    }
}