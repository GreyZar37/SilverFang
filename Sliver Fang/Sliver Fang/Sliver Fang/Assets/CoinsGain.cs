using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsGain : MonoBehaviour
{
    [SerializeField] PlayerEntity playerEntity;
    Transform coinsPosition;
    Rigidbody2D rb;
    bool startFollowing;
    [SerializeField] AudioClip coinCollectSound, coinSpawnSound;
    [SerializeField] string Pos;
    [SerializeField] float timer_;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.playSound(coinSpawnSound, 0.5f);
        coinsPosition = GameObject.FindGameObjectWithTag(Pos).transform;
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(timer());
        rb.velocity = transform.up * 7f;

    }

    // Update is called once per frame
    void Update()
    {
        if(startFollowing == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, coinsPosition.position, 8f * Time.deltaTime);

            if (Vector2.Distance(transform.position, coinsPosition.position) <= .1f)
            {
                if(Pos == "XPPos")
                {
                    playerEntity.currentXP++;
                }
                else
                {
                    playerEntity.gold++;
                }
                AudioManager.playSound(coinCollectSound, 0.5f);
                Destroy(transform.gameObject);

            }
        } 
    }
    IEnumerator timer()
    {
        yield return new WaitForSeconds(timer_);
        Destroy(rb);
        startFollowing = true;
    }

}
