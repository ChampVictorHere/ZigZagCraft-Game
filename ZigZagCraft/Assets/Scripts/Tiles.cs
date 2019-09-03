using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tiles : MonoBehaviour
{
    public GameObject cube;

    //public GameObject rightTile;

    //public GameObject topTile;

    public Slider sliderSize;

    public Slider sliderRandom;

    public GameObject[] tiles;

    public GameObject currentTile;

    private static Tiles instance;

    private Stack<GameObject> rightTiles = new Stack<GameObject>();

    private Stack<GameObject> topTiles = new Stack<GameObject>();

    public static Tiles Instance
    {
        get
        {
            if(instance == null)
            {
                instance = GameObject.FindObjectOfType<Tiles>();
            }
            return instance;
        }
    }


    public Stack<GameObject> TopTiles { get => topTiles; set => topTiles = value; }
    public Stack<GameObject> RightTiles { get => rightTiles; set => rightTiles = value; }

    // Start is called before the first frame update
    void Start()
    {
        //CreateTiles(20);

    for(int i = 0; i < 5; i++)
        {
            SpawnTile();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //SpawnTile();

        if (sliderSize.value == 1)
        {
            tiles[0].transform.localScale = new Vector3(0.33f, 0.33f, 0.33f);
            tiles[1].transform.localScale = new Vector3(0.33f, 0.33f, 0.33f);
            cube.transform.localScale = new Vector3(9f, 1f, 9f);
        }
        else if (sliderSize.value == 2)
        {
            tiles[0].transform.localScale = new Vector3(0.66f, 0.66f, 0.66f);
            tiles[1].transform.localScale = new Vector3(0.66f, 0.66f, 0.66f);
            cube.transform.localScale = new Vector3(9f, 2f, 9f);
        }
        else
        {
            tiles[0].transform.localScale = new Vector3(1f, 1f, 1f);
            tiles[1].transform.localScale = new Vector3(1f, 1f, 1f);
            cube.transform.localScale = new Vector3(9f, 3f, 9f);
        }
    }

    public void CreateTiles(int amount)
    {
        for(int i = 0; i <amount; i++)
        {
            rightTiles.Push(Instantiate(tiles[0]));
            topTiles.Push(Instantiate(tiles[1]));
            rightTiles.Peek().name = "RightTile";
            rightTiles.Peek().SetActive(false);
            topTiles.Peek().name = "TopTile";
            topTiles.Peek().SetActive(false);
        }
    }

    public void SpawnTile()
    {
        int spawnCrystals;
        


        if (rightTiles.Count == 0 || topTiles.Count == 0)
        {
         CreateTiles(5);
        }
        int randomI = Random.Range(0, 2);

        if (randomI == 0)
        {
            GameObject tmp = rightTiles.Pop();
            tmp.SetActive(true);
            tmp.transform.position = currentTile.transform.GetChild(0).transform.GetChild(randomI).position;
            currentTile = tmp;
        }
        else if (randomI == 1)
        {
            GameObject tmp = topTiles.Pop();
            tmp.SetActive(true);
            tmp.transform.position = currentTile.transform.GetChild(0).transform.GetChild(randomI).position;
            currentTile = tmp;
        }
        if (sliderRandom.value == 4)
        {
            spawnCrystals = Random.Range(0, 3);
            if (spawnCrystals == 0)
            {
                currentTile.transform.GetChild(1).gameObject.SetActive(true);
            }
        }
        else { spawnCrystals = Random.Range(0, 5);
            if (spawnCrystals == 0)
            {
                currentTile.transform.GetChild(1).gameObject.SetActive(true);
            }
        }
        
        //currentTile = (GameObject)Instantiate(tiles[randomI], currentTile.transform.GetChild(0).transform.GetChild(randomI).position, Quaternion.identity);
    }

    public void RestartGame()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
