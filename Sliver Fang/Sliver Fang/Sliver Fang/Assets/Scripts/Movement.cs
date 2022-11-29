using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
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
    [SerializeField] float speed;
    float steps;

    [SerializeField] Button dizeBtn;
    bool isMoving;

    [SerializeField] Sprite[] dizeNumbers;
    [SerializeField] Image dizeSprite;
    [SerializeField] Animator dizeAnim;
    [SerializeField] Animator playerAnim;
    Animator fadeAnim;

    void Start()
    {
        fadeAnim = GameObject.FindGameObjectWithTag("Fader").GetComponent<Animator>();

        currenPos = world.currentLocation;
        playerPos.localPosition = tiles[currenPos].transform.position;

        dizeBtn.onClick.AddListener(() => startMove());
    }

    void Update()
    {
        if (isMoving)
        {
            steps = speed * Time.deltaTime;

            playerPos.localPosition = Vector2.MoveTowards(playerPos.localPosition, tiles[currenPos].transform.position, steps);
           





            
           

        }
    }

    public void startMove()
    {
        if (!isMoving)
        {
            playerAnim.SetBool("Walking", true);

            dizeNum = Random.Range(1, 7);
            dizeSprite.sprite = dizeNumbers[dizeNum-1];
            dizeAnim.enabled = false;
           

            StartCoroutine(move());
            isMoving = true;

        }

    }

    IEnumerator move()
    {
        while (dizeNum > 0)
        {
           

            if (currenPos < tiles.Count - 1)
            {
                currenPos++;

            }
            else
            {
                yield return null;
            }


            //playerPos.localPosition = tiles[currenPos].transform.position;



            world.currentLocation = currenPos;

            float facingDir = playerPos.localPosition.x - tiles[currenPos].transform.position.x;

            if (facingDir > 0)
            {
                playerPos.rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                playerPos.rotation = Quaternion.Euler(0, 0, 0);

            }



            dizeNum--;
          

            yield return new WaitForSeconds(Vector2.Distance(playerPos.localPosition, tiles[currenPos].transform.position)/3);

            if (tiles[currenPos].GetComponent<Platform>() != null)
            {
                Platform currentPlatform = tiles[currenPos].GetComponent<Platform>();


                switch (currentPlatform.type)
                {
                    case platformType.EnemyPlatform:
                        fadeAnim.SetTrigger("Fade");

                        currentPlatform.giveInfo();
                        dizeNum = 0;

                        yield return new WaitForSeconds(1f);
                        SceneManager.LoadScene(2);

                        break;

                    case platformType.shopPlatform:
                        currentPlatform.openShop();
                        dizeNum = 0;

                        break;
                    case platformType.TreasurePlatform:
                        if(dizeNum == 0)
                        {
                            currentPlatform.openChest();
                        }

                        break;
                    default:
                        break;
                }

            }

        }
        isMoving = false;
        dizeAnim.enabled = true;
        playerAnim.SetBool("Walking", false);

    }

}
