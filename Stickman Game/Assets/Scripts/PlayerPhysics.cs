using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{
    Rigidbody2D[] bones;

    // Start is called before the first frame update
    void Start()
    {
        bones = GetComponentsInChildren<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (Rigidbody2D bone in bones)
            {
                bone.constraints = RigidbodyConstraints2D.None;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Respawn")
        {
            foreach(Rigidbody2D bone in bones)
            {
                bone.constraints = RigidbodyConstraints2D.None;
            }

            Destroy(GetComponent<Animator>());
        }
    }
}