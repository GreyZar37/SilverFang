using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TresureCoin : MonoBehaviour
{
    public TextMeshPro coinValue;
    int speedValue = 5;
    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = Vector2.up * speedValue;
        StartCoroutine(death());
    }

    IEnumerator death()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
