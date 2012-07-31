/*
 * Node.h
 *
 *  Created on: Dec 2, 2011
 *      Author: KENCORMA
 */

#ifndef NODE_H_
#define NODE_H_

#include "StandardIncludes.h"
#include <typeinfo>

template<class T>
class Node
{
public:
	Node(T inData);
	virtual ~Node();
	Node(const Node<T>& rhs);
	Node();
	vector<Node<T>* > getConnections()const;
	void setConnection(Node<T>* connection);
	int getNumberOfConnections();
	void setData(T inData);
	T getData();
	bool operator==(const Node<T> aNode) const;
	bool operator<(const Node<T> aNode) const;
private:
	T Data;
	vector<Node<T>* > Connections;


};

template<class T>
Node<T>::Node(T inData)
{
	Data = inData;

}

template<class T>
Node<T>::~Node<T>()
{

}

template<class T>
Node<T>::Node()
{

}

template<class T>
Node<T>::Node(const Node<T>& rhs)
{

}

template<class T>
void Node<T>::setConnection(Node<T>* Connection)
{
	Connections.push_back(Connection);
	//Connection->setConnection(this);

}

template<class T>
vector<Node<T>* > Node<T>::getConnections() const
{
	return Connections;
}

template<class T>
int Node<T>::getNumberOfConnections()
{
	return Connections.size();
}

template<class T>
void Node<T>::setData(T inData)
{
	Data = inData;
}

template<class T>
bool Node<T>::operator ==(const Node<T> aNode) const
{
	bool equal = false;
	if (Data == aNode.Data)
	{
		equal = true;
	}
	return equal;
}

template<class T>
bool Node<T>::operator<(const Node<T> aNode) const
{
	if (Data < aNode.Data)
	{
		return true;
	}
	else
	{
		return false;
	}


}

template<class T>
T Node<T>::getData()
{
	return Data;
}

template class Node<int>;


#endif /* NODE_H_ */
