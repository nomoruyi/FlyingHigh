using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WaveAnimation : MonoBehaviour
{
    [SerializeField]
    public GameObject wave1;
    [SerializeField]
    public GameObject wave2;
    private readonly float timeToSwitch = 0.5f;
    private float timer;
    private bool wave1Active = true;
    // Start is called before the first frame update
    void Start()
    {
        timer = timeToSwitch;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= timeToSwitch) {
        wave1Active = !wave1Active;
            wave1.SetActive(wave1Active);
            wave2.SetActive(!wave1Active);
            timer = 0f;
        }


    }
}
