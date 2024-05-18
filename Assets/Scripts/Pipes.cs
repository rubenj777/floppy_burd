using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{
    public float speed = 5f;
    private float leftEdge;

    private void Start()
    {
        // affecte la valeur de la largeur de la cam�ra pour d�tecter lorsque les pipes sortent de l'�cran par la gauche
        // -12 pour que l'object soit d�truit lorsqu'il est compl�tement sorti de l'�cran
        leftEdge = Camera.main.ScreenToViewportPoint(Vector3.zero).x - 12f;
    }
    private void Update()
    {
        transform.position += speed * Time.deltaTime * Vector3.left;

        // d�truit le GameObject lorsque les pipes sortent de l'�cran
        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }


}
