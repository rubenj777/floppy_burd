using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex;

    public Vector3 direction;
    public float gravity = -9.8f;
    public float strength = 5f;

    // viens chercher le component spriteRenderer qui se trouve
    // attach� sur le m�me GameObject (ici Player)
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            direction = Vector3.up * strength;
        }

        // pour mobile
        if (Input.touchCount > 0)
        {
            // r�f�rence au toucher sur l'�cran
            Touch touch = Input.GetTouch(0);

            // on touche juste l'�cran
            if (touch.phase == TouchPhase.Began)
            {
                direction = Vector3.up;
            }
        }

        // update de la position du joueur
        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }

    private void AnimateSprite()
    {
        spriteIndex++;
        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }

        spriteRenderer.sprite = sprites[spriteIndex];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            FindObjectOfType<Game>().GameOver();
        }
        else if (collision.gameObject.CompareTag("Scoring"))
        {
            FindObjectOfType<Game>().IncreaseScore();
        }
    }
}
