using System;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public static class AStarGrid
{
    class Node
    {
        public int2 pos;
        public float g;
        public float h;
        public float f => g + h;
        public Node parent;
        public Node(int2 p) { pos = p; g = float.MaxValue; h = 0; }
    }

    public static List<int2> FindPath(int2 start, int2 goal, bool[,] walkable)
    {
        int w = walkable.GetLength(0);
        int h = walkable.GetLength(1);
        Node[,] nodes = new Node[w, h];
        for (int x = 0; x < w; x++)
            for (int y = 0; y < h; y++)
                nodes[x, y] = new Node(new int2(x, y));

        List<Node> open = new List<Node>();
        HashSet<Node> closed = new HashSet<Node>();

        Node startN = nodes[start.x, start.y];
        Node goalN = nodes[goal.x, goal.y];
        startN.g = 0;
        startN.h = Heuristic(start, goal);
        open.Add(startN);

        int2[] dirs = {
            new int2(1,0), new int2(-1,0),
            new int2(0,1), new int2(0,-1)
        };

        while (open.Count > 0)
        {
            open.Sort((a, b) => a.f.CompareTo(b.f));
            Node current = open[0];
            open.RemoveAt(0);
            closed.Add(current);

            if (current == goalN)
                return Reconstruct(current);

            foreach (var d in dirs)
            {
                int2 np = current.pos + d;
                if (!InBounds(np, w, h)) continue;
                if (!walkable[np.x, np.y]) continue;
                Node neighbor = nodes[np.x, np.y];
                if (closed.Contains(neighbor)) continue;

                float tentativeG = current.g + 1;
                if (tentativeG < neighbor.g)
                {
                    neighbor.parent = current;
                    neighbor.g = tentativeG;
                    neighbor.h = Heuristic(np, goal);
                    if (!open.Contains(neighbor)) open.Add(neighbor);
                }
            }
        }

        return null; 
    }

    static bool InBounds(int2 p, int w, int h)
        => p.x >= 0 && p.x < w && p.y >= 0 && p.y < h;

    static float Heuristic(int2 a, int2 b)
        => Mathf.Abs(a.x - b.x) + Mathf.Abs(a.y - b.y); // Âü¹þ¶Ù¾àÀë

    static List<int2> Reconstruct(Node n)
    {
        List<int2> path = new List<int2>();
        while (n != null)
        {
            path.Add(n.pos);
            n = n.parent;
        }
        path.Reverse();
        return path;
    }
}
