using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hint : MonoBehaviour
{
    public int HintCount = 3;
    public GameObject Check;
    public Text HintButtonText;
    public PictureSpawn PicSpawn;

    public void HintButton()
    {
        if (PicSpawn.index < PicSpawn.PictureList.Count)
        {
            if (HintCount > 0)
            {
                HintCount--;
                StartCoroutine(FadeHint());
            }
        }
    }

    private void Update()
    {
        HintButtonText.text = "Hint" + HintCount + "/" + "3";

        if (GameManager.instance.gameStart)
        {
            StartCoroutine(PicSpawn.PictureisCleared());
        }
    }

    public IEnumerator FadeHint()
    {
        int colindex = Random.Range(0, PicSpawn.PictureList[PicSpawn.index].ChildCollider.Length);
        GameObject clone = Instantiate(Check, PicSpawn.PictureList[PicSpawn.index].ChildCollider[colindex].transform.position, Quaternion.identity);

        yield return new WaitForSeconds(3f);
        Destroy(clone);
    }
}