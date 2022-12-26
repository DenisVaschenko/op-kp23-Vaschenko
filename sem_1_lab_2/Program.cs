using System;
using System.Buffers;
using System.Data;
using System.Transactions;

namespace Program1
{
    class Percolation
    {
        static int[,] arr;
        static int[] nodes;
        static int num_of_opened, length;
        // creates n-by-n grid, with all sites initially blocked
        static void init(int n)
        {
            arr = new int[n + 1, n + 1];
            num_of_opened = 0;
            length = n + 1;
            nodes = new int[n * n + 2];
            for (int i = 1; i < n * n + 2; i++)
            {
                nodes[i] = i;
            }
        }

        // opens the site (row, col) if it is not open already
        static void open(int row, int col)
        {
            if (arr[row, col] == 0)
            {
                arr[row, col] = 1;
                int index = getIndex(row, col);
                if (row > 1 && arr[row - 1, col] != 0)
                {
                    union(index, getIndex(row - 1, col));
                }
                else if (row == 1)
                {
                    union(index, 0);
                }
                if (row < length - 1 && arr[row + 1, col] != 0)
                {
                    union(index, getIndex(row + 1, col));
                }
                else if (row == length - 1)
                {
                    union(index, nodes.Length - 1);
                }
                if (col > 1 && arr[row, col - 1] != 0)
                {
                    union(index, getIndex(row, col - 1));
                }
                if (col < length - 1 && arr[row, col + 1] != 0)
                {
                    union(index, getIndex(row, col + 1));
                }
                num_of_opened++;
            }
        }

        // is the site (row, col) open?
        static bool isOpen(int row, int col)
        {
            return arr[row, col] != 0;
        }

        // is the site (row, col) full?
        static bool isFull(int row, int col)
        {
            if (nodes[getIndex(row, col)] == 0)
            {
                arr[row, col] = 2;
            }
            return arr[row, col] == 2;
        }

        // returns the number of open sites
        static int numberOfOpenSites()
        {
            return num_of_opened;
        }

        // does the system percolate?
        static bool percolates()
        {
            return nodes[nodes.Length - 1] == 0;
        }

