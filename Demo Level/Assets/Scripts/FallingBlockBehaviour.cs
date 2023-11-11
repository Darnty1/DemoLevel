using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlockBehaviour : MonoBehaviour
{
    public float wiggleModifier = 0.1f;

    private bool falling = false;

    private Vector3 newPosition;

    // Start is called before the first frame update
    void Start()
    {
        newPosition = transform.position + Vector3.down * 50;
        //StartCoroutine(StartFallingDown());
    }

    // Update is called once per frame
    void Update()
    {
        if (falling)
        {
            transform.position = Vector3.Lerp(transform.position, newPosition , Time.deltaTime * 0.5f);
        }
    }

    public IEnumerator StartFallingDown()
    {
        for (int i = 0; i < 10; i++) 
        {
            transform.position += Vector3.up * wiggleModifier;
            yield return new WaitForSeconds(0.3f);
            transform.position += Vector3.down * wiggleModifier;
            yield return new WaitForSeconds(0.3f);
        }
        falling = true;
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
        yield return null;
    }
}
