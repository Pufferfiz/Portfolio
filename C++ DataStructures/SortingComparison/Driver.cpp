/*
 *
 * University of Advancing Technology Standard C++ Template Driver
 *
 * Name: Driver.cpp
 * Student: Kendal Cormany
 *
 */

#include "StandardIncludes.h"
#include "selcSort.h"
#include "insertSort.h"
#include "mergSort.h"

void fillWithWithRandomNumbers(int* array, int arraySize)
{
	srand(time(NULL));
	for (int index = 0; index < arraySize; ++index)
	{
		array[index] = rand() % arraySize + 1;
	}
}

int main()
{
	selcSort selcSorter;
	insertSort insertSorter;
	mergSort mergeSorter;
	int array[6] = {0,5,3,1,2,4};
	//fillWithWithRandomNumbers(array,6);
	int temp[6];
	int size = 6;
	int zero = 0;
	mergeSorter.run(array,temp,size);
	mergeSorter.print(array,6);
	// Define your code here
	return 0;
}
