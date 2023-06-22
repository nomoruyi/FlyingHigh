using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollected : MonoBehaviour
{
    [SerializeField] public GameObject kiwi;
    [SerializeField] public GameObject collected;

    [SerializeField] private AudioSource collectCoinSound;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            kiwi.SetActive(false);
            collected.SetActive(true);
            Debug.Log("Item");
            collectCoinSound.Play();
            GameManager.Instance.Coins = 20;

            StartCoroutine(CollectAndDestroy());
        }
    }

    private IEnumerator CollectAndDestroy()
    {

        yield return new WaitForSeconds(1);

        Destroy(gameObject);
    }
}
