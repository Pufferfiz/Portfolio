/*
 * sort.cpp
 *
 *  Created on: Oct 15, 2011
 *      Author: Kendal
 */

#include "StandardIncludes.h"
#include "sort.h"


sort::sort()
{

}

sort::~sort()
{

}


void sort::swap(int &aInt, int &bInt)
{
	int temp;
	temp = aInt;
	aInt = bInt;
	bInt = temp;

}

void sort::quickSort(int* array, int startIndex, int endIndex)
{
	int pivot = array[startIndex];
	int splitPoint;
	if (endIndex > startIndex)
	{
		splitPoint = SplitArray(array,pivot,startIndex,endIndex);
		array[splitPoint] = pivot;
		quickSort(array,startIndex,splitPoint-1);
		quickSort(array,splitPoint+1,endIndex);
	}
	thearray = array;

}

int sort::SplitArray(int* array, int pivotValue, int startIndex, int endIndex)
{
	int leftBound = startIndex;
	int rightBound = endIndex;

	while (leftBound < rightBound)
	{
		while (pivotValue < array[rightBound] && rightBound > leftBound)
		{
			rightBound--;
		}
		swap(array[leftBound],array[rightBound]);
		while(pivotValue >= array[leftBound]  && leftBound < rightBound)
		{
			leftBound++;
		}
		swap(array[rightBound],array[leftBound]);
	}
	return  leftBound;
}


void sort::print(int * array, int size)
{
	for (int var = 0; var < size; ++var)
		{
			cout << array[var] << endl;

		}
}



