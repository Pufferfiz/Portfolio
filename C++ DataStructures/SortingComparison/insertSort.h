/*
 * sort.h
 *
 *  Created on: Oct 15, 2011
 *      Author: Kendal
 */

#ifndef INSERTSORT_H_
#define INSERTSORT_H_

class insertSort
{
public:
	insertSort();
	void print(int* array,int size);
	void insertionSort(int* array,int startIndex, int endIndex);
	virtual ~insertSort();

private:
	int* thearray;
	int theSize;

	void swap(int &aInt, int &bInt);

};


#endif /* INSERTSORT_H_ */
