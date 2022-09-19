using System;
using System.Collections.Generic;
using System.Linq;

namespace TilesMaster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> whiteTiles = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Queue<int> greyTiles = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

            Dictionary<string, int> locationsCount = new Dictionary<string, int>();
            Dictionary<int, string> tilesAreas = new Dictionary<int, string>()
            {
                {40, "Sink" },
                {50, "Oven" },
                {60, "Countertop" },
                {70, "Wall" }
            };

            while (greyTiles.Count > 0 && whiteTiles.Count > 0)
            {
                var currentGreyTile = greyTiles.Dequeue();
                var currentWhiteTile = whiteTiles.Pop();
                var areaSize = currentGreyTile + currentWhiteTile;

                if (currentWhiteTile==currentGreyTile && tilesAreas.ContainsKey(areaSize))
                {
                    var location = tilesAreas[areaSize];
                    if (locationsCount.ContainsKey(location)) locationsCount[location]+=1;
                    else locationsCount.Add(location, 1);
                }
                else if (currentGreyTile==currentWhiteTile)
                {
                    if (locationsCount.ContainsKey("Floor")) locationsCount["Floor"] += 1;
                    else locationsCount.Add("Floor", 1);
                }
                else
                {
                    whiteTiles.Push(currentWhiteTile / 2);
                    greyTiles.Enqueue(currentGreyTile);
                }
            }

            var whiteTilesLeft = whiteTiles.Count <= 0 ? "none" : string.Join(", ", whiteTiles);
            var greyTilesLeft = greyTiles.Count <= 0 ? "none" : string.Join(", ", greyTiles);

            Console.WriteLine($"White tiles left: {whiteTilesLeft}");
            Console.WriteLine($"Grey tiles left: {greyTilesLeft}");

            var order = locationsCount.OrderByDescending(x => x.Value).ThenBy(x => x.Key);
            foreach (var location in order) Console.WriteLine($"{location.Key}: {location.Value}");
        }
    }
}