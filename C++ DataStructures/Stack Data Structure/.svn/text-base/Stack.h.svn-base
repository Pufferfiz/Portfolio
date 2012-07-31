/*
 * Stack.h
 *
 *  Created on: Sep 13, 2011
 *      Author: hartley
 */

#ifndef STACK_H_
#define STACK_H_

template<class T>
class Stack
{
public:
	const static unsigned int DEFAULT_NUMBER_OF_ELEMENTS = 100;
	Stack();
	Stack(unsigned int numberOfElements);
	virtual ~Stack();
	void push(T item);
	T pop();
	T top();
	bool isEmpty();
	unsigned int size();
	void clear();
private:
	unsigned int numberOfElements;
	T* stackElements;
	unsigned int stackPointer;
};

template<class T>
Stack<T>::Stack()
{
}

template<class T>
Stack<T>::Stack(unsigned int numberOfElements) : stackPointer(0), numberOfElements(numberOfElements), stackElements(new T[numberOfElements])
{
}

template<class T>
Stack<T>::~Stack()
{
	delete [] stackElements;
}

template<class T> void Stack<T>::push(T item)
{
	if(numberOfElements == DEFAULT_NUMBER_OF_ELEMENTS)
	{

	}
	else
	{
		stackElements[stackPointer] = item;
		stackPointer++;
		numberOfElements++;
	}

}

template<class T> T Stack<T>::pop()
{
	if((isEmpty() == true))
	{
		return null;
	}
	else
	{
		stackPointer--;
		T itemReturn = stackElements[stackPointer];
		stackElements[stackPointer] = null;
		numberOfElements--;
		return itemReturn;
	}

}

template<class T> T Stack<T>::top()
{
	if (numberOfElements == 0)
	{

	}
	else
	{
		return stackElements[stackPointer-1];
	}
}

template<class T> bool Stack<T>::isEmpty()
{
	if(numberOfElements = 0)
	{
		return true;
	}

	else{
		return false;
	}

}

template<class T> unsigned int Stack<T>::size()
{
	return numberOfElements;
}

template<class T> void Stack<T>::clear()
{
	for (int index = 0; index < numberOfElements; ++index)
	{
		T[index]= null;
	}
	numberOfElements = 0;
}



#endif /* STACK_H_ */
