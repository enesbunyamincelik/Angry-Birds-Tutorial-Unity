using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Monster : MonoBehaviour
{
    [SerializeField] Sprite _deadSprite;
    [SerializeField] ParticleSystem _particleSystem;

    ScoreManager scoreManager;
    bool _hasDied;

    private void Start()
    {
        scoreManager = GameObject.Find("Canvas").GetComponent<ScoreManager>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!_hasDied && ShouldDieFromCollision(collision))
        {
            StartCoroutine(Die());
            scoreManager.AddScore();
            _hasDied = true;
        }
    }

    bool ShouldDieFromCollision(Collision2D collision)
    {

        Bird bird = collision.gameObject.GetComponent<Bird>();
        if (bird != null)
            return true;

        if (collision.contacts[0].normal.y < -0.5) // Crate Death
            return true;

        return false; // default
    }

    IEnumerator Die()
    {
        _hasDied = true;
        GetComponent<SpriteRenderer>().sprite = _deadSprite;
        _particleSystem.Play();

        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }
}