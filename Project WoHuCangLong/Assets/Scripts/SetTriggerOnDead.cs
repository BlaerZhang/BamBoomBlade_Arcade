using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SetTriggerOnDead : MonoBehaviour
{
    public GameObject playerWeapon;

    public GameObject playerCharacter;

    private List<BoxCollider2D> playerColliders;

    private List<SpriteRenderer> playerRenderers;

    private List<SpriteMask> playerMasks;

    private bool isSet = false;

    void Start()
    {
        isSet = false;
    }

    void Update()
    {
        if (GameManager.instance.player1HP <= 0 && gameObject.name.Equals("Player1") && !isSet)
        {
            playerColliders = playerCharacter.GetComponentsInChildren<BoxCollider2D>().ToList();
            playerRenderers = playerCharacter.GetComponentsInChildren<SpriteRenderer>().ToList();
            playerMasks = playerCharacter.GetComponentsInChildren<SpriteMask>().ToList();
            playerColliders.Add(playerWeapon.GetComponent<BoxCollider2D>());
            playerRenderers.Add(playerWeapon.GetComponent<SpriteRenderer>());

            foreach (var boxCollider2D in playerColliders)
            {
                boxCollider2D.isTrigger = true;
            }

            foreach (var spriteRenderer in playerRenderers)
            {
                spriteRenderer.sortingOrder += 100;
            }

            foreach (var spriteMask in playerMasks)
            {
                spriteMask.backSortingOrder += 100;
                spriteMask.frontSortingOrder += 100;
            }

            isSet = true;
        }
        
        if (GameManager.instance.player2HP <= 0 && gameObject.name.Equals("Player2") && !isSet)
        {
            playerColliders = playerCharacter.GetComponentsInChildren<BoxCollider2D>().ToList();
            playerRenderers = playerCharacter.GetComponentsInChildren<SpriteRenderer>().ToList();
            playerMasks = playerCharacter.GetComponentsInChildren<SpriteMask>().ToList();
            playerColliders.Add(playerWeapon.GetComponent<BoxCollider2D>());
            playerRenderers.Add(playerWeapon.GetComponent<SpriteRenderer>());

            foreach (var boxCollider2D in playerColliders)
            {
                boxCollider2D.isTrigger = true;
            }
            
            foreach (var spriteRenderer in playerRenderers)
            {
                spriteRenderer.sortingOrder += 100;
            }

            foreach (var spriteMask in playerMasks)
            {
                spriteMask.backSortingOrder += 100;
                spriteMask.frontSortingOrder += 100;
            }
            
            isSet = true;
        }
    }
}
