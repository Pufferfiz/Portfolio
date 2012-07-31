/*
 *
 * University of Advancing Technology Standard C++ Template Driver
 *
 * Name: Driver.cpp
 * Student: Kendal Cormany
 *
 */

#include "StandardIncludes.h"
#include "MyString2.h"
#include "myString1.h"
#include "HashTable.h"

int main()
{
	// Define your code here
	MyString2 aaaaa("dddd");
	MyString2 bbbbb("dddd");
	MyString2 asd("BNG");
	MyString2 asd2("BGN");
	HashTable<MyString2> ccccc(100000);
	ccccc.write(aaaaa);
	ccccc.write(asd);
	cout << ccccc["dddd"].getString() <<endl;
	cout << ccccc["BNG"].getString() <<endl;
	cout << ccccc["BGN"].getString() <<endl;
	return 0;
}
