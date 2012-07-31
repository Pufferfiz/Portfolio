/*
 *
 * University of Advancing Technology Standard C++ Template Driver
 *
 * Name: Driver.cpp
 * Student: Default Student
 *
 */

#include "StandardIncludes.h"
#include <cppunit/ui/text/TestRunner.h>
#include "Stack.h"
#include "TestStack.h"


bool doAllTestsFunction()
{
    CppUnit::TextUi::TestRunner runner;
    runner.addTest(TestStack::suite());
    return runner.run();
}

int main()
{
	if (doAllTestsFunction())
	{
		//  Your application code goes here
		Stack<int> stackOfInt;
		Stack<string> stackOfString;
	}
	return 0;
}
