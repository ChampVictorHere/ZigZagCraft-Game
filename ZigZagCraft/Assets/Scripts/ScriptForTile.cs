using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptForTile : MonoBehaviour
{
    private float fallTime = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            //Debug.Log("Spawn tile");
            Tiles.Instance.SpawnTile();
            StartCoroutine(Fall());
        }
    }

    IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallTime);
        GetComponent<Rigidbody>().isKinematic = false;
        yield return new WaitForSeconds(2);
        switch (gameObject.name)
        {
            case "RightTile":
                Tiles.Instance.RightTiles.Push(gameObject);
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
                gameObject.SetActive(false);
                break;

            case "TopTile":
                Tiles.Instance.TopTiles.Push(gameObject);
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
                gameObject.SetActive(false);
                break;
        }
    }
}
