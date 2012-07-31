/*
 * Node.h
 *
 *  Created on: Sep 30, 2011
 *      Author: kencorma
 */

#ifndef NODE_H_
#define NODE_H_

template <class T>
class Node
{
public:
	Node();
	virtual ~Node();
	T& getDataByReference();
	T getData();
	void setData(T);
	Node<T>* getNext();
	void setNext(Node<T>*);
	Node<T>* getPrevious();
	void setPrevious(Node<T>*);
private:
	Node(const Node<T>& rhs);
	Node<T>& operator=(const Node<T>& rhs);
	T data;
	Node<T>* next;
	Node<T>* previous;
};

template <class T>
Node<T>::Node()
{

}

template <class T>
Node<T>::~Node()
{

}

template<class T>
T& Node<T>::getDataByReference()
{
	return data;
}

template<class T>
T Node<T>::getData()
{
	return data;
}

template<class T>
Node<T>* Node<T>::getNext()
{
	return next;
}

template<class T>
void Node<T>::setNext(Node<T>* node)
{
	next = node;
}

template<class T>
Node<T>* Node<T>::getPrevious()
{
	return previous;
}

template<class T>
void Node<T>::setPrevious(Node<T>* node)
{
	previous = node;
}


#endif /* NODE_H_ */
