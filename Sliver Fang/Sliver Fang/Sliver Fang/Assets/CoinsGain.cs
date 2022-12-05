using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsGain : MonoBehaviour
{
    Transform coinsPosition;
    Rigidbody2D rb;
    bool startFollowing;
    // Start is called before the first frame update
    void Start()
    {
        coinsPosition = GameObject.FindGameObjectWithTag("CoinPos").transform;
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
                Destroy(transform.gameObject);
            }
        } 
    }
    IEnumerator timer()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(rb);
        startFollowing = true;
    }

}
