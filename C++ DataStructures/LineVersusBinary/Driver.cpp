/*
 *
 * University of Advancing Technology Standard C++ Template Driver
 *
 * Name: Driver.cpp
 * Student: Kendal Cormany
 *
 */

#include "StandardIncludes.h"
#include "search.h"
#include "sort.h"

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
	int array[100000];
	fillWithWithRandomNumbers(array,100000);
	int whatIamLookingFor = 9434;
	sort sorter;
	sorter.quickSort(array,0,99999);
	Search searcher;
	cout << "9434 is at index: " << searcher.linarSearch(array,100000,9434) << endl;
	cout << "9434 is at index: " << searcher.binarySearch(array,whatIamLookingFor,0,100000) << endl;
	cout << "Check it: " << array[searcher.binarySearch(array,whatIamLookingFor,0,100000)] << endl;
	cout << "Check it: " << array[searcher.linarSearch(array,100000,9434)];



	return 0;
}
