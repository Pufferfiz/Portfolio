/*
 * MyString2.h
 *
 *  Created on: Nov 11, 2011
 *      Author: kencorma
 */

#ifndef MYSTRING2_H_
#define MYSTRING2_H_
#include "StandardIncludes.h"

class MyString2
{
public:
	MyString2();
	MyString2(string inString);
	virtual ~MyString2();
	void setString(string inString);
	string getString();
	int getHash() const;
	bool operator==(const MyString2 &rhs);

private:
	string myString;
	int hash;
	void setHash();

};

#endif /* MYSTRING2_H_ */
