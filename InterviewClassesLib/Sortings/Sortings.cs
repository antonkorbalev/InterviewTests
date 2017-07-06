using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewClassesLib.Sortings
{
    public static class Sortings
    {
        /// <summary>
        /// Сортировка вставками
        /// </summary>
        /// <param name="arr">Массив для сортировки</param>
        public static void InsertionSort(int[] arr)
        {
            int curr;
            int i, j;
            for (i = 0; i < arr.Length; i++)
            {
                curr = arr[i];
                for (j = i; j > 0 && arr[j - 1] > curr; j--)
                {
                    arr[j] = arr[j - 1];
                }
                arr[j] = curr;
            }
        }

        /// <summary>
        /// Пузырьковая сортировка
        /// </summary>
        /// <param name="arr">Массив для сортировки</param>
        /// <returns></returns>
        public static int[] BubbleSort(int[] arr)
        {
            for (var i = 0; i < arr.Length; i++)
                for (var j = 0; j < arr.Length - i - 1; j++)
                    if (arr[j] > arr[j + 1])
                    {
                        var temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
            return arr;
        }

        /// <summary>
        /// Сортировка выборками
        /// </summary>
        /// <param name="arr">Массив для сортировки</param>
        public static void SelectionSort(int[] arr)
        {
            int minIdx;
            int tmp;
            for (int i = 0; i < arr.Length; i++)
            {
                minIdx = i;
                for (int j = i; j < arr.Length; j++)
                {
                    if (arr[j] < arr[minIdx])
                    {
                        minIdx = j;
                    }
                }
                tmp = arr[i];
                arr[i] = arr[minIdx];
                arr[minIdx] = tmp;
            }
        }

        /// <summary>
        /// Быстрая сортировка
        /// </summary>
        /// <param name="arr">Массив для сортировки</param>
        public static void QuickSort(int[] arr)
        {
            QuickSort(arr, 0, arr.Length - 1);
        }

        private static void QuickSort(int[] arr, int l, int r)
        {
            int temp;
            int x = arr[l + (r - l) / 2];
            int i = l;
            int j = r;

            while (i <= j)
            {
                while (arr[i] < x) i++;
                while (arr[j] > x) j--;
                if (i <= j)
                {
                    temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                    i++;
                    j--;
                }
            }
            if (i < r)
                QuickSort(arr, i, r);

            if (l < j)
                QuickSort(arr, l, j);
        }
    }
}
