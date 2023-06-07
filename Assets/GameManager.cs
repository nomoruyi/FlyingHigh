using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemState {sober, jibit, vodka, lsd, mdma}

public class GameManager : MonoBehaviour
{

    public int lifes = 3;
    public ItemState currentItemState = ItemState.sober;
    [SerializeField]
    public AudioSource defaultBgMusic;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if(lifes <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {

    }
}
