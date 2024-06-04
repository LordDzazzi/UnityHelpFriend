using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;
using UnityEngine.UIElements;

public class ChestColision : MonoBehaviour
{
    private bool isOpened = false;
    public Sprite openedChestSprite;
    private SpriteRenderer chestSpriteRender;
    public GameObject[] randomItemsIndex;
   
    void Start()
    {
        chestSpriteRender = transform.parent.gameObject.GetComponent<SpriteRenderer>();
       
        isOpened = false;
    }

  
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.E) && !isOpened)
        {
            StartCoroutine(LootChest());
           
        }
    }
    IEnumerator LootChest()
    {
        isOpened = true;
        Debug.Log("StartLooting");
        yield return new WaitForSeconds(2);
        Debug.Log("StopLooting");
        chestSpriteRender.sprite = openedChestSprite;
        RandomItemsForSpawn();
       
    }

    private void RandomItemsForSpawn()
    {
        float randomSpawnX = Random.Range(-1, 1);
        float randomSpawnY =  Random.Range(-1, 1);
        Vector2 spawnPosition = new Vector2(transform.position.x+randomSpawnX, transform.position.y+randomSpawnY);
        int randomIndex = Random.Range(0, randomItemsIndex.Length);
        Instantiate(randomItemsIndex[randomIndex], spawnPosition, randomItemsIndex[randomIndex].transform.rotation);

    }
  
}
