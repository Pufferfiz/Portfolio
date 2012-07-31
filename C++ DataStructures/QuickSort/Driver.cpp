/*
 *
 * University of Advancing Technology Standard C++ Template Driver
 *
 * Name: Driver.cpp
 * Student: Kendal Cormany
 *
 */

#include "StandardIncludes.h"
#include "sort.h"
#include <cppunit/TestFixture.h>
#include <cppunit/extensions/HelperMacros.h>
#include <cppunit/ui/text/TestRunner.h>


class tests : public CppUnit::TestFixture
{
	CPPUNIT_TEST_SUITE (tests);
	CPPUNIT_TEST (testsort);
	CPPUNIT_TEST_SUITE_END ();
private:
	int* thearray;
	int thesize;
	sort sorter;
public:
	void setUp()
	{
		cout << "Set Up Started" << endl;
		thesize = 6;
		thearray = new int[thesize];
		thearray[0] = 1;
		thearray[1] = 3;
		thearray[2] = 0;
		thearray[3] = 5;
		thearray[4] = 2;
		thearray[5] = 4;

	}
	void tearDown()
	{
		delete [] thearray;
	}
	void testsort()
	{
		cout << "Test Quick Sort Started" << endl;
		sorter.quickSort(thearray,0,thesize -1);
		CPPUNIT_ASSERT(thearray[0] == 0);
		CPPUNIT_ASSERT(thearray[1] == 1);
		CPPUNIT_ASSERT(thearray[2] == 2);
		CPPUNIT_ASSERT(thearray[3] == 3);
		CPPUNIT_ASSERT(thearray[4] == 4);
		CPPUNIT_ASSERT(thearray[5] == 5);
		cout << "Test Quick Sort Ended" << endl;
	}
};

bool runtest()
{
	CppUnit::TextUi::TestRunner runner;
	runner.addTest(tests::suite());
	return runner.run();
}

int main()
{
	sort sorter;
	// Define your code here
	bool done = runtest();
	int size = 10;
	int array[size];
	for (int index = 0; index < size; ++index)
	{
		array[index] = rand() % 30;
	}
	cout << "Unsorted" << endl;
	sorter.print(array,size);
	sorter.quickSort(array,0,size-1);
	cout << "Sorted" << endl;
	sorter.print(array,size);

	return 0;
}
