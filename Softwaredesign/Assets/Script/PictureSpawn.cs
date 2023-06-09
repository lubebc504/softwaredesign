using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PictureSpawn : MonoBehaviour
{
    public PictureBase[] PicturesPrefabs;
    public List<PictureBase> PictureList;
    public Hint hint;
    public int index = 0;
    public int _ClearCount;
    private int shuffleindex = 1;

    public Text LeftText;

    private void Start()
    {
        PictureList = new List<PictureBase>();
        Vector3 position = new Vector3(0, -1.28f, 0f);
        for (int i = 0; i < PicturesPrefabs.Length; i++)
        {
            PictureList.Add(Instantiate(PicturesPrefabs[i], transform.position + position, Quaternion.identity));
            PictureList[i].gameObject.SetActive(false);
            Debug.Log("그림 선택 : " + i);
        }
    }

    public void Shuffle()
    {
        Debug.Log("Shuffle!");
        for (int i = 0; i < PictureList.Count; i++)
        {
            PictureList[i].gameObject.SetActive(true);
        }
        for (int i = 0; i < 10; i++)
        {
            int a = Random.Range(0, PictureList.Count - 1);
            int b = Random.Range(0, PictureList.Count - 1);

            PictureBase tmp = PictureList[a];
            PictureList[a] = PictureList[b];
            PictureList[b] = tmp;
        }
        PictureList[index].gameObject.SetActive(true);

        for (int i = 0; i < PictureList.Count; i++)
        {
            Debug.Log(PictureList[i].name);
            if (i != index)
            {
                PictureList[i].gameObject.SetActive(false);
            }
        }
    }

    // Start is called before the first frame update
    private void Update()
    {
        if (GameManager.instance.gameStart && shuffleindex == 1)
        {
            Shuffle();
            shuffleindex++;
        }
    }

    // Update is called once per frame

    public IEnumerator PictureisCleared()
    {
        if (index >= PictureList.Count)
        {
            yield return null;
        }
        else
        {
            int leftCollider = PictureList[index].ChildCollider.Length - PictureList[index].colliderCount;
            LeftText.text = "남은 개수 : " + leftCollider;
            if (PictureList[index].AllColliderisChecked())
            {
                _ClearCount++;
                Debug.Log(_ClearCount);
                PictureList[index].gameObject.SetActive(false);
                hint.HintCount = 3;

                index++;
                if (index >= PictureList.Count)
                {
                    yield return null;
                }
                else
                {
                    PictureList[index].gameObject.SetActive(true);
                }
            }
        }
    }
}