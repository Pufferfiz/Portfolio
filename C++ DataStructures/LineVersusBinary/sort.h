/*
 * sort.h
 *
 *  Created on: Oct 15, 2011
 *      Author: Kendal
 */

#ifndef SORT_H_
#define SORT_H_

class sort
{
public:
	sort();
	void print(int* array,int size);
	void quickSort(int* array,int startIndex, int endIndex);
	int SplitArray(int* array, int pivotValue, int startIndex, int endIndex);
	virtual ~sort();

private:
	int* thearray;
	int theSize;

	void swap(int &aInt, int &bInt);

};


#endif /* SORT_H_ */
