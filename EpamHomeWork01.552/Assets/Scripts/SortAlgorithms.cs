using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortAlgorithms {


    public static void BubbleSort(int[] array)
    {
        int n = array.Length;

        bool swapMade = false;

        for (int i = 0; i < n-1; i++)
        {
            swapMade = false;
            for(int j = n-1; j > i; j--)
            {
                if (array[j] < array[j - 1])
                {
                    Swap(array, i, j);
                    swapMade = true;
                }

            }


            if (!swapMade)
            {
                break;
            }
        }
    }


    private static void Swap(int[] array, int i, int j)
    {
        int tmp = array[i];
        array[i] = array[j];
        array[j] = tmp;
    }

    //////////////////////////////////////////////////////////////////////////////////////


    public static void MergeSort(int[] array)
    {
        MergeSort(array, 0, array.Length);
    }


    /**
     * start inclusive
     * finish exclusive
     */
    private static void MergeSort(int[] array, int start, int finish)
    {

        if ((finish - start) <= 1)
        {
            return;
        }
        int mid = start + (finish - start) / 2;

        MergeSort(array, start, mid);
        MergeSort(array, mid, finish);

        Merge(array, start, mid, finish);
    }

    private static void Merge(int[] array, int start, int mid, int finish)
    {
        int index1 = start;
        int index2 = mid;
        int len = finish - start;

        if (len <= 1)
        {
            return;
        }

        int auxPtr = 0;
        int[] aux = new int[len];

        while (index1 < mid && index2 < finish)
        {
            if (array[index1] < array[index2])
            {
                aux[auxPtr] = array[index1];
                auxPtr++;
                index1++;
            }
            else
            {
                aux[auxPtr] = array[index2];
                auxPtr++;
                index2++;
            }
        }
        while (index1 < mid)
        {
            aux[auxPtr] = array[index1];
            index1++;
        }
        while (index2 < finish)
        {
            aux[auxPtr] = array[index2];
        }

        for (int l = 0; l < len; l++)
        {
            array[start + l] = aux[l];
        }
    } // merge() //

    //////////////////////////////////////////////////////////////////////////////////////
    
    public static void Quick3WaySort(int[] array)
    {
        Quick3WaySort(array, 0, array.Length);
    }

    

    public static void Quick3WaySort(int[] array, int start, int finish)
    {
        if (finish - start <= 2)
        {
            if (array[start] > array[finish - 1])
            {
                Swap(array, start, finish - 1);
            }
            return;
        }

        int cl = 0;
        int cr = 0;
       
        Partition(array, start, finish, ref cl, ref cr);

        Quick3WaySort(array, start, cl);
        Quick3WaySort(array, cr, finish);
    }



    public static void Partition(int[] array, int start, int finish, ref int cl, ref int cr)
    {
        

        int pivot = array[start];
        cl = start;
        cr = start + 1;

        int right = finish - 1;

        while (cr < right) // ????
        {
            while (cr < finish && array[cr] <= pivot)
            {
                if (array[cr] == pivot)
                {
                    cr++;
                }
                else
                {
                    Swap(array, cl, cr);
                    cl++;
                    cr++;
                }
            }

            while(array[right] > pivot && cr < right)
            {
                right --;
            }

            if (cr < right)
            {
                Swap(array, cr, right);
            }

        } // global while //

    }



}
