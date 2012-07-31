/*
 * Tests.h
 *
 *  Created on: Oct 4, 2011
 *      Author: Kendal
 */

#ifndef TESTS_H_
#define TESTS_H_

#include <cppunit/TestFixture.h>
#include <cppunit/extensions/HelperMacros.h>
#include "DoublyLinkedList.h"
#include "StandardIncludes.h"

class DoublyLinkedListTests: public CPPUNIT_NS::TestFixture
{
    CPPUNIT_TEST_SUITE (DoublyLinkedListTests);
    CPPUNIT_TEST (testPushBack);
    CPPUNIT_TEST (testClear);
    CPPUNIT_TEST (testIndex);
    CPPUNIT_TEST (testRemoveAtIndex);
    CPPUNIT_TEST (testRemove);
    CPPUNIT_TEST (testInsertAt);
    CPPUNIT_TEST (testPopBack);
    CPPUNIT_TEST (testCopyConstructor);
    CPPUNIT_TEST (testAssignment);
    CPPUNIT_TEST (testEquality);
    CPPUNIT_TEST_SUITE_END ();
public:
    void setUp(void);
    void tearDown(void);
protected:
	void testPushBack();
	void testClear();
	void testIndex();
	void testRemoveAtIndex();
	void testRemove();
	void testInsertAt();
	void testPopBack();
	void testCopyConstructor();
	void testAssignment();
	void testEquality();
private:
	DoublyLinkedList<string> testList;
};



#endif /* TESTS_H_ */
