/*
 * TestStack.cpp
 *
 *  Created on: Sep 13, 2011
 *      Author: hartley
 */

#include "TestStack.h"
#include "StandardIncludes.h"

void TestStack::setUp()
{
	// TODO Your setup code goes here.  Typically you will set your instance
	// variables in this code
	testIntStack = new Stack<int>(10);
	testInt = 0;
}

void TestStack::tearDown()
{
	// TODO Your tear down code goes here. Typically, you will be deleting any
	// pointers you created in the setUp method
	delete testIntStack;
}

void TestStack::testPush()
{
	cout << "Test Push Starting" << endl;
	testIntStack->push(1);
	testIntStack->push(2);
	testIntStack->push(3);
	testIntStack->push(4);
	testIntStack->push(5);
	testIntStack->push(6);
	testIntStack->push(7);
	testIntStack->push(8);
	testIntStack->push(9);

	CPPUNIT_ASSERT(testIntStack->size()==9);
	cout << "Test Push Ending" << endl;
}

void TestStack::testPop()
{
	cout << "Test Pop starting" << endl;
	cout<< "last element inserted is:" + testIntStack->pop() << endl;
	CPPUNIT_ASSERT(testIntStack->pop() == 9);
	cout << "Test Pop Ending" << endl;
}

void TestStack::testTop()
{
	cout << "Test Top starting" << endl;
	cout << "Top Element is:" + testIntStack->top() << endl;
	CPPUNIT_ASSERT(testIntStack->top() == 1 );
	cout << "Test Top Ending" << endl;
}

void TestStack::testClear()
{
	cout << "Test Clear starting" << endl;
	testIntStack->clear();
	CPPUNIT_ASSERT(testIntStack->size()==0);
	cout << "Test Clear Ending" << endl;
}

void TestStack::testIsEmpty()
{
	cout << "Test isEmpty starting" << endl;
	CPPUNIT_ASSERT(testIntStack->isEmpty()==true);
	cout << "Test isEmpty Ending" << endl;

}

void TestStack::testSize()
{
	cout << "Test size Starting" << endl;
	CPPUNIT_ASSERT(testIntStack->size() = 0);
	cout << "Test Size Ending" << endl;

}