        // prints the matrix on the screen
        // The method should display different types of sites (open, blocked, full)
        static void print()
        {
            for (int i = 1; i < length; i++)
            {
                for (int j = 1; j < length; j++)
                {
                    if (nodes[getIndex(i, j)] == 0)
                    {
                        arr[i, j] = 2;
                    }
                    Console.Write(arr[i, j]);
                }
                Console.WriteLine();
            }
        }
        static void union(int x, int y)
        {
            int ComponentX = nodes[x];
            int ComponentY = nodes[y];
            if (ComponentX == 0)
            {
                int tmp = ComponentY;
                ComponentY = ComponentX;
                ComponentX = tmp;
            }
            for (int i = 0; i < nodes.Length; i++)
            {
                if (nodes[i] == ComponentX)
                {
                    nodes[i] = ComponentY;
                }
            }

        }
        static int getIndex(int row, int col)
        {
            return (row - 1) * (length - 1) + col;
        }
        static bool initTest()
        {
            init(4);
            for (int i = 1; i < 5; i++)
            {
                for (int j = 1; j < 5; j++)
                {
                    if (arr[i, j] != 0)
                    {
                        Console.WriteLine("initTest: case1 FAILED");
                        return false;
                    }
                }
            }
            init(1);
            for (int i = 1; i < 2; i++)
            {
                for (int j = 1; j < 2; j++)
                {
                    if (arr[i, j] != 0)
                    {
                        Console.WriteLine("initTest: case2 FAILED");
                        return false;
                    }
                }
            }
            init(6);
            for (int i = 1; i < 7; i++)
            {
                for (int j = 1; j < 7; j++)
                {
                    if (arr[i, j] != 0)
                    {
                        Console.WriteLine("initTest: case3 FAILED");
                        return false;
                    }
                }
            }
            Console.WriteLine("isOpenTest: all cases PASSED");
            return true;
        }
        static bool openTest()
        {
            init(5);
            open(1, 1);
            if (arr[1, 1] == 0)
            {
                Console.WriteLine("initTest: case1 FAILED");
                return false;
            }
            open(2, 4);
            if (arr[2, 4] == 0)
            {
                Console.WriteLine("openTest: case2 FAILED");
                return false;
            }
            open(5, 3);
            if (arr[5, 3] == 0)
            {
                Console.WriteLine("openTest: case3 FAILED");
                return false;
            }
            Console.WriteLine("openTest: all cases PASSED");
            return true;
        }
        static bool isOpenTest()
        {
            init(5);
            open(1, 2);
            if (!isOpen(1, 2))
            {
                Console.WriteLine("isOpenTest: case1 FAILED");
                return false;
            }
            open(2, 1);
            if (!isOpen(2, 1))
            {
                Console.WriteLine("isOpenTest: case2 FAILED");
                return false;
            }
            open(3, 3);
            if (!isOpen(3, 3))
            {
                Console.WriteLine("isOpenTest: case3 FAILED");
                return false;
            }
            Console.WriteLine("isOpenTest: all cases PASSED");
            return true;
        }
        static bool isFullTest()
        {
            init(5);
            open(2, 2);
            if (isFull(1, 2))
            {
                Console.WriteLine("isFullTest: case1 FAILED");
                return false;
            }
            open(1, 2);
            if (!isFull(1, 2))
            {
                Console.WriteLine("isFullTest: case2 FAILED");
                return false;
            }
            open(3, 2);
            if (!isFull(3, 2))
            {
                Console.WriteLine("isFullTest: case3 FAILED");
                return false;
            }
            Console.WriteLine("isFullTest: all cases PASSED");
            return true;
        }
        static bool numberOfOpenSitesTest()
        {
            init(5);
            open(1, 2);
            if (numberOfOpenSites() != 1)
            {
                Console.WriteLine("numberOfOpenSitesTest: case1 FAILED");
                return false;
            }
            open(2, 1);
            if (numberOfOpenSites() != 2)
            {
                Console.WriteLine("numberOfOpenSitesTest: case2 FAILED");
                return false;
            }
            open(1, 2);
            if (numberOfOpenSites() != 2)
            {
                Console.WriteLine("numberOfOpenSitesTest: case3 FAILED");
                return false;
            }
            Console.WriteLine("numberOfOpenSitesTest: all cases PASSED");
            return true;
        }
        static bool percolatesTest()
        {
            init(3);
            open(1, 1);
            if (percolates())
            {
                Console.WriteLine("percolatesTest: case1 FAILED");
                return false;
            }
            open(3, 1);
            if (percolates())
            {
                Console.WriteLine("percolatesTest: case2 FAILED");
                return false;
            }
            open(2, 1);
            if (!percolates())
            {
                Console.WriteLine("percolatesTest: case3 FAILED");
                return false;
            }
            Console.WriteLine("percolatesTest: all cases PASSED");
            return true;
        }
        static bool unionTest()
        {
            init(3);
            union(0, 3);
            if (nodes[0] != nodes[3])
            {
                Console.WriteLine("unionTest: case1 FAILED");
                return false;
            }
            union(1, 4);
            if (nodes[1] != nodes[4])
            {
                Console.WriteLine("unionTest: case2 FAILED");
                return false;
            }
            union(3, 1);
            if (nodes[0] != nodes[3] || nodes[0] != nodes[1] || nodes[0] != nodes[4])
            {
                Console.WriteLine("unionTest: case3 FAILED");
                return false;
            }
            Console.WriteLine("unionTest: all cases PASSED");
            return true;
        }
        static bool getIndexTest()
        {
            init(4);
            if (getIndex(1, 3) != 3)
            {
                Console.WriteLine("getIndexTest: case1 FAILED");
                return false;
            }
            if (getIndex(2, 3) != 7)
            {
                Console.WriteLine("getIndexTest: case2 FAILED");
                return false;
            }
            if (getIndex(4, 2) != 14)
            {
                Console.WriteLine("getIndexTest: case3 FAILED");
                return false;
            }
            Console.WriteLine("getIndexTest: all cases PASSED");
            return true;
        }
        static void Main(String[] args)
        {
            bool initTestResult = initTest();
            bool openTestResult = openTest();
            bool isOpenTestResult = isOpenTest();
            bool isFullTestResult = isFullTest();
            bool numberOfOpenSitesTestResult = numberOfOpenSitesTest();
            bool percolatesTestResult = percolatesTest();
            bool unionTestResult = unionTest();
            bool getIndexTestResult = getIndexTest();
            string s = "";
            int x, y;

            while (s != "stop")
            {
                s = Console.ReadLine();
                if (s == "init")
                {
                    x = Convert.ToInt32(Console.ReadLine());
                    init(x);
                }
                if (s == "open")
                {
                    x = Convert.ToInt32(Console.ReadLine());
                    y = Convert.ToInt32(Console.ReadLine());
                    open(x, y);
                }
                if (s == "isOpen")
                {
                    x = Convert.ToInt32(Console.ReadLine());
                    y = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(isOpen(x, y));
                }
                if (s == "isFull")
                {
                    x = Convert.ToInt32(Console.ReadLine());
                    y = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(isFull(x, y));
                }
                if (s == "numberOfOpenSites")
                {
                    Console.WriteLine(numberOfOpenSites());
                }
                if (s == "percolates")
                {
                    Console.WriteLine(percolates());
                }
                if (s == "print")
                {
                    print();
                }
            }
        }
    }

}