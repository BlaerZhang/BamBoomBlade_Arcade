using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SetTriggerOnDead : MonoBehaviour
{
    public GameObject playerWeapon;

    public GameObject playerCharacter;

    private List<BoxCollider2D> playerColliders;
    
    void Start()
    {
        playerColliders = playerCharacter.GetComponentsInChildren<BoxCollider2D>().ToList();
        playerColliders.Add(playerWeapon.GetComponent<BoxCollider2D>());
    }
    
    void Update()
    {
        if (GameManager.instance.player1HP <= 0 && gameObject.name.Equals("Player1"))
        {
            foreach (var boxCollider2D in playerColliders)
            {
                boxCollider2D.isTrigger = true;
            }
        }
        
        if (GameManager.instance.player2HP <= 0 && gameObject.name.Equals("Player2"))
        {
            foreach (var boxCollider2D in playerColliders)
            {
                boxCollider2D.isTrigger = true;
            }
        }
    }
}
