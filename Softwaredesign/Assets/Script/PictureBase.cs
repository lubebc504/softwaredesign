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
        CheckList = new List<GameObject>();
        ChildCollider = GetComponentsInChildren<Collider2D>();
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