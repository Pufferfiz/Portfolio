/*
 *
 * University of Advancing Technology Standard C++ Template Driver
 *
 * Name: Driver.cpp
 * Student: Kendal Cormany
 *
 */

#include "StandardIncludes.h"
#include "Node.h"
#include "Tree.h"

int main()
{
	// Define your code here
	Tree<int> myTree;
	myTree.insert(32);
	myTree.insert(12);
	myTree.insert(8);
	myTree.insert(25);
	myTree.insert(11);
	myTree.insert(20);
	return 0;
}
