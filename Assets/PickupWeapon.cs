using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Photon.Pun;

public class PickupWeapon : MonoBehaviour
{
    public Weapons weapon;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("PlayerHit");
            collision.gameObject.GetComponent<playerMovement>().currentweapon = weapon;
            collision.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = weapon.currentWeaponSpr;
            PhotonNetwork.Destroy(gameObject);
        }
    }
}
