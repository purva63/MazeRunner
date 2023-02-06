using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MazeR : MonoBehaviour
{

    [SerializeField]
    [Range(1, 50)]
    public int width = 10;

    [SerializeField]
    [Range(1, 50)]
    private int height = 10;

    [SerializeField]
    private float size = 1f;

    [SerializeField]
    private Transform wallPrefab = null;

    [SerializeField]
    private Transform floorPrefab = null;

    [SerializeField]
    private Transform endPrefab = null;

    [SerializeField]
    private Transform barrierPrefab = null;

    private float maxDistance = 0;
    private float posX = 0;
    private float posY = 0;
    private float posZ = 0;
    private float currHealth = 0;
    public GameObject cannon;

    public float speed = 1.0f;
    private List<float> settX = new List<float>();
    private List<float> settY = new List<float>();
    private List<float> settZ = new List<float>();
    internal float player_health = 1.0f;
    private AudioSource src;
    private AudioClip end;
    static public bool completed = false;

    // Start is called before the first frame update
    void Start()
    {
        completed = false;
        var maze = MazeG.Generate(width, height);
        Draw(maze);

        for (int i = 0; i < System.Math.Min(5, settX.Count); i++)
        {
            int index = UnityEngine.Random.Range(0, settX.Count - 1);
            var barrier = Instantiate(barrierPrefab, transform) as Transform;
            barrier.position = new Vector3(settX[i] - 0.1F, settY[i], settZ[i]);
            barrier.localScale = new Vector3(0.6F, barrier.localScale.y, barrier.localScale.z);
            barrier.eulerAngles = new Vector3(0, 90, 0);
            settX.RemoveAt(index);
            settY.RemoveAt(index);
            settZ.RemoveAt(index);

        }

        int endIndex = settX.Count - 1;
        var endGame = Instantiate(endPrefab, transform) as Transform;
        endGame.position = new Vector3(settX[endIndex] + 0.2F, settY[endIndex], settZ[endIndex]);
        endGame.localScale = new Vector3(0.008F, 0.008F, 0.018F);
        endGame.eulerAngles = new Vector3(0, 90, 0);

        src = cannon.GetComponent<AudioSource>();
        end = cannon.GetComponent<cannon>().endGameSound;

    }

    private void Draw(WallState[,] maze)
    {

        var floor = Instantiate(floorPrefab, transform);
        floor.localScale = new Vector3(width, 1, height);

        for (int i = 0; i < width; ++i)
        {
            for (int j = 0; j < height; ++j)
            {
                var cell = maze[i, j];
                var position = new Vector3(-width / 2 + i, 0, -height / 2 + j);

                if (cell.HasFlag(WallState.UP))
                {
                    var topWall = Instantiate(wallPrefab, transform) as Transform;
                    topWall.position = position + new Vector3(0, 0, size / 2);
                    topWall.localScale = new Vector3(size, topWall.localScale.y, topWall.localScale.z);
                }

                if (cell.HasFlag(WallState.LEFT))
                {
                    var leftWall = Instantiate(wallPrefab, transform) as Transform;
                    leftWall.position = position + new Vector3(-size / 2, 0, 0);
                    leftWall.localScale = new Vector3(size, leftWall.localScale.y, leftWall.localScale.z);
                    leftWall.eulerAngles = new Vector3(0, 90, 0);
                }

                if (i == width - 1)
                {
                    if (cell.HasFlag(WallState.RIGHT))
                    {
                        var rightWall = Instantiate(wallPrefab, transform) as Transform;
                        rightWall.position = position + new Vector3(+size / 2, 0, 0);
                        rightWall.localScale = new Vector3(size, rightWall.localScale.y, rightWall.localScale.z);
                        rightWall.eulerAngles = new Vector3(0, 90, 0);
                    }
                }

                if (j == 0)
                {
                    if (cell.HasFlag(WallState.DOWN))
                    {
                        var bottomWall = Instantiate(wallPrefab, transform) as Transform;
                        bottomWall.position = position + new Vector3(0, 0, -size / 2);
                        bottomWall.localScale = new Vector3(size, bottomWall.localScale.y, bottomWall.localScale.z);

                    }
                }

                if(maze[i,j].HasFlag(WallState.UP) && i < height -1 && maze[i+1,j].HasFlag(WallState.UP) && !maze[i,j].HasFlag(WallState.LEFT) && !maze[i + 1, j].HasFlag(WallState.LEFT))
                {
                    //Debug.Log("Came here");
                    settX.Add(position.x + size / 2 );
                    settY.Add(position.y);
                    settZ.Add(position.z);
                    
                }


            }

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        endPrefab.position += Vector3.up * speed;
        currHealth = cannon.GetComponent<cannon>().health;

        if (currHealth == 0)
        {
            cannon.SetActive(false);

        }

        if (!cannon.activeSelf)
        {
            Debug.Log("Game Ended");
            // src.PlayOneShot(end);
        }
    }
}
