/*
 * myString1.h
 *
 *  Created on: Nov 11, 2011
 *      Author: kencorma
 */

#ifndef MYSTRING1_H_
#define MYSTRING1_H_
#include "StandardIncludes.h"

class myString1
{
public:
	myString1(string inString);
	virtual ~myString1();
	void setString(string inString);
	string getString();
	int getHash() const;
	bool operator==(const myString1& rhs);

private:
	string myString;
	void setHash();
	int hash;
};

#endif /* MYSTRING1_H_ */
