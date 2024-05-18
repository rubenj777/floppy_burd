using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{
    public float speed = 5f;
    private float leftEdge;

    private void Start()
    {
        // affecte la valeur de la largeur de la caméra pour détecter lorsque les pipes sortent de l'écran par la gauche
        // -12 pour que l'object soit détruit lorsqu'il est complétement sorti de l'écran
        leftEdge = Camera.main.ScreenToViewportPoint(Vector3.zero).x - 12f;
    }
    private void Update()
    {
        transform.position += speed * Time.deltaTime * Vector3.left;

        // détruit le GameObject lorsque les pipes sortent de l'écran
        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }


}
