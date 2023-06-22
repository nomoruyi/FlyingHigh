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
       
        if (collision.gameObject.layer == LayerMask.NameToLayer("Item"))
        {
            Debug.LogWarning("ITEM");
            if (collision.gameObject.CompareTag("Coin")) return;
          
      
            if(collision.gameObject.CompareTag("FinishLine"))
            {
                GameManager.Instance.Die();
            }
            else
            {
                ItemState itemState = (ItemState)Enum.Parse(typeof(ItemState), collision.gameObject.tag);

                StartCoroutine(SetGameState(itemState))
                ;
                CollectAndDestroy(collision.gameObject, collectItemSound);

            }


        }
    }

    private IEnumerator SetGameState(ItemState itemState) {
        GameManager.Instance.SetItemState(itemState);
        yield return new WaitForSeconds(7);
        GameManager.Instance.SetItemState(ItemState.Sober);
    }

    private void CollectAndDestroy(GameObject gameObject, AudioSource audioSource)
    {
        Debug.Log("Item");
        audioSource.Play();
        coins++;

        Destroy(gameObject);
    }
}
