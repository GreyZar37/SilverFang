using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{

    [SerializeField] Transform playerPos;

    [SerializeField] List<Transform> tiles = new List<Transform>();

    int dizeNum;
    int currenPos;

    [SerializeField]  Button dizeBtn;
    

    void Start()
    {
        dizeBtn.onClick.AddListener(() => startMove());
    }

    void Update()
    {
  
    }

    public void startMove()
    {
        dizeNum = Random.Range(1, 7);
        print(dizeNum);
        StartCoroutine(move());

    }

    IEnumerator move()
    {
        while(dizeNum > 0)
        {

            playerPos.localPosition = tiles[currenPos].transform.position;
            currenPos++;


            yield return new WaitForSeconds(1);

            dizeNum--;


        }


    }
}
