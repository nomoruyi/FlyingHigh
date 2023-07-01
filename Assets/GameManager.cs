using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;

public enum ItemState { Sober, Jibit, Vodka, LSD}

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
    public TMP_Text lifesText;
 
    public int points = 0;

    public TMP_Text pointsText;
    public ItemState currentItemState = ItemState.Sober;
    public float itemTime = 15.0f;
    private float _itemTime = 0;
    [SerializeField]
    public GameObject vodkaBg;
    [SerializeField]
    public GameObject lsdBg;

    [SerializeField]
    public AudioSource defaultBgMusic;
    [SerializeField] 
    private AudioSource deathSoundEffect;

    private void Awake()
    {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateHUD();
    }

    // Update is called once per frame
    void Update()
    {
        if(_itemTime > 0 && currentItemState != ItemState.Sober)
        {
            _itemTime = Time.deltaTime;
           // Debug.Log(_itemTime);
                
        }
        if (lifes <= 0)
        {
            GameOver();
        }

        UpdateHUD();
    }

    public IEnumerator SetGameState(ItemState itemState)
    {
        SetItemState(itemState);
        Debug.Log("Item state SET");
        yield return new WaitForSeconds(7);
        SetItemState(ItemState.Sober);
        Debug.Log("Item state BACK TO NORMAL");
    }

    private void UpdateHUD()
    {
        lifesText.text = lifes.ToString();
        pointsText.text = points.ToString();
    }

    public void SetItemState(ItemState state)
    {
        switch (state)
        {
            case ItemState.Sober:  
                currentItemState = ItemState.Sober;
               vodkaBg.SetActive(false);
               lsdBg.SetActive(false);
                break;
             case ItemState.Jibit:
                currentItemState= ItemState.Jibit;
                _itemTime = itemTime;
                vodkaBg.SetActive(false);
                lsdBg.SetActive(false);
                break;
            case ItemState.Vodka:
                currentItemState = ItemState.Vodka;
                vodkaBg.SetActive(true);
                lsdBg.SetActive(false);
                break;
            case ItemState.LSD:
                currentItemState= ItemState.LSD;
                vodkaBg.SetActive(false);
                lsdBg.SetActive(true);
                break;
      
        }

        Debug.Log(currentItemState.ToString());

    }

    public void TakeDamage()
    {
 
        lifes--;
        if(lifes <= 0)
        {
            Die();
        }

    }

    public void Die()
    {
        deathSoundEffect.Play();
        RestartLevel();
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void GameOver()
    {

    }
}
