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

void sort::setSize(int size)
{
	theSize = size;
}

int sort::left(int root)
{
	return root * 2 + 1;
}

int sort::right(int root)
{
	return left(root) + 1;
}

void sort::swap(int lowValue, int highValue)
{
	int temporary = thearray[lowValue];
	thearray[lowValue] = thearray[highValue];
	thearray[highValue] = temporary;
}

void sort::shiftDown(int start)
{
	int root = start;
	int large = root;
	int l = left(root);

	int r = right(root);

	if((l <= theSize) && thearray[l] > (thearray[root]))

	{
		large = l;
	}
	else
	{
		large = start;
	}

	if((r <= theSize) && thearray[r] > (thearray[large]))
	{
		large = r;
	}
	if(large != root)
	{
		swap(root,large);
		shiftDown(large);
	}


}


void sort::heapify()
{
	int start = theSize / 2 - 1;
	while(start >= 0)
	{
		shiftDown(start);
		start--;
	}
}



void sort::heapSort()
{
	heapify();
	int end = theSize;
 	while (end > 0)
 	{
 		int temporary = thearray[0];
 		thearray[0] = thearray[end - 1];
 			thearray[end - 1] = temporary;
 		end  = end -1;
 		shiftDown(0);
 	}
}

void sort::setArray(int array[])
{
	thearray = array;
}


void sort::print()
{
	for (int var = 0; var < theSize; ++var)
		{
			cout << thearray[var] << endl;
		}
}

int* sort::getArray()
{
	return thearray;
}

void sort::run()
{
	heapSort();
}

