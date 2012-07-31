/*
 * MyString2.cpp
 *
 *  Created on: Nov 11, 2011
 *      Author: kencorma
 */

#include "MyString2.h"

MyString2::MyString2(string inString)
{
	myString = inString;
	setHash();

}

MyString2::MyString2()
{

}

MyString2::~MyString2()
{

}

void MyString2::setString(string inString)
{
	myString = inString;
	setHash();
}

string MyString2::getString()
{
	return myString;
}



void MyString2::setHash()
{
	hash = 0;
	for (int var = 0; var < myString.size(); ++var)
	{
		hash += int(myString[var]);
	}
}

int MyString2::getHash() const
{
	return hash;
}

bool MyString2::operator==(const MyString2 &inString)
{

	if (inString.getHash() == hash)
	{
		if( myString == inString.getString())
		{
		return true;
		}
	}
	else
		return false;
}



