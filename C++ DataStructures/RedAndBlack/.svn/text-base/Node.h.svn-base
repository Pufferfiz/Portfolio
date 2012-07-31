/*
 * Node.h
 *
 *  Created on: Nov 20, 2011
 *      Author: Kendal
 */

#ifndef NODE_H_
#define NODE_H_

#include "StandardIncludes.h"

template<class T>
class Node
{
public:
	Node<T>(T Data);
	virtual ~Node<T>();
	Node(const Node<T>& rhs);
	bool operator<(const Node& rhs);
	bool operator>(const Node& rhs);
	int getColor();
	void makeRed();
	void makeBlack();
	Node<T>* getParent();
	Node<T>* getLeft();
	Node<T>* getRight();
	void setParent(Node<T>*);
	void setLeft(Node<T>*);
	void setRight(Node<T>*);
	void setData(T);
	T getData();



private:
	int color;
	T data;
	Node<T>* parent;
	Node<T>* rightNode;
	Node<T>* leftNode;


};




template<class T>
Node<T>::Node(T Data) : data(Data), parent(NULL), leftNode(NULL), rightNode(NULL)
{
	makeRed();
}

template<class T>
Node<T>::~Node<T>()
{

	delete this->leftNode;
	delete this->rightNode;

}

template<class T>
bool Node<T>::operator<(const Node& rhs)
{
	if (this->data < rhs.data)
	{
		return true;
	}
	else
	{
		return false;
	}
}
template<class T>
bool Node<T>::operator>(const Node& rhs)
{
	if (this->data > rhs.data)
	{
		return true;
	}
	else
	{
		return false;
	}
}

template<class T>
void Node<T>::makeBlack()
{
	color = 0;

}

template<class T>
void Node<T>::makeRed()
{
	color = 1;
}

template<class T>
int Node<T>::getColor()
{
	return color;
}

template<class T>
Node<T>* Node<T>::getLeft()
{
	return leftNode;
}

template<class T>
Node<T>* Node<T>::getParent()
{
	return parent;

}

template<class T>
Node<T>* Node<T>::getRight()
{
	return rightNode;
}

template<class T>
T Node<T>::getData()
{
	return data;
}

template<class T>
void Node<T>::setParent(Node<T>* node)
{
	parent = node;
}

template<class T>
void Node<T>::setLeft(Node<T>* node)
{
	leftNode = node;
}

template<class T>
void Node<T>::setRight(Node<T>* node)
{
	rightNode = node;
}

template<class T>
void Node<T>::setData(T inData)
{
	data = inData;
}
#endif /* NODE_H_ */
