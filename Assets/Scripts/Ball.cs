using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle;
    [SerializeField] float initialHeightOffset;
    [SerializeField] AudioClip[] collisionClips;
    bool hasFired = false;

    //Cached references
    AudioSource audioSrc;
    Rigidbody2D physicsBody;

    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        physicsBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasFired)
        {
            transform.position = new Vector2(paddle.transform.position.x, paddle.transform.position.y + initialHeightOffset);

            if (Input.GetMouseButtonDown(0))
            {
                hasFired = true;
                physicsBody.velocity = new Vector2(0, 15f);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasFired)
        {
            audioSrc.PlayOneShot(
                collisionClips[Random.Range(0, collisionClips.Length)]
                );
        }
    }
}
