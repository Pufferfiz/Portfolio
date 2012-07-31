/*
 * myString1.cpp
 *
 *  Created on: Nov 11, 2011
 *      Author: kencorma
 */

#include "myString1.h"

myString1::myString1(string inString)
{
	// TODO Auto-generated constructor stub
	myString = inString;
	setHash();
}

myString1::~myString1()
{
	// TODO Auto-generated destructor stub
}


void myString1::setString(string inString)
{
	myString = inString;
}

string myString1::getString()
{
	return myString;
}

int myString1::getHash() const
{
	return hash;
}

void myString1::setHash()
{
	hash = 0;
	for (int var = 0; var < myString.size(); ++var)
	{
		hash += int(myString[var]);
	}
	hash *= 31;
}

bool myString1::operator ==(const myString1& inString)
{

	if (inString.getHash() == hash)
		{
			return true;
		}
		else
			return false;
}
