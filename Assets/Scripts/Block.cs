using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip destroyClip;
    [SerializeField] GameObject destroyAnim;
    [SerializeField] Sprite[] hitSprites;

    Level level;
    GameStatus gameStatus;
    SpriteRenderer spriteComponent;

    int hitsRequired;
    int numHits = 0;

    private void Start()
    {
        hitsRequired = hitSprites.Length + 1;
        
        gameStatus = FindObjectOfType<GameStatus>();
        spriteComponent = GetComponent<SpriteRenderer>();
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.IncNumBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            OnBreakableCollision();
        }
        
        AudioSource.PlayClipAtPoint(
            destroyClip, 
            new Vector3(
                transform.position.x,
                transform.position.y,
                transform.position.z)
            );
    }

    private void OnBreakableCollision()
    {
        numHits++;

        if (numHits >= hitsRequired)
        {
            PlayDestroyAnimation();
            level.DecNumBlocks();
            Destroy(gameObject);
        }
        else
        {
            spriteComponent.sprite = hitSprites[numHits - 1];
        }
        gameStatus.IncScore();
    }

    private void PlayDestroyAnimation()
    {
        GameObject sparklesAnim = Object.Instantiate(destroyAnim, transform.position, transform.rotation);
        Destroy(sparklesAnim.gameObject, 1f);
    }
}
