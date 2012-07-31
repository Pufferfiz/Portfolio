/*
 * Search.cpp
 *
 *  Created on: Oct 26, 2011
 *      Author: kencorma
 */

#include "Search.h"
#include "StandardIncludes.h"

Search::Search()
{
	// TODO Auto-generated constructor stub

}

Search::~Search()
{
	// TODO Auto-generated destructor stub
}


int Search::linarSearch(int* array, int size, int lookingFor)
{
	int index;
	for (index = 0; index < size; ++index)
	{
		if (array[index] == lookingFor)
		{
			break;
		}

	}
	if (index == size)
	{
		index = -1;
	}
	return index;

}

int Search::binarySearch(int *array, int &lookingFor, int left, int right)
{
	int middle = (right + left) / 2;
	if (array[left] == lookingFor)
	{
		return left;
	}
	if (array[right] == lookingFor)
	{
		return right;
	}
	if (array[middle] == lookingFor)
	{
		return middle;
	}
	if ((left + right) < 2)
	{
		return -1;
	}
	if (lookingFor > array[middle])
	{
		binarySearch(array,lookingFor,middle,right);
	}
	if (lookingFor < array[middle])
	{
		binarySearch(array,lookingFor,left,middle);
	}
}
