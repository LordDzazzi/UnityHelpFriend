using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsScript : MonoBehaviour
{
    public float speedChange;
    public float damageChange;
    public float healhChange;
    public float manaChange;
    public float fastArmorHealing;
    public float capacityBagChange;
    public float healhCountChange;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Skeleton").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("popugDzazzi");
        if (collision.gameObject.CompareTag("Player"))
        {
            if (gameObject.CompareTag("AppleWorm"))
            {
                playerControllerScript.healhPlayer /= 2;
                playerControllerScript.UpdateText();
                Destroy(gameObject);
            }
            else if (gameObject.CompareTag("MiniManaPotion"))
            {
                playerControllerScript.manaPlayer += manaChange;
                if (playerControllerScript.manaPlayer > 150) 
                {
                    playerControllerScript.manaPlayer = 150;
                }
                playerControllerScript.UpdateText();
                Destroy(gameObject);
            }
            if (gameObject.CompareTag("ArmorPotion"))
            {
                playerControllerScript.armorPlayer = fastArmorHealing;
                playerControllerScript.UpdateText();
                Destroy(gameObject);
            }
            else if (gameObject.CompareTag("DragonFruit"))
            {
                playerControllerScript.ñapacityBagPlayer += capacityBagChange;
                playerControllerScript.UpdateText();
                Destroy(gameObject);

            }
            else if (gameObject.CompareTag("MiniHealhPotion")) 
            {
                playerControllerScript.healhPlayer += healhCountChange;
                if (playerControllerScript.healhPlayer > 10)
                {
                    playerControllerScript.healhPlayer = 10;
                }
                playerControllerScript.UpdateText();
                Destroy(gameObject);
            }

        }
    }
}

