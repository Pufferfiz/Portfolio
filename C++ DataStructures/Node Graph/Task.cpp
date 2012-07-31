/*
 * Task.cpp
 *
 *  Created on: Dec 21, 2011
 *      Author: kencorma
 */

#include "Task.h"

Task::Task(string inName, unsigned int inDuration): name(inName), duration(inDuration)
{
	// TODO Auto-generated constructor stub

}

Task::~Task()
{
	// TODO Auto-generated destructor stub
}

vector<Task*>& Task::getParents()
{
	return Parents;
}

vector<Task*>& Task::getChildrens()
{
	return Childrens;
}

int Task::getDuration()
{
	return duration;
}

string Task::getName() const
{
	return name;
}

void Task::addChildrens(Task* aTask)
{
	Childrens.push_back(aTask);
}

void Task::addParents(Task* aTask)
{
	Parents.push_back(aTask);
}
void Task::addTime(unsigned int inDays)
{
	duration+= inDays;
	for (unsigned int var = 0; var < Childrens.size(); ++var)
	{
		Childrens[var]->addTime(inDays);
	}
}

bool Task::operator =(const Task& asd) const
{
	if (name == asd.getName() )
			{
				return true;
			}
	else
	{
		return false;
	}
}

