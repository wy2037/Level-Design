using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            gameObject.SetActive(false);
        }
    }
}
