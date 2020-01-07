using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D playerRb;
    Rigidbody2D[] bodyPartsRb;

    BoxCollider2D playerCollider;
    BoxCollider2D[] bodyPartsColliders;
    CircleCollider2D headCollider;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        bodyPartsRb = GetComponentsInChildren<Rigidbody2D>();

        playerCollider = GetComponent<BoxCollider2D>();
        bodyPartsColliders = GetComponentsInChildren<BoxCollider2D>();
        headCollider = GetComponentInChildren<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        EnableRagdoll();
    }

    void EnableRagdoll()
    {
        headCollider.enabled = true;

        foreach (Rigidbody2D bodyPartsRb in bodyPartsRb)
        {
            bodyPartsRb.bodyType = RigidbodyType2D.Dynamic;
        }

        playerRb.bodyType = RigidbodyType2D.Kinematic;
        playerRb.constraints = RigidbodyConstraints2D.None;

        foreach (BoxCollider2D bodyPartsCollider in bodyPartsColliders)
        {
            bodyPartsCollider.enabled = true;
        }

        playerCollider.enabled = false;
    }

    void DisableRagdoll()
    {
        headCollider.enabled = false;

        foreach (Rigidbody2D bodyPartsRb in bodyPartsRb)
        {
            bodyPartsRb.bodyType = RigidbodyType2D.Kinematic;
        }

        playerRb.bodyType = RigidbodyType2D.Dynamic;
        playerRb.constraints = RigidbodyConstraints2D.FreezeRotation;

        foreach (BoxCollider2D bodyPartsCollider in bodyPartsColliders)
        {
            bodyPartsCollider.enabled = false;
        }

        playerCollider.enabled = true;
    }
}