/*
 *
 * University of Advancing Technology Standard C++ Template Driver
 *
 * Name: Driver.cpp
 * Student: Kendal Cormany
 *
 */

#include "StandardIncludes.h"
#include "Task.h"
#include "Graph.h"
#include <cppunit/TestFixture.h>
#include <cppunit/extensions/HelperMacros.h>
#include <cppunit/ui/text/TestRunner.h>


class tests : public CppUnit::TestFixture
{
	CPPUNIT_TEST_SUITE (tests);
	CPPUNIT_TEST (testgraph);
	CPPUNIT_TEST_SUITE_END ();
private:
	Task A;
	Task B;
	Task C;
	Graph myGraph;
public:
	void setUp()
	{
		cout << "Set Up Started" << endl;
		A = new Task("asd",2);
		B = new Task("dsa", 3);
		C = new Task("ha", 2);
		myGraph = new Graph("look");
		A.addChildrens(&B);
		B.addChildrens(&C);
		B.addParents(&A);
		C.addParents(&B);
		myGraph.pushIn(A);
		myGraph.pushIn(B);
		myGraph.pushIn(C);
	}
	void tearDown()
	{

	}
	void testgraph()
	{
		cout << "Test Graph Started" << endl;

		cout << "Test Graph Ended" << endl;
	}
};

int main()
{
	// Define your code here
	Graph aGraph("asd");
	Task A("asd", 3);
	Task B("a213sd", 4);
	Task C("aasdsd", 3);
	Task D("asd23e", 5);
	Task E("a111sd", 1);
	A.addChildrens(&B);
	A.addChildrens(&C);
	B.addChildrens(&D);
	C.addChildrens(&D);
	C.addChildrens(&E);
	B.addParents(&A);
	C.addParents(&A);
	D.addParents(&B);
	B.addParents(&C);
	C.addParents(&C);
	aGraph.pushIn(A);
	aGraph.pushIn(B);
	aGraph.pushIn(C);
	aGraph.pushIn(D);
	aGraph.pushIn(E);


	cout << aGraph.isLoop();
	return 0;
}
