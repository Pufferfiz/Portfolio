/*
 * Graph.h
 *
 *  Created on: Dec 7, 2011
 *      Author: kencorma
 */

#ifndef GRAPH_H_
#define GRAPH_H_

#include "StandardIncludes.h"
#include "Task.h"



class Graph
{
public:
	Graph(string inFileName);
	virtual ~Graph();
	bool isLoop();
	unsigned int getCount();
	void pushIn(Task aNode);
private:
	string fileName;
	vector<Task > myNodes;
	bool atTheEnd;
	bool hasALoop;
	vector<Task* > placesIHaveBeen;
	void depthSearch(Task* aNode);
	bool containsItem(vector<Task* > aVec,Task* item);
	Task* nodeThatHasALoop;
	Task* tempNode;
	vector<Task* > tempList;

};


#endif /* GRAPH_H_ */
