using UnityEngine;

public enum ItemState { Sober, Jibit, Vodka, LSD, MDMA

}

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null) Debug.LogError("Game Manager is NULL");

            return _instance;
        }
    }


    public int lifes = 3;
    public ItemState currentItemState = ItemState.Sober;
    [SerializeField]
    public AudioSource defaultBgMusic;

    private void Awake()
    {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (lifes <= 0)
        {
            GameOver();
        }
    }

    public void SetItemState(ItemState state)
    {
        switch (state)
        {
            case ItemState.Sober:  
                currentItemState = ItemState.Sober;
                break;
             case ItemState.Jibit:
                currentItemState= ItemState.Jibit;

                break;
            case ItemState.Vodka:
                currentItemState = ItemState.Vodka;
                break;
            case ItemState.LSD:
                currentItemState= ItemState.LSD;
                break;
            case ItemState.MDMA:
                currentItemState= ItemState.MDMA;
                break;
        }
    }

    void GameOver()
    {

    }
}
