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
	void print();
	void setArray(int array[]);
	void setSize(int size);
	int* getArray();
	void run();
	virtual ~sort();

private:
	int* thearray;
	int theSize;
	void shiftDown(int start);
	void heapify();
	void heapSort();
	int left(int root);
	int right(int root);
	void swap(int lowValue, int highValue);

};


#endif /* SORT_H_ */
