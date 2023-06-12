using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int coins = 0;

   // [SerializeField] private Text cherriesText;

    [SerializeField] private AudioSource collectCoinSound;
    [SerializeField] private AudioSource collectItemSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.LogWarning("Collision");
        Debug.LogWarning(collision.gameObject.layer);
        Debug.LogWarning(LayerMask.NameToLayer("Item"));
        if (collision.gameObject.layer == LayerMask.NameToLayer("Item"))
        {
            Debug.LogWarning("ITEM");
            if (collision.gameObject.CompareTag("Coin"))
            {
                coins++;
                CollectAndDestroy(collision.gameObject, collectCoinSound);

                //  cherriesText.text = "Cherries: " + coins;
            }
            else
            {
                ItemState itemState = (ItemState)Enum.Parse(typeof(ItemState), collision.gameObject.tag);
              
                GameManager.Instance.SetItemState(itemState);
                CollectAndDestroy(collision.gameObject, collectItemSound);

            }


        }
    }

    private void CollectAndDestroy(GameObject gameObject, AudioSource audioSource)
    {
        Debug.Log("Item");
        audioSource.Play();
        coins++;

        Destroy(gameObject);
    }
}
