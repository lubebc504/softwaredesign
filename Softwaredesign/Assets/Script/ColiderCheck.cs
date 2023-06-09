using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColiderCheck : MonoBehaviour
{
    [SerializeField]
    private PictureBase Picture;

    private Collider2D Collider;

    public GameObject Check;

    private void Awake()
    {
        Collider = GetComponent<Collider2D>();
    }

    private void OnMouseDown()
    {
        Picture.colliderCount++;
        Debug.Log(Picture.colliderCount);
        GameObject clone = Instantiate(Check, transform.position, Quaternion.identity);
        clone.transform.SetParent(this.transform, true);
        Collider.enabled = false;
    }
}