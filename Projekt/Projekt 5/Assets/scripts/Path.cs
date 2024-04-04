using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;


public class Path : MonoBehaviour
{
    public int XS;
    public int YS;

    public int XK;
    public int YK;

    public generationController controller;
    bool calculated = false;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            calculated = false;
        }
        
        if (controller.ready && calculated==false)
        {
            controller.blocks[XS, YS].GetComponent<tile>().setDistance(XK, YK);
            var activeTiles=new List<tile>();
            activeTiles.Add(controller.blocks[XS, YS].GetComponent<tile>());
            var visitedTiles = new List<tile>();

            while(activeTiles.Any())
            {
                
                var checkTile = activeTiles.OrderBy(x => x.CostDistance).First();

                if (checkTile.X == controller.blocks[XK, YK].GetComponent<tile>().X && checkTile.Y == controller.blocks[XK, YK].GetComponent<tile>().Y)
                {
                    int it = 0;
                    var Tile = checkTile;
                    while(true)
                    {
                        it++;
                        Debug.Log($"X:{Tile.X} Y:{Tile.Y}");
                        Tile = Tile.parent;
                        if(Tile==null || it>100)
                        {
                            calculated = true;
                            return;
                        }
                    }
                }
                
                visitedTiles.Add(checkTile);
                activeTiles.Remove(checkTile);

                tile [,]map=new tile[10,10];
                for(int i=0;i<10;i++)
                {
                    for (int j=0;j<10;j++)
                    {
                        map[i, j] = controller.blocks[i, j].GetComponent<tile>();
                    }
                }

                var walkableTiles = checkTile.GetNeighbourhs(map, controller.blocks[XK, YK].GetComponent<tile>());
                map[XS, YS].parent = null;
                foreach (var walkableTile in walkableTiles)
                {
                    if (visitedTiles.Any(x => x.X == walkableTile.X && x.Y == walkableTile.Y))
                        continue;

                    if(activeTiles.Any(x=>x.X==walkableTile.X && x.Y==walkableTile.Y))
                    {
                        var existingTile = activeTiles.First(x => x.X == walkableTile.X && x.Y == walkableTile.Y);
                        if(existingTile.CostDistance>checkTile.CostDistance)
                        {
                            activeTiles.Remove(existingTile);
                            activeTiles.Add(walkableTile);
                        }
                    }
                    else
                    {
                        activeTiles.Add(walkableTile);
                    }
                    
                }
                
            }
        }
        
    }
}
