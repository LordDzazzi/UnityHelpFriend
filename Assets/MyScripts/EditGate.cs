using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditGate : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite openGateSprite;
    public Sprite closeGateSprite;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.gameObject.CompareTag("Player"))
        {
          spriteRenderer.sprite = openGateSprite;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
         spriteRenderer.sprite = closeGateSprite;
        }
    }
}    

