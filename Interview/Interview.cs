using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewQuestions
{
    public class Interview
    {
        public static void Main(String[] args)
        {
            Interview interview = new Interview();

            //#1 reverse a string
            String a = "";
            Console.WriteLine("Please type the word you wish to reverse.");
            a = Console.ReadLine();

            Console.WriteLine("This is the word you entered: " + a);
            String rev = interview.reverse(a);
            Console.WriteLine("The reverse of the word is : " + rev);
            bool testPalindrome = interview.palindrome(a);
            Console.WriteLine("Is the string you entered a palindrome?" + testPalindrome);

            //#2 most freq int in an array
            int[] testArray = { 1, 1, 2, 2, 3, 3, 7, 7, 8, 8, 9, 9, 10, 10, 11 };
            Console.Write("These are the values in the array: \n" + testArray[0]);
            for (int i = 1; i < testArray.Length; i++)
            {
                Console.Write(" , " + testArray[i]);
            }
            Console.WriteLine("");
            int freq = interview.freqInt(testArray);
            Console.WriteLine("The most frequent int in the array: \n" + freq);

            //#3 Find the only element in an array that only occurs once.
            //using testArray again.
            int x = interview.occursOnce(testArray);
            Console.WriteLine("This value only occurs once in the array: " + x);

            //#4 Find the common elements of 2 int arrays
            //using test array again.
            int[] comm = new int[100];
            int[] testArray2 = { 1, 3, 5, 7, 9, 11, 13 };
            Console.Write("This is the elements in testArray2: \n" + testArray2[0]);
            for (int i = 1; i < testArray2.Length; i++)
            {
                Console.Write(" , " + testArray2[i]);
            }
            Console.WriteLine("");
            Console.WriteLine("This is the common elements found in both arrays: ");
            interview.commonElements(testArray, testArray2);

            //#5 fibbonaci iteratively and recursively 
            int[] fibArray = interview.fibbITER(10);
            Console.WriteLine();
            Console.Write("This is the fibb array iterative with input of 10: \n" + fibArray[0]);
            for (int i = 1; i < fibArray.Length; i++)
            {
                Console.Write(" , " + fibArray[i]);
            }
            Console.WriteLine("");
            Console.Write("This is the fibb array recursive with input of 10: ");
            Console.WriteLine("");
            int n = 10;
            for (int i = 0; i < n; i++)
            {
                if (i == 0)
                {
                    Console.Write(interview.fibbRECUR(i));
                }
                else
                {
                    Console.Write(" , " + interview.fibbRECUR(i));
                }
            }
            Console.WriteLine("");

            //#6 Implement binary search of a sorted array of integers.
            interview.binarySearch(8, testArray);

            //#7 Find unique elements of one array in comparison to another array
            Console.WriteLine("This is the unique values in testArray not contained in testArray2: ");
            interview.uniqueElements(testArray, testArray2);

            //#8 Remove duplicates from array
            Console.WriteLine("");
            Console.WriteLine("This is the array after duplicates are removed");
            int[] dupRemoved = interview.removeDuplicates(testArray);
            foreach (int i in dupRemoved)
            {
                Console.Write(i + " , ");
            }

            //keep console open
            Console.ReadKey();
        }

        private int[] removeDuplicates(int[] testArray)
        {
            HashSet<int> map = new HashSet<int>();
  
            foreach (int i in testArray)
            {
                map.Add(i);
            }
            
            int[] temp = new int[map.Count];
            //this copies values from hashset to the array
            map.CopyTo(temp);
            

            return temp;
        }


        /**
         * Reverses string a and stores the value in b, which is returned. 
         * @param a
         * @return b
         */
        public string reverse(string a)
        {
            StringBuilder b = new StringBuilder("");
            if (a == null)
            {
                Console.WriteLine("Error: The string is null.");
            }
            else if (a.Length == 1)
            {
                return a;
            }
            else
            {
                for (int i = a.Length - 1; i >= 0; i--)
                {

                    b = b.Append(a[i]);
                }

            }

            return b.ToString();

        }

        /**
         * searches array to find value requested using binarySearch
         * @param a
         * @param b
         */
        public void binarySearch(int a, int[] b)
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
         * Find all the common elements of 2 arrays. Fastest way is to use Hash set. 
         * @param testArray
         * @param testArray2
         */
        public void commonElements(int[] testArray, int[] testArray2)
        {
            HashSet<int> map = new HashSet<int>();
            foreach(int i in testArray){
                map.Add(i);
            }
            foreach (int i in testArray2)
            {
                if (map.Contains(i))
                {
                    Console.Write(i + " ");
                }
            }
        }

        /**
         * Find all the elements not shared by the 2 arrays. Fastest way is to use Hash set. 
         * @param testArray
         * @param testArray2
         */
        public void uniqueElements(int[] testArray, int[] testArray2)
        {
            HashSet<int> map = new HashSet<int>();
            HashSet<int> map2 = new HashSet<int>();
            foreach (int i in testArray)
            {
                map.Add(i);
            }
            foreach (int i in testArray2)
            {
                map2.Add(i);
            }
            
            //this removes all items from map that aren't shared with map2. It runs in O(n) so pretty efficient 
            map.ExceptWith(map2);
            
            foreach (int i in map)
            {
                Console.Write(i + " ");
            }
        }

        /**
         * Find the most frequent integer in an array 
         * 
         */
        public int freqInt(int[] a)
        {

            int current = 0;
            int prev = a[0];
            int countCurrent = 1;
            int countPrevious = 0;
            int best = 0;

            if (a == null)
            {
                return -1;
            }
            else if (a.Length == 1)
            {
                return a[0];
            }
            else
            {
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
        }

        /**
         * iterative method fibbonaci sequence of length n. returns array
         * @param n
         * @return a
         */
        public int[] fibbITER(int len)
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
        public int fibbRECUR(int n)
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
        public int occursOnce(int[] a)
        {
            int val = 0;
            if(a == null){
                return -1;
            }
            else if (a.Length == 1)
            {
                return a[0];
            }
            else
            {
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
            }
            return val;
        }

        /*
         * This method checks if the string is a palindrome. Uses the previously built method reverse()
         *
        */
        public Boolean palindrome(String a)
        {
            if(a == null){
                return false;
            }
            else if(a.Length == 1){
                return true;
            }
            else{
                String b = reverse(a);
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] != b[i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }




    }
}