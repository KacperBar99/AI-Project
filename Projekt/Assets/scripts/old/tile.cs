using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class tile : MonoBehaviour
{
    public TextMeshProUGUI xcord;
    public TextMeshProUGUI ycord;


    public int X;
    public int Y;
    public int Cost;
    public int Distance;
    public int weight;

    public void setCord(int x,int y)
    {
        X = x;
        Y = y;
        xcord.text=x.ToString();
        ycord.text=y.ToString();
    }

    public int CostDistance => Cost + Distance;
    public tile parent=null;

    public void setDistance(int targetX,int targetY)
    {
        this.Distance = Mathf.Abs(targetX - X) + Mathf.Abs(targetY - Y);
    }
    public List<tile> GetNeighbourhs(tile[,] map,tile target)
    {
       var possibleTiles=new List<tile>();

        if(this.Y-1>=0)
        {
            map[this.X, this.Y - 1].Cost = this.Cost + map[this.X, this.Y - 1].weight;
           if(map[this.X, this.Y - 1].parent==null) map[this.X, this.Y - 1].parent = this;
            possibleTiles.Add(map[this.X, this.Y - 1]);
        }
        if(this.Y+1 <10)
        {
            map[this.X, this.Y + 1].Cost = this.Cost + map[this.X, this.Y +1].weight;
           if(map[this.X, this.Y + 1].parent==null) map[this.X, this.Y + 1].parent = this;
            possibleTiles.Add(map[this.X, this.Y + 1]);
        }
        if(this.X-1>=0)
        {
            map[this.X - 1, this.Y].Cost = this.Cost + map[this.X - 1, this.Y].weight;
            if(map[this.X - 1, this.Y].parent == null) map[this.X - 1, this.Y].parent = this;
            possibleTiles.Add(map[this.X - 1, this.Y]);
        }
        if(this.X+1<10)
        {
            map[this.X + 1, this.Y].Cost = this.Cost + map[this.X + 1, this.Y].weight;
            if(map[this.X + 1, this.Y].parent==null) map[this.X + 1, this.Y].parent = this;
            possibleTiles.Add(map[this.X + 1, this.Y]);
        }

        possibleTiles.ForEach(tile => tile.setDistance(target.X, target.Y));

        return possibleTiles;
    }
}
