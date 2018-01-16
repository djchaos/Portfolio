using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{

    public enum Tiles
    {
        Grass,
        Solide,
        Tree,
        Bomb,
        SpeedBoost,
        Switch,
        Button,
    }

    private const float PIXEL_PER_UNIT = 16;
    private const int TILE_SIZE = 16;

    private int[,] maps = new int[10, 10] { { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                                            { 1, 0, 1, 0, 0, 0, 0, 0, 0, 1 },
                                            { 1, 0, 0, 0, 0, 0, 0, 3, 0, 1 },
                                            { 1, 0, 0, 0, 0, 0, 0, 5, 0, 1 },
                                            { 1, 0, 0, 0, 2, 2, 0, 5, 0, 1 },
                                            { 1, 0, 0, 0, 6, 2, 0, 5, 0, 1 },
                                            { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                                            { 1, 0, 4, 0, 0, 0, 0, 0, 0, 1 },
                                            { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                                            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },};

    private IInteractiveObject[,] mapsInterctac = new IInteractiveObject[10, 10];


    private const int MAPS_MAX = 10;

    public GameObject Grass;
    public GameObject Solide;

    public GameObject Tree;
    public GameObject Bomb;
    public GameObject Button;
    public GameObject SpeedBoost;
    public GameObject Switch;

    private Dictionary<Tiles,GameObject> PrefabByTiles;

    void Start()
    {
        PrefabByTiles = new Dictionary<Tiles, GameObject> {
            { Tiles.Grass, Grass },
            { Tiles.Solide, Solide },
            { Tiles.Tree, Tree },
            { Tiles.Bomb, Bomb },
            { Tiles.SpeedBoost, SpeedBoost },
            { Tiles.Switch, Switch },
            { Tiles.Button, Button },
        };
        Vector2 Position = new Vector2(0, 0);

        int index = 0;
        for (int i = 0; i < MAPS_MAX; i++)
        {
            for (int j = 0; j < MAPS_MAX; j++)
            {
                Vector2 offset = new Vector2(TILE_SIZE / PIXEL_PER_UNIT * j, -TILE_SIZE / PIXEL_PER_UNIT * i);
                Vector2 spawnPos = new Vector2(i, j);
                IInteractiveObject obj = CreateTiles((Tiles)maps[i, j], spawnPos);
                if (obj != null)
                {
                    mapsInterctac[i, j] = obj;
                    if (obj is Switchs)
                    {
                        ((Switchs)obj).index = index++;
                    }
                    else if (obj is Button)
                    {
                        ((Button)obj).InteractionStarted += OnDoorOpen;
                    }
                }
            }
        }
    }

    private void OnDoorOpen(IInteractiveObject source)
    {
        Debug.Log("door open");
    }

    public IInteractiveObject CreateTiles(Tiles type, Vector2 Spawn)
    {
        GameObject po = Instantiate(PrefabByTiles[type], Spawn, new Quaternion(0, 0, 0, 0));

        switch (type)
        {
            case Tiles.Switch:
                    return po.GetComponent<Switchs>();
            case Tiles.Button:
                return po.GetComponent<Button>();
        }
        return null;
    }

    public bool Hittest(int x, int y)
    {
        int i = x;
        int j = y;

        if (i < 1 || j < 1 || i > 9 || j > 9)
        {
            return true;
        }

        return maps[i, j] == 1 || maps[i, j] == 2;
    }
    public void TakeItme(Vector3 position)
    {
        int i = (int)position.x;
        int j = (int)position.y;

        if (i < 1 || j < 1 || i > 9 || j > 9)
        {
            return;
        }
        if (maps[i,j] == 3)
        {
            FindObjectOfType<Inventory>().AddItem(new Bomb());
        }
        if (maps[i, j] == 4)
        {
            FindObjectOfType<Inventory>().AddItem(new SpeedBoost());
        }

    }

    internal void Interact(Vector3 pos)
    {
        int i = (int)pos.x;
        int j = (int)pos.y;

        if (i < 1 || j < 1 || i > 9 || j > 9)
        {
            return ;
        }
        IInteractiveObject obj = mapsInterctac[i, j];
        if (obj != null)
        {
            obj.StartInteraction();
        }

    }
}
