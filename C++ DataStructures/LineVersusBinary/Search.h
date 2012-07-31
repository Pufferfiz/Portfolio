/*
 * Search.h
 *
 *  Created on: Oct 26, 2011
 *      Author: kencorma
 */

#ifndef SEARCH_H_
#define SEARCH_H_

class Search
{
public:
	Search();
	int linarSearch(int* array,int size, int lookingFor);
	int binarySearch(int* array,int &searchval, int left , int right);
	virtual ~Search();
};

#endif /* SEARCH_H_ */
