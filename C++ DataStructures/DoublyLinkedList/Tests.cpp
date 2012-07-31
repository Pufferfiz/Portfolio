/*
 * Tests.cpp
 *
 *  Created on: Oct 4, 2011
 *      Author: Kendal
 */


#include "Tests.h"
#include "StandardIncludes.h"


void DoublyLinkedListTests::setUp()
{
}

void DoublyLinkedListTests::tearDown()
{
}

void DoublyLinkedListTests::testPushBack()
{
	cout << "Push Back Started" << endl;
	CPPUNIT_ASSERT(testList.size() == 0);
	testList.pushBack("One");
	CPPUNIT_ASSERT(testList.size() == 1);

	cout << "Push Back Ended" << endl;
}

void DoublyLinkedListTests::testClear()
{
	cout << "Clear Started" << endl;
	testList.pushBack("This");
	testList.pushBack("is");
	testList.pushBack("a");
	testList.pushBack("test");
	testList.clear();
	CPPUNIT_ASSERT(testList.size() == 0);

	cout << "Clear Ended" << endl;
}

void DoublyLinkedListTests::testIndex()
{
	cout << "[] Started" << endl;
	testList.clear();
	testList.pushBack("This");
	CPPUNIT_ASSERT(testList[0] == "This");
	cout << "[] Ended" << endl;
}

void DoublyLinkedListTests::testRemoveAtIndex()
{
	cout << "Remove Index Started" << endl;
	testList.clear();
	testList.pushBack("One");
	testList.pushBack("Two");
	CPPUNIT_ASSERT(testList[1] == "Two");
	testList.removeAt(1);
	CPPUNIT_ASSERT(testList.size() == 1);

	cout << "Remove Index Ended" << endl;
}



void DoublyLinkedListTests::testRemove()
{
	cout << "Remove Started" << endl;

	testList.clear();
	testList.pushBack("One");
	testList.pushBack("Two");
	CPPUNIT_ASSERT(testList[1] == "Two");
	testList.remove("Two");
	CPPUNIT_ASSERT(testList.size() == 1);

	cout << "Remove Ended" << endl;
}

void DoublyLinkedListTests::testInsertAt()
{
	cout << "Insert Started" << endl;
	testList.clear();
	testList.pushBack("1");
	testList.pushBack("3");
	testList.insertAt(1,"2");
	CPPUNIT_ASSERT(testList[1] == "2");
	cout << "Insert Ended" << endl;
}

void DoublyLinkedListTests::testPopBack()
{
	cout << "Pop Back Started" << endl;
	testList.clear();
	string data;
	testList.pushBack("Test");
	data = testList.popBack();
	CPPUNIT_ASSERT(data == "Test");
	cout << "Pop Back Ended" << endl;
}

void DoublyLinkedListTests::testCopyConstructor()
{
	cout << "Copy Constructor Started" << endl;
	DoublyLinkedList<string> newList;
	testList.clear();
	testList.pushBack("This");
	testList.pushBack("is");
	testList.pushBack("a");
	testList.pushBack("test");
	newList = testList;
	CPPUNIT_ASSERT(newList == testList);
	cout << "Copy Constructor Ended" << endl;
}

void DoublyLinkedListTests::testAssignment()
{
	cout << "Assignment Started" << endl;
	DoublyLinkedList<string> newList;
	testList.clear();
	testList.pushBack("This");
	testList.pushBack("is");
	testList.pushBack("a");
	testList.pushBack("test");
	newList = testList;
	CPPUNIT_ASSERT(newList == testList);
	cout << "Assignment Ended" << endl;
}

void DoublyLinkedListTests::testEquality()
{
	cout << "Equality Started" << endl;
	DoublyLinkedList<string> newList;
	testList.clear();
	testList.pushBack("This");
	testList.pushBack("is");
	testList.pushBack("a");
	testList.pushBack("test");
	newList = testList;
	CPPUNIT_ASSERT(newList == testList);
	cout << "Equality Ended" << endl;
}



