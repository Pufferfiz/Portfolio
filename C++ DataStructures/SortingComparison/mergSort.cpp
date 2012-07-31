/*
 * sort.cpp
 *
 *  Created on: Oct 15, 2011
 *      Author: Kendal
 */

#include "StandardIncludes.h"
#include "mergSort.h"


mergSort::mergSort()
{
	theSize = 6;
}

mergSort::~mergSort()
{

}


void mergSort::swap(int &aInt, int &bInt)
{
	int temp;
	temp = aInt;
	aInt = bInt;
	bInt = temp;

}


void mergSort::run(int* array,int* temp,int size)
{
	mergeSort(array,temp,0,size-1);
}


void mergSort::mergeSort(int* array,int* temp,int low, int high)
{
	int mid;
	if (high > low)
	{
		cout << "one pass" <<endl;
		mid = (high+low)/2;
		mergeSort(array,temp,low,mid);
		mergeSort(array,temp,mid +1 ,high);
		merge(array,temp,low,mid,high);
	}

}


void mergSort::merge(int* array,int* temp,int low, int mid, int high)
{
	int lowEnd,size,pos;
	//lowEnd = mid -1;
	int highEnd = mid + 1;
	pos = 0;
	size = high - low + 1;

	while((low<=mid) && (highEnd<=high))
	{
		if(array[low] < array[highEnd])
		{
			temp[pos] = array[low];
			pos++;
			low++;
		}
		else
		{
			temp[pos] = array[highEnd];
			pos++;
			highEnd++;
		}
	}
	while (low <= mid)
	{
		temp[pos] = array[low];
		pos++;
		low++;
	}

	while (highEnd  <= high)
	{
		temp[pos] = array[highEnd];
		pos++;
		highEnd++;
	}

	for (int index = low; index < high; ++index)
	{
		array[index] = temp[index - low];
		high--;
	}


}


void mergSort::print(int * array, int size)
{
	for (int var = 0; var < size; ++var)
		{
			cout << array[var] << endl;

		}
}



