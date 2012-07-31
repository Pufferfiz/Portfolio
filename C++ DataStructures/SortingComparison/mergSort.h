/*
 * sort.h
 *
 *  Created on: Oct 15, 2011
 *      Author: Kendal
 */

#ifndef MERGSORT_H_
#define MERGSORT_H_

class mergSort
{
public:
	mergSort();
	void print(int* array,int size);
	void run(int* array,int* temp,int size);
	void mergeSort(int* array,int* temp,int low, int high);
	void merge(int* array,int* temp,int low, int mid, int high);
	virtual ~mergSort();

private:
	int* thearray;
	int theSize;

	void swap(int &aInt, int &bInt);

};


#endif /* MERGSORT_H_ */
