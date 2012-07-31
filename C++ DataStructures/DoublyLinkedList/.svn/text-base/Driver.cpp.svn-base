/*
 *
 * University of Advancing Technology Standard C++ Template Driver
 *
 * Name: Driver.cpp
 * Student: Kendal Cormany
 *
 */

#include "StandardIncludes.h"
#include <cppunit/ui/text/TestRunner.h>
#include "DoublyLinkedList.h"

bool runTests()
{
	CppUnit::TextUi::TestRunner runner;
	runner.addTest(DoublyLinkedListTests::suite());
	return runner.run();
}


int main()
{
	if(runTests())
	{
		DoublyLinkedList<int> list;
		unsigned int numberOfPeople;
		unsigned int currentIndex;

		list.clear();
		for (unsigned int count = 0; count < numberOfPeople; ++count)
		{
			list.pushBack(count + 1);
		}

		while(numberOfPeople > 1)
		{
			for (unsigned int skip = 0; skip < 33; ++skip)
			{
				currentIndex++;
				if( currentIndex > list.size() )
					currentIndex = 1;
			}
				list.removeAt(currentIndex-1);
				numberOfPeople--;
		}

		cout << "Person number: " << list.popBack() << "is left" << endl;
	}
	return 0;
}
