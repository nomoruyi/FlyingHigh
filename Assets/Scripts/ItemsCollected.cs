using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsCollected : MonoBehaviour
{
    [SerializeField] private AudioSource collectItemSound;

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

            Debug.Log("Item");
            collectItemSound.Play();
            GameManager.Instance.points += 100;
            ItemState itemState = (ItemState)Enum.Parse(typeof(ItemState), gameObject.tag);
            Debug.LogWarning("Should Call collectAndDestroy");
           
            StartCoroutine(GameManager.Instance.SetGameState(itemState));
            StartCoroutine(CollectAndDestroy());
        }
    }

    private IEnumerator CollectAndDestroy()
    {
        gameObject.GetComponent<SpriteRenderer>().forceRenderingOff = true;
        Debug.LogWarning("Should Destroy after 1 sec");
        yield return new WaitForSeconds(8);
        Debug.LogError("Destroyed");
        Destroy(gameObject);
    }
}
