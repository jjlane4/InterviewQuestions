using System;

namespace InterviewQuestions
{
    public class Interview
    {
        public static void Main(String[] args)
        {
            //#1 reverse a string
            String a = "";
            Console.WriteLine("Please type the word you wish to reverse.");
            a = Console.ReadLine();

            String rev = reverse(a);
            Console.WriteLine("The reverse of the string is : " + rev);

            //#2 most freq int in an array
            int[] testArray = { 1, 1, 2, 2, 3, 3, 7, 7, 8, 8, 9, 9, 10, 10, 11 };
            int freq = freqInt(testArray);
            Console.WriteLine("The most frequent int in the array: " + freq);

            //#3 fibbonaci iteratively and recursively 
            int[] fibArray = fibbITER(10);
            Console.WriteLine();
            Console.WriteLine("This is the fibb array iter: ");
            for (int i = 0; i < fibArray.Length; i++)
            {
                Console.WriteLine(fibArray[i] + " ");
            }
            Console.WriteLine("");
            Console.WriteLine("This is the fibb array recur:");
            int n = 10;
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(fibbRECUR(i) + " ");
            }

            //#4 Find the only element in an array that only occurs once.
            //using testArray again.
            int x = 0;
            x = occursOnce(testArray);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("This value only occurs once in the array: " + x);

            //#5 Find the common elements of 2 int arrays
            //using test array again.
            Console.WriteLine("This is the common elements found in testArray2");
            int[] comm = new int[100];
            int[] testArray2 = { 1, 3, 5, 7, 9, 11, 13 };
            commonElements(testArray, testArray2);

            //#6 Implement binary search of a sorted array of integers.
            binarySearch(8, testArray);

            //#7 Implement binary search in a rotated array {5,6,7,8,1,2,3}
            int[] rotArray = new int[] { 5, 6, 7, 8, 1, 2, 3 };
            int[] storedA = new int[rotArray.Length];
            storedA = sexySort(rotArray);
            binarySearch(6, rotArray);

        }


        /**
         * Reverses string a and stores the value in b, which is returned. 
         * @param a
         * @return b
         */
        public static string reverse(string a)
        {
            String b = "";
            for (int i = a.Length - 1; i >= 0; i--)
            {

                b = b + a[i];
            }


            return b;

        }

        /**
	 * sorts a rotated array 
	 * @param s
	 * @return
	 */
        public static int[] sexySort(int[] s)
        {
            int saveV = 0;
            int[] tempA = new int[s.Length];


            for (int i = 1; i < s.Length - 1; i++)
            {
                if (s[i] < s[i - 1])
                {
                    saveV = i;
                    break;
                }
            }

            for (int i = 0; i < tempA.Length; i++)
            {

            }

            return tempA;
        }

        /**
         * searches array to find value requested using binarySearch
         * @param a
         * @param b
         */
        public static void binarySearch(int a, int[] b)
        {
            int high = b.Length - 1;
            int low = 0;
            int key = -1;
            int mid;
            while (high >= low)
            {
                mid = (low + high) / 2;
                if (a == b[mid])
                {
                    key = b[mid];
                    break;
                }
                if (b[mid] < a)
                {
                    low = mid + 1;
                }
                if (b[mid] > a)
                {
                    high = mid - 1;
                }
            }
            Console.WriteLine("The expected value is : " + key);

        }

        /**
         * Find all the common elements of 2 arrays
         * @param testArray
         * @param testArray2
         */
        public static void commonElements(int[] testArray, int[] testArray2)
        {
            int temp = 0;
            Array.Sort(testArray);
            temp = testArray[0];

            for (int i = 0; i < testArray.Length; i++)
            {
                if (i == 0)
                {
                    for (int j = 0; j < testArray2.Length; j++)
                    {
                        if (j == 0)
                        {
                            if (testArray[i] == testArray2[j])
                            {
                                Console.WriteLine(testArray[i]);
                            }
                        }
                        else
                        {
                            if (testArray[i] == testArray2[j] && testArray2[j] != testArray2[j - 1])
                            {
                                Console.WriteLine(testArray[i]);
                            }
                        }
                    }
                }
                else
                {
                    if (testArray[i] != testArray[i - 1])
                    {
                        for (int j = 0; j < testArray2.Length; j++)
                        {
                            if (j == 0)
                            {
                                if (testArray[i] == testArray2[j])
                                {
                                    Console.WriteLine(testArray[i]);
                                }
                            }
                            else
                            {
                                if (testArray[i] == testArray2[j] && testArray2[j] != testArray2[j - 1])
                                {
                                    Console.WriteLine(testArray[i]);
                                }
                            }
                        }
                    }
                }
            }

        }

        /**
         * Find the most frequent integer in an array 
         * 
         */
        public static int freqInt(int[] a)
        {

            int current = 0;
            int prev = a[0];
            int countCurrent = 1;
            int countPrevious = 0;
            int best = 0;

            Array.Sort(a);

            for (int i = 1; i < a.Length; i++)
            {
                current = a[i];
                if (current == prev)
                {
                    countCurrent++;
                }
                else
                {
                    if (countCurrent > countPrevious)
                    {
                        countPrevious = countCurrent;
                        best = a[i - 1];
                    }

                    countCurrent = 1;
                    prev = a[i];

                }
            }

            if (countCurrent > best)
            {
                return a[a.Length - 1];
            }
            else
            {
                return best;
            }

        }

        /**
         * iterative method fibbonaci sequence of length n. returns array
         * @param n
         * @return a
         */
        public static int[] fibbITER(int len)
        {
            int[] a = new int[len];


            if (len > 0)
            {
                a[0] = 0;
            }
            if (len > 1)
            {
                a[1] = 1;
            }

            for (int i = 2; i < a.Length; i++)
            {
                a[i] = a[i - 2] + a[i - 1];
            }

            return a;
        }

        /**
         * Recursive method for fibbonaci sequence of length n. returns values.
         * @param n
         * @return
         */
        public static int fibbRECUR(int n)
        {

            if (n == 0)
            {
                return 0;
            }
            else if (n == 1)
            {
                return 1;
            }
            else
            {
                return fibbRECUR(n - 1) + fibbRECUR(n - 2);
            }
        }

        /**
         * Find a single occurrence of an int(assuming only one number is used only once).
         * n^2 is the easiest. Trying for faster.
         * @param a
         * @return val
         */
        public static int occursOnce(int[] a)
        {
            int val = 0;

            //possibilities: n^2; or sort the array and go through array once checking; 
            //or go through deleting checked values

            Array.Sort(a);
            if (a[0] != a[1])
            {
                return a[0];
            }

            for (int i = 1; i < a.Length - 1; i++)
            {
                if (a[i] != a[i - 1] && a[i] != a[i + 1])
                {
                    val = a[i];
                    break;
                }
            }

            if (a[a.Length - 1] != a[a.Length - 2])
            {
                return a[a.Length - 1];
            }
            return val;
        }




    }
}