/*
 * Task.h
 *
 *  Created on: Dec 21, 2011
 *      Author: kencorma
 */

#ifndef TASK_H_
#define TASK_H_
#include "StandardIncludes.h"

class Task
{
public:
	Task(string inName, unsigned int induriation);
	Task();
	Task(const Task& rhs);
	virtual ~Task();
	int getDuration();
	void addTime(unsigned int inDays);
	string getName() const;
	void addParents(Task*);
	void addChildrens(Task*);
	vector<Task*>& getParents();
	vector<Task*>& getChildrens();
	bool operator=(const Task& asd) const;
private:
	string name;
	unsigned int duration;
	vector<Task*> Parents;
	vector<Task*> Childrens;
};

#endif /* TASK_H_ */
