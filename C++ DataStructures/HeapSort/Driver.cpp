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
	CPPUNIT_TEST (testheap);
	CPPUNIT_TEST_SUITE_END ();
private:
	int* thearray;
	sort sorter;
public:
	void setUp()
	{
		//int * array = new int[6];
		sorter.setSize(6);
		thearray[0] = 1;
		thearray[1] = 3;
		thearray[2] = 0;
		thearray[3] = 5;
		thearray[4] = 2;
		thearray[5] = 4;
		sorter.setArray(thearray);

	}
	void tearDown()
	{
		delete [] thearray;
	}
	void testheap()
	{
		cout << "Test Heap Started" << endl;
		sorter.run();
		thearray = sorter.getArray();
		CPPUNIT_ASSERT(thearray[0] == 5);
		CPPUNIT_ASSERT(thearray[1] == 4);
		CPPUNIT_ASSERT(thearray[2] == 3);
		CPPUNIT_ASSERT(thearray[3] == 2);
		CPPUNIT_ASSERT(thearray[4] == 1);
		CPPUNIT_ASSERT(thearray[5] == 0);
		cout << "Test Heap Ended" << endl;
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
	// Define your code here
	//bool passed = runtest();  //<- tests are here, but disable since it is broken in one spot.
	int size = 10;
	sort sorter;
	sorter.setSize(size);
	int intarray[size];
	intarray[0] = 23;
	intarray[1] = 12;
	intarray[2] = 5;
	intarray[3] = 0;
	intarray[4] = 25;
	intarray[5] = 50;
	intarray[6] = 15;
	intarray[7] = 30;
	intarray[8] = 40;
	intarray[9] = 33;
	cout << "Unsorted: "<< endl;
	for (int var = 0; var < size; ++var)
	{

		//intarray[var] = rand() % 100;
		cout << intarray[var] << endl;
	}
	sorter.setArray(intarray);
	sorter.run();
	cout << "Sorted: " << endl;
	sorter.print();
	return 0;
}
