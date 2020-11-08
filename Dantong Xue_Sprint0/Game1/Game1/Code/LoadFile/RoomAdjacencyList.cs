using System;
using System.Collections.Generic;
using System.Text;

namespace Game1.Code.LoadFile
{
    class RoomAdjacencyList
    {
        private List<Dictionary<string, int>> adjacencyList;
        public RoomAdjacencyList()
        {
            adjacencyList = new List<Dictionary<string, int>>()
            {
                // #0 map does not exist
                new Dictionary<string, int>(){ },
                // #1
                new Dictionary<string, int>()
                {
                    {"left", 0},
                    {"right", 2},
                    {"up", 0},
                    {"down", 0}
                },
                // #2
                new Dictionary<string, int>()
                {
                    {"left", 1},
                    {"right", 0},
                    {"up", 0},
                    {"down", 4}
                },
                // #3 special case
                new Dictionary<string, int>(){ },
                // #4
                new Dictionary<string, int>()
                {
                    {"left", 0},
                    {"right", 0},
                    {"up", 2},
                    {"down", 9}
                },
                // #5
                new Dictionary<string, int>()
                {
                    {"left", 0},
                    {"right", 6},
                    {"up", 0},
                    {"down", 11}
                },
                // #6
                new Dictionary<string, int>()
                {
                    {"left", 5},
                    {"right", 0},
                    {"up", 0},
                    {"down", 0}
                },
                // #7
                new Dictionary<string, int>()
                {
                    {"left", 0},
                    {"right", 8},
                    {"up", 0},
                    {"down", 0}
                },
                // #8
                new Dictionary<string, int>()
                {
                    {"left", 7},
                    {"right", 9},
                    {"up", 0},
                    {"down", 12}
                },
                // #9
                new Dictionary<string, int>()
                {
                    {"left", 8},
                    {"right", 10},
                    {"up", 4},
                    {"down", 13}
                },
                // #10
                new Dictionary<string, int>()
                {
                    {"left", 9},
                    {"right", 11},
                    {"up", 0},
                    {"down", 14}
                },
                // #11
                new Dictionary<string, int>()
                {
                    {"left", 10},
                    {"right", 0},
                    {"up", 5},
                    {"down", 0}
                },
                // #12
                new Dictionary<string, int>()
                {
                    {"left", 0},
                    {"right", 13},
                    {"up", 8},
                    {"down", 0}
                },
                // #13
                new Dictionary<string, int>()
                {
                    {"left", 12},
                    {"right", 14},
                    {"up", 9},
                    {"down", 15}
                },
                // #14
                new Dictionary<string, int>()
                {
                    {"left", 13},
                    {"right", 0},
                    {"up", 10},
                    {"down", 0}
                },
                // #15
                new Dictionary<string, int>()
                {
                    {"left", 0},
                    {"right", 0},
                    {"up", 13},
                    {"down", 17}
                },
                // #16
                new Dictionary<string, int>()
                {
                    {"left", 0},
                    {"right", 17},
                    {"up", 0},
                    {"down", 0}
                },
                // #17
                new Dictionary<string, int>()
                {
                    {"left", 16},
                    {"right", 18},
                    {"up", 15},
                    {"down", 0}
                },
                // #18
                new Dictionary<string, int>()
                {
                    {"left", 17},
                    {"right", 0},
                    {"up", 0},
                    {"down", 0}
                }
            };
        }

        public int GetAdjacency(int currRoomID, string doorPosition)
        {
            return adjacencyList[currRoomID][doorPosition];
        }

    }
}
