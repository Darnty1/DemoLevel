using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private List<GameObject> groundPieces = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectsWithTag("GroundPiece", groundPieces);
        StartCoroutine(StartTheGame());
    }

    public IEnumerator StartTheGame()
    {
        for (int i = 0; i < 70; i++)
        {
            int temp = Random.Range(0, groundPieces.Count);
            StartCoroutine(groundPieces[temp].GetComponent<FallingBlockBehaviour>().StartFallingDown());
            groundPieces.RemoveAt(temp);
            yield return new WaitForSeconds(2);
        }

        yield return null;
    }
}
