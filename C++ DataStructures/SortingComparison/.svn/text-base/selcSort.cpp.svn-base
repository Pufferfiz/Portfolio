/*
 * sort.cpp
 *
 *  Created on: Oct 15, 2011
 *      Author: Kendal
 */

#include "StandardIncludes.h"
#include "selcSort.h"


selcSort::selcSort()
{

}

selcSort::~selcSort()
{

}


void selcSort::swap(int &aInt, int &bInt)
{
	int temp;
	temp = aInt;
	aInt = bInt;
	bInt = temp;

}

void selcSort::selectSort(int* array, int startIndex, int endIndex)
{
	for (int index = 0; index < endIndex; ++index)
	{
		for (int bIndex = 0; bIndex < endIndex; ++bIndex)
		{
			if (array[bIndex] < array[index])
			{
				swap(array[bIndex],array[index]);
			}
		}
	}

}




void selcSort::print(int * array, int size)
{
	for (int var = 0; var < size; ++var)
		{
			cout << array[var] << endl;

		}
}



