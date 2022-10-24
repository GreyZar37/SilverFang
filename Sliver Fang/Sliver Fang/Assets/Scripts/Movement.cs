using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public enum platformType
{
    EnemyPlatform, shopPlatform, TreasurePlatform, FreezePlatform, ChooseDirectionPlatfor
}

public class Movement : MonoBehaviour
{
    public WorldManager world;
    [SerializeField] Transform playerPos;

    [SerializeField] List<Transform> tiles = new List<Transform>();

    int dizeNum;
    int currenPos;

    [SerializeField]  Button dizeBtn;
    bool isMoving;




    void Start()
    {
        currenPos = world.currentLocation;
        playerPos.localPosition = tiles[currenPos].transform.position;

        dizeBtn.onClick.AddListener(() => startMove());
    }

    void Update()
    {
  
    }

    public void startMove()
    {
        if (!isMoving)
        {
            dizeNum = Random.Range(1, 7);
            print(dizeNum);
            StartCoroutine(move());
            isMoving = true;

        }

    }

    IEnumerator move()
    {
        while(dizeNum > 0)
        {
            if (currenPos < tiles.Count - 1)
            {
                currenPos++;

            }
            else
            {
               yield return null;
            }


            playerPos.localPosition = tiles[currenPos].transform.position;
            world.currentLocation = currenPos;
            if (tiles[currenPos].GetComponent<Platform>() != null)
            {
                Platform currentPlatform = tiles[currenPos].GetComponent<Platform>();
                

                switch (currentPlatform.type)
                {
                    case platformType.EnemyPlatform:

                        currentPlatform.giveInfo();
                        SceneManager.LoadScene(1);

                        break;

                    case platformType.shopPlatform:

                        print("Shop");
                        break;
                    default:
                        break;
                }

            }

           

            dizeNum--;


            yield return new WaitForSeconds(1);



        }
        isMoving = false;

    }
}
