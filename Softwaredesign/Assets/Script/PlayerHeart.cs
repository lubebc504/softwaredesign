using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeart : MonoBehaviour
{
    public int health;

    [SerializeField]
    private Collider2D Collider;

    // Start is called before the first frame update
    private void Start()
    {
        health = 5;
    }

    private void OnMouseDown()
    {
        health--;
        Debug.Log("Health down");
    }
}