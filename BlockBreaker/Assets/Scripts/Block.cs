using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //Config params
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject Particle;
    [SerializeField] Sprite[] hitSprites;

    //Cached reference
    Level level;

    //State Variables
    [SerializeField] int timesHit;
    private void Start()
    {
        CountBlocks();
    }

    private void CountBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBreakableBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && tag == "Breakable")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block Sprite is Missing from an array" + gameObject.name);
        }
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        FindObjectOfType<GameStatus>().AddScore();
        Destroy(gameObject);
        level.BlockDestroyed();
        TriggerParticle();
    }

    private void TriggerParticle()
    {
        GameObject sparkles = Instantiate(Particle);
        sparkles.transform.position = transform.position;
        Destroy(sparkles, 1f);
    }
}
