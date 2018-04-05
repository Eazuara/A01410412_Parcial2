using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D coll)
    {
        // Destroy the coin
        Destroy(gameObject);
    }
}
