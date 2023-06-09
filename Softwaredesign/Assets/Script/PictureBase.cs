using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureBase : MonoBehaviour
{
    public Collider2D[] ChildCollider;

    public int colliderCount = 0;

    public List<GameObject> CheckList;

    // Start is called before the first frame update
    private void Start()
    {
        ChildCollider = new Collider2D[transform.childCount];

        int index = 0;
        for (int i = 0; i < transform.childCount; i++)
        {
            Collider2D childCollider = transform.GetChild(i).GetComponent<Collider2D>();

            if (childCollider != null && childCollider != GetComponent<Collider2D>())
            {
                ChildCollider[index] = childCollider;
                index++;
            }
        }
        for (int i = 0; i < ChildCollider.Length; i++)
        {
            Debug.Log("collider : " + (i + 1));
        }
    }

    public bool AllColliderisChecked()
    {
        if (colliderCount == ChildCollider.Length)
        {
            for (int i = 0; i < ChildCollider.Length; i++)
            {
                GameObject check = GameObject.Find("동그라미(Clone)");
                CheckList.Add(check);
            }
            for (int i = 0; i < CheckList.Count; i++)
            {
                CheckList[i].SetActive(false);
            }
            CheckList.Clear();
            return true;
        }
        else
        {
            return false;
        }
    }
}