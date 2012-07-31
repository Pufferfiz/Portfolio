/*
 * HashTable.h
 *
 *  Created on: Nov 11, 2011
 *      Author: kencorma
 */

#ifndef HASHTABLE_H_
#define HASHTABLE_H_

#include "StandardIncludes.h"
template<class T>
class HashTable
{
public:
	HashTable();
	HashTable(int inSize);
	virtual ~HashTable();
	int getSize();
	T operator[](string inString);
	void write(T Object);
private:
	vector<T> hashVector;
	int hashFunction(T object);
	int size;

};

#endif /* HASHTABLE_H_ */


template<class T>
HashTable<T>::HashTable()
{

}

template<class T>
HashTable<T>::HashTable(int inSize) : hashVector(inSize)
{
	size = inSize;
	T object("");
	for (int var = 0; var < inSize; ++var)
	{

		hashVector[var] = object;
	}
}

template<class T>
HashTable<T>::~HashTable()
{

}

template<class T>
int HashTable<T>::getSize()
{
	return size;
}

template<class T>
int HashTable<T>::hashFunction(T object)
{
	return object.getHash();
}

template<class T>
T HashTable<T>::operator [](string inString)
{
	T object(inString);
	int hash = object.getHash();
	T blank("");

	if (blank == hashVector[hash])
	{
		write(object);
	}
	else
	{
		if (object == hashVector[hash])
		{
		return hashVector[hash];
		}
		else
		{
		int count = 0;
		while (count <= 0)
			{
				if (hashVector[hash + (count*2)] == blank)
				{
					return hashVector[hash + (count*2)];
					count ++;
				}
				else
				{
					count--;

				}

			}
		}
	}
	//return hashVector[hash];

}

template<class T>
void HashTable<T>::write(T Object)
{
	int count = 0;
	int hash = hashFunction(Object);
	T blank("");
	if (hash > size)
	{
		hash %= size;
	}
	while (count <= 0)
	{
		if (hashVector[hash + (count*2)] == blank)
		{
			hashVector[hash + (count*2)] = Object;
			count ++;
		}
		else
		{
			count--;

		}

	}

}
