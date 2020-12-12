/*
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Solutions.Year2020
{

    class Day11 : ASolution
    {
        public string[] room;
        string[] room2;
        public bool[,] needsChange;

        public Day11() : base(11, 2020, "")
        {
            room = Input.SplitByNewline();
            room2 = new string[room.Length];
            Array.Copy(room, room2, room.Length);
            needsChange = new bool[room.Length, room[0].Length];
        }

        protected override string SolvePartOne()
        {
            do
            {
                CheckForChanges();
                ChangeSeats();
            } while (CheckForChanges());
            return CountSeats().ToString();
        }

        public bool CheckForChanges()
        {
            bool changedSomething = false;
            for (int i = 0; i < needsChange.GetLength(0); i++)
            {
                for (int j = 0; j < needsChange.GetLength(1); j++)
                {
                    needsChange[i,j] = false;
                }
            }

            for (int i = 0; i < room.Length; i++)
            {
                for (int j = 0; j < room[i].Length; j++)
                {
                    if (room[i][j] == '.')
                    {
                        continue;
                    }
                    int adjacent = 0;
                    if (i == 0 && j == 0)
                    {
                        if (room[i][j] == 'L')
                        {
                            if (room[i][j + 1] != '#' && room[i + 1][j] != '#' && room[i + 1][j + 1] != '#')
                            {
                                needsChange[i,j] = true;
                                changedSomething = true;
                            }
                        }
                    }
                    else if (i == 0 && j == room[i].Length - 1)
                    {
                        if (room[i][j] == 'L')
                        {
                            if (room[i][j - 1] != '#' && room[i + 1][j - 1] != '#' && room[i + 1][j] != '#')
                            {
                                needsChange[i,j] = true;
                                changedSomething = true;
                            }
                        }
                    }
                    else if (i == room.Length - 1 && j == room[i].Length - 1)
                    {
                        if (room[i][j] == 'L')
                        {
                            if (room[i][j - 1] != '#' && room[i - 1][j - 1] != '#' && room[i - 1][j] != '#')
                            {
                                needsChange[i,j] = true;
                                changedSomething = true;
                            }
                        }
                    }
                    else if (i == room.Length - 1 && j == 0)
                    {
                        if (room[i][j] == 'L')
                        {
                            if (room[i - 1][j] != '#' && room[i - 1][j + 1] != '#' && room[i][j + 1] != '#')
                            {
                                needsChange[i,j] = true;
                                changedSomething = true;
                            }
                        }
                    }
                    else if (i == 0)
                    {
                        if (room[i][j] == 'L')
                        {
                            if (room[i][j + 1] != '#' && room[i + 1][j] != '#' && room[i + 1][j + 1] != '#' && room[i + 1][j - 1] != '#' && room[i][j - 1] != '#')
                            {
                                needsChange[i,j] = true;
                                changedSomething = true;
                            }
                        }
                        else if (room[i][j] == '#')
                        {
                            if (room[i][j + 1] == '#')
                            {
                                adjacent++;
                            }
                            if (room[i + 1][j] == '#')
                            {
                                adjacent++;
                            }
                            if (room[i + 1][j + 1] == '#')
                            {
                                adjacent++;
                            }
                            if (room[i + 1][j - 1] == '#')
                            {
                                adjacent++;
                            }
                            if (room[i][j - 1] == '#')
                            {
                                adjacent++;
                            }
                            if (adjacent >= 4)
                            {
                                needsChange[i,j] = true;
                                changedSomething = true;
                            }
                        }
                    }
                    else if (i == room.Length - 1)
                    {
                        if (room[i][j] == 'L')
                        {
                            if (room[i][j - 1] != '#' && room[i - 1][j - 1] != '#' && room[i - 1][j] != '#' && room[i - 1][j + 1] != '#' && room[i][j + 1] != '#')
                            {
                                needsChange[i,j] = true;
                                changedSomething = true;
                            }
                        }
                        else if (room[i][j] == '#')
                        {
                            if (room[i][j - 1] == '#')
                            {
                                adjacent++;
                            }
                            if (room[i - 1][j - 1] == '#')
                            {
                                adjacent++;
                            }
                            if (room[i - 1][j] == '#')
                            {
                                adjacent++;
                            }
                            if (room[i - 1][j + 1] == '#')
                            {
                                adjacent++;
                            }
                            if (room[i][j + 1] == '#')
                            {
                                adjacent++;
                            }
                            if (adjacent >= 4)
                            {
                                needsChange[i,j] = true;
                                changedSomething = true;
                            }
                        }
                    }
                
                    else if (j == 0)
                    {
                        if (room[i][j] == 'L')
                        {
                            if (room[i - 1][j] != '#' && room[i - 1][j + 1] != '#' && room[i][j + 1] != '#' && room[i + 1][j + 1] != '#' && room[i + 1][j] != '#')
                            {
                                needsChange[i,j] = true;
                                changedSomething = true;
                            }
                        }
                        else if (room[i][j] == '#')
                        {
                            if (room[i - 1][j] == '#')
                            {
                                adjacent++;
                            }
                            if (room[i - 1][j + 1] == '#')
                            {
                                adjacent++;
                            }
                            if (room[i][j + 1] == '#')
                            {
                                adjacent++;
                            }
                            if (room[i + 1][j + 1] == '#')
                            {
                                adjacent++;
                            }
                            if (room[i + 1][j] == '#')
                            {
                                adjacent++;
                            }
                            if (adjacent >= 4)
                            {
                                needsChange[i,j] = true;
                                changedSomething = true;
                            }
                        }
                    }
                    else if (j == room[i].Length - 1)
                    {
                        if (room[i][j] == 'L')
                        {
                            if (room[i - 1][j] != '#' && room[i - 1][j - 1] != '#' && room[i][j - 1] != '#' && room[i + 1][j - 1] != '#' && room[i + 1][j] != '#')
                            {
                                needsChange[i,j] = true;
                                changedSomething = true;
                            }
                        }
                        else if (room[i][j] == '#')
                        {
                            if (room[i - 1][j] == '#')
                            {
                                adjacent++;
                            }
                            if (room[i - 1][j - 1] == '#')
                            {
                                adjacent++;
                            }
                            if (room[i][j - 1] == '#')
                            {
                                adjacent++;
                            }
                            if (room[i + 1][j - 1] == '#')
                            {
                                adjacent++;
                            }
                            if (room[i + 1][j] == '#')
                            {
                                adjacent++;
                            }
                            if (adjacent >= 4)
                            {
                                needsChange[i,j] = true;
                                changedSomething = true;
                            }
                        }
                    }
                    else
                    {
                        if (room[i][j] == 'L')
                        {
                            if (room[i - 1][j] != '#' && room[i - 1][j + 1] != '#' && room[i][j + 1] != '#' && room[i + 1][j + 1] != '#' && room[i + 1][j] != '#' && room[i - 1][j - 1] != '#' && room[i][j - 1] != '#' && room[i + 1][j - 1] != '#')
                            {
                                needsChange[i,j] = true;
                                changedSomething = true;
                            }
                        }
                        else if (room[i][j] == '#')
                        {
                            if (room[i - 1][j] == '#')
                            {
                                adjacent++;
                            }
                            if (room[i - 1][j + 1] == '#')
                            {
                                adjacent++;
                            }
                            if (room[i][j + 1] == '#')
                            {
                                adjacent++;
                            }
                            if (room[i + 1][j + 1] == '#')
                            {
                                adjacent++;
                            }
                            if (room[i + 1][j] == '#')
                            {
                                adjacent++;
                            }
                            if (room[i - 1][j - 1] == '#')
                            {
                                adjacent++;
                            }
                            if (room[i][j - 1] == '#')
                            {
                                adjacent++;
                            }
                            if (room[i + 1][j - 1] == '#')
                            {
                                adjacent++;
                            }
                            if (adjacent >= 4)
                            {
                                needsChange[i,j] = true;
                                changedSomething = true;
                            }
                        }
                    }
                }
            }
            return changedSomething;
        }

        public void ChangeSeats()
        {
            for (int i = 0; i < room.Length; i++)
            {
                for (int j = 0; j < room[i].Length; j++)
                {
                    if (needsChange[i,j])
                    {
                        StringBuilder sb = new StringBuilder(room[i]);
                        if (room[i][j] == 'L')
                        {
                            sb[j] = '#';
                            room[i] = sb.ToString();
                        }
                        else if (room[i][j] == '#')
                        {
                            sb[j] = 'L';
                            room[i] = sb.ToString();
                        }
                    }
                }
            }
        }

        public int CountSeats()
        {
            int count = 0;
            for (int i = 0; i < room.Length; i++)
            {
                for (int j = 0; j < room[i].Length; j++)
                {
                    if (room[i][j] == '#')
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public bool CheckForChanges2()
        {
            bool changedSomething = false;
            for (int i = 0; i < needsChange.GetLength(0); i++)
            {
                for (int j = 0; j < needsChange.GetLength(1); j++)
                {
                    needsChange[i,j] = false;
                }
            }

            for (int i = 0; i < room.Length; i++)
            {
                for (int j = 0; j < room[i].Length; j++)
                {
                    int seen = 0;
                    if (room[i][j] == '.')
                    {
                        continue;
                    }
                    else
                    {
                        for (int y = j + 1; y < room[i].Length; y++)
                        {
                            if (room[i][y] == '#')
                            {
                                seen++;
                                break;
                            }
                            if (room[i][y] == 'L')
                            {
                                break;
                            }
                        }
                        for (int y = j - 1; y >= 0; y--)
                        {
                            if (room[i][y] == '#')
                            {
                                seen++;
                                break;
                            }
                            if (room[i][y] == 'L')
                            {
                                break;
                            }
                        }
                        for (int x = i + 1; x < room.Length; x++)
                        {
                            if (room[x][j] == '#')
                            {
                                seen++;
                                break;
                            }
                            if (room[x][j] == 'L')
                            {
                                break;
                            }
                        }
                        for (int x = i - 1; x >= 0; x--)
                        {
                            if (room[x][j] == '#')
                            {
                                seen++;
                                break;
                            }
                            if (room[x][j] == 'L')
                            {
                                break;
                            }
                        }
                        for (int x = i + 1, y = j + 1; x < room.Length && y < room[i].Length; x++, y++)
                        {
                            if (room[x][y] == '#')
                            {
                                seen++;
                                break;
                            }
                            if (room[x][y] == 'L')
                            {
                                break;
                            }
                        }
                        for (int x = i - 1, y = j - 1; x >= 0 && y >= 0; x--, y--)
                        {
                            if (room[x][y] == '#')
                            {
                                seen++;
                                break;
                            }
                            if (room[x][y] == 'L')
                            {
                                break;
                            }
                        }
                        for (int x = i - 1, y = j + 1; x > 0 && y < room[i].Length; x--, y++)
                        {
                            if (room[x][y] == '#')
                            {
                                seen++;
                                break;
                            }
                            if (room[x][y] == 'L')
                            {
                                break;
                            }
                        }
                        for (int x = i + 1, y = j - 1; x < room.Length && y >= 0; x++, y--)
                        {
                            if (room[x][y] == '#')
                            {
                                seen++;
                                break;
                            }
                            if (room[x][y] == 'L')
                            {
                                break;
                            }
                        }
                    }

                    if (room[i][j] == 'L' && seen == 0)
                    {
                        needsChange[i,j] = true;
                        changedSomething = true;
                    }
                    else if (room[i][j] == '#' && seen >= 5)
                    {
                        needsChange[i,j] = true;
                        changedSomething = true;
                    }
                }
            }
            return changedSomething;
        }

        protected override string SolvePartTwo()
        {
            Array.Copy(room2, room, room.Length);
            
            do
            {
                CheckForChanges2();
                ChangeSeats();
            } while (CheckForChanges2());
            return CountSeats().ToString();
        }
    }
}
*/
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solutions.Year2020
{

    class Day11 : ASolution
    {
        Dictionary<(int, int), bool> Seats = new Dictionary<(int, int), bool>();
        Dictionary<(int, int), bool> Seats2;
        private readonly List<(int, int)> Neighbors = new List<(int x, int y)>()
        {
            (1,0),
            (1,1),
            (0,1),
            (-1,1),
            (-1,0),
            (-1,-1),
            (0,-1),
            (1,-1)
        };
        readonly int maxX = 0;
        readonly int maxY = 0;

        public Day11() : base(11, 2020, "")
        {
            var lines = Input.SplitByNewline().ToList();
            maxY = lines.Count;
            for(int j = 0; j < lines.Count; j++)
            {
                for(int i = 0; i < lines[j].Length; i++)
                {
                    if (lines[j][i] == 'L') Seats[(i, j)] = false;
                    else if(lines[j][i] == '#') Seats[(i, j)] = false;
                    if (i > maxX) maxX = i;
                }
            }

            Seats2 = new Dictionary<(int, int), bool>(Seats);
        }

        protected override string SolvePartOne()
        {
            int seatsChanged = int.MaxValue;
            do
            {
                seatsChanged = 0;
                var nextSeats = new Dictionary<(int, int), bool>(Seats);
                foreach(var seat in Seats)
                {
                    bool nextVal = AliveNext(seat.Key);
                    if (nextVal != seat.Value) seatsChanged++;
                    nextSeats[seat.Key] = nextVal;
                }

                Seats = new Dictionary<(int, int), bool>(nextSeats);
            } while (seatsChanged != 0);


            return Seats.Count(x => x.Value).ToString();
        }

        protected override string SolvePartTwo()
        {
            Seats = new Dictionary<(int, int), bool>(Seats2);
            int seatsChanged = int.MaxValue;
            do
            {
                seatsChanged = 0;
                var nextSeats = new Dictionary<(int, int), bool>(Seats);
                foreach (var seat in Seats)
                {
                    bool nextVal = AliveNext(seat.Key, true);
                    if (nextVal != seat.Value) seatsChanged++;
                    nextSeats[seat.Key] = nextVal;
                }

                Seats = new Dictionary<(int, int), bool>(nextSeats);
            } while (seatsChanged != 0);


            return Seats.Count(x => x.Value).ToString();
        }

        private bool AliveNext((int x, int y) c, bool part2 = false)
        {
            int livingNeighbors = 0;
            List<(int, int)> locNeighbors = new List<(int x, int y)>();
            List<(int, int)> extendedNeighbors = new List<(int x, int y)>();
            foreach (var n in Neighbors)
            {
                locNeighbors.Add(c.Add(n));

                var tmp = c.Add(n);
                while(!Seats.ContainsKey(tmp))
                {
                    if (tmp.Item1 < 0 || tmp.Item1 > maxX || tmp.Item2 < 0 || tmp.Item2 > maxY) break;
                    tmp = tmp.Add(n);
                }

                extendedNeighbors.Add(tmp);
            }

            

            

            if (part2)
            {
                foreach (var n in extendedNeighbors)
                {
                    if (!Seats.ContainsKey(n)) continue;
                    if (Seats[n]) livingNeighbors++;
                }
                if (Seats[c])
                {
                    if (livingNeighbors < 5) return true;
                }
                else
                {
                    if (livingNeighbors == 0) return true;
                }
            } else
            {
                foreach (var n in locNeighbors)
                {
                    if (!Seats.ContainsKey(n)) continue;
                    if (Seats[n]) livingNeighbors++;
                }

                if (Seats[c])
                {
                    if (livingNeighbors < 4) return true;
                }
                else
                {
                    if (livingNeighbors == 0) return true;
                }
            }


            
            return false;
        }
    }
}