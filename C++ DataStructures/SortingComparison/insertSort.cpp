/*
 * sort.cpp
 *
 *  Created on: Oct 15, 2011
 *      Author: Kendal
 */

#include "StandardIncludes.h"
#include "insertSort.h"


insertSort::insertSort()
{

}

insertSort::~insertSort()
{

}


void insertSort::swap(int &aInt, int &bInt)
{
	int temp;
	temp = aInt;
	aInt = bInt;
	bInt = temp;

}

void insertSort::insertionSort(int* array, int startIndex, int endIndex)
{
	int aIndex;
	int bIndex;
	for(aIndex =1; aIndex < endIndex; aIndex++)
	{
		bIndex = aIndex;
		while(bIndex>0 && array[bIndex - 1] > array[bIndex])
		{
			swap(array[bIndex],array[bIndex - 1]);
			bIndex--;
		}
	}

}




void insertSort::print(int * array, int size)
{
	for (int var = 0; var < size; ++var)
		{
			cout << array[var] << endl;

		}
}



