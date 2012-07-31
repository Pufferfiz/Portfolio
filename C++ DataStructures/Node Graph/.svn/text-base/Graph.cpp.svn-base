/*
 * Graph.cpp
 *
 *  Created on: Dec 21, 2011
 *      Author: kencorma
 */


#include "Graph.h"




Graph::Graph(string inName): fileName(inName)
{
}


Graph::~Graph()
{

}


bool Graph::isLoop()
{
	int aaaaaaaaaa = 0;
	while(aaaaaaaaaa != 3)
	{
		depthSearch(&myNodes[0]);
		aaaaaaaaaa++;
	}

	return hasALoop;
}



unsigned int Graph::getCount()
{
	return myNodes.size();
}



void Graph::pushIn(Task aNode)
{
	myNodes.push_back(aNode);
}



void Graph::depthSearch(Task* aNode)
{
	vector<Task* > tempList = aNode->getChildrens();

	cout << "Got Connections" << endl;
	cout << tempList.size() << endl;
	for (unsigned int var = 0; var < tempList.size(); ++var)
	{
		cout << "In forloop" << endl;
		if(tempList[var]->getChildrens().size() == 0)
		{
			continue;
			cout << "No Connection" << endl;
		}

		if(containsItem(placesIHaveBeen,tempList[var]))
		{
			hasALoop = true;
			cout << "Has loop" << endl;
		}

		if(hasALoop == true)
		{
			continue;
			nodeThatHasALoop = aNode;
			cout << "Stop Searching" << endl;
		}

		else
		{
			placesIHaveBeen.push_back(tempList[var]);
			depthSearch(tempList[var]);
			cout << "go to a node" << endl;
		}

	}
}


bool containsItem(vector<Task* > aVec,Task* item)
{
	bool isItem = false;
	for (unsigned int var = 0; var < aVec.size(); ++var)
	{
		if (aVec[var] ==  item)
		{
			isItem = true;
		}
	}

	return isItem;
}

