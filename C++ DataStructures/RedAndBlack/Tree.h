/*
 * Tree.h
 *
 *  Created on: Nov 20, 2011
 *      Author: Kendal
 */

#ifndef TREE_H_
#define TREE_H_

#include "StandardIncludes.h"
#include "Node.h"

template <class T>
class Tree
{
public:
	Tree<T>();
	Tree(Node<T>* node);
	virtual ~Tree<T>();
	void insert(T data);

	int size() const;

	void printTree();

private:
	Node<T>* insertRec(Node<T>* node, Node<T>* currentNode);
	Node<T>* getGrandParent(Node<T>* node);
	Node<T>* getUncle(Node<T>* node);
	Node<T>* getSibling(Node<T>* node);
	void insertCase1(Node<T>* node);
	void insertCase2(Node<T>* node);
	void insertCase3(Node<T>* node);
	void insertCase4(Node<T>* node);
	void insertCase5(Node<T>* node);
	void rotateLeft(Node<T>* node);
	void rotateRight(Node<T>* node);
	void printTree(Node<T>* node);
	Node<T>* root;
	int nodeCount;

	};


/*
Color:
0 = black
1 = red
*/

template<class T>
Tree<T>::Tree() : root(NULL), nodeCount(0)
{
}

template<class T>
Tree<T>::Tree(Node<T>* node) : root(node), nodeCount(1)
{
}

template<class T>
Tree<T>::~Tree()
{
	delete root;
}

template<class T>
int Tree<T>::size() const
{
	return nodeCount;
}

template<class T>
Node<T>* Tree<T>::getGrandParent(Node<T>* node)
{
	if ((node != NULL) && (node->getParent() != NULL))
	{
		return node->getParent()->getParent();
	}
	else
	{
		return NULL;
	}
}

template<class T>
Node<T>* Tree<T>::getUncle(Node<T>* node)
{
	Node<T>* grandparent = getGrandParent(node);
	if (grandparent == NULL)
	{
		return NULL;
	}
	if (node->getParent() == grandparent->getLeft())
	{
		return grandparent->getRight();
	}
	else
	{
		return grandparent->getLeft();
	}
}

template<class T>
Node<T>* Tree<T>::getSibling(Node<T>* node)
{
	if (node == node->parent->left)
		return node->parent->right;
	else
		return node->parent->left;
}


template<class T>
void Tree<T>::insert(T data)
{
	Node<T>* newNode = new Node<T>(data);
	if(root == NULL)
		root = newNode;
	else
		insertRec(newNode, root);
	insertCase1(newNode);
}

template<class T>
Node<T>* Tree<T>::insertRec(Node<T>* node, Node<T>* currentNode)
{
	if(currentNode == NULL)
		return NULL;

	if(*node < *currentNode)
	{
		if(currentNode->getLeft() == NULL)
		{
			currentNode->setLeft(node);
			return NULL;
		}
		else
		{
			return insertRec(node, currentNode->getLeft());
		}
	}
	else if(*node > *currentNode)
	{
		if(currentNode->getRight() == NULL)
		{
			currentNode->setRight(node);
			return NULL;
		}
		else
		{
			return insertRec(node, currentNode->getRight());
		}
	}

	return currentNode;
}


template<class T>
void Tree<T>::insertCase1(Node<T>* node)
{
	if (node->getParent() == NULL)
		node->makeBlack();
	else
		insertCase2(node);
}

template<class T>
void Tree<T>::insertCase2(Node<T>* node)
{
	if (node->getParent()->getColor() == 0)
		return;
	else
		insertCase3(node);
}

template<class T>
void Tree<T>::insertCase3(Node<T>* node)
{
	Node<T>* uncle = getUncle(node);
	Node<T>* grandparent;

	if ((uncle != NULL) && (uncle->getColor() == 1))
	{
		node->getParent()->makeBlack();
		uncle->makeBlack();
		grandparent = getGrandParent(node);
		grandparent->makeRed();
		insertCase1(grandparent);
	}
	else
		insertCase4(node);
}

template<class T>
void Tree<T>::insertCase4(Node<T>* node)
{
	Node<T>* grandparent = getGrandParent(node);

	if ((node == node->getParent()->getRight()) && (node->getParent() == grandparent->getLeft()))
	{
		rotateLeft(node->getParent());
		node = node->getLeft();
	}
	else if ((node == node->getParent()->getLeft()) && (node->getParent() == grandparent->getRight()))
	{
		rotateRight(node->getParent());
		node = node->getRight();
	}
	insertCase5(node);
}

template<class T>
void Tree<T>::insertCase5(Node<T>* node)
{
	Node<T>* grandparent = getGrandParent(node);

	node->getParent()->makeBlack();
	grandparent->makeRed();
	if ((node == node->getParent()->getLeft()) && (node->getParent() == grandparent->getLeft()))
	{
		rotateRight(grandparent);
	}
	else if ((node == node->getParent()->getRight()) && (node->getParent() == grandparent->getRight()))
	{
		rotateLeft(grandparent);
	}
}

template<class T>
void Tree<T>::rotateRight(Node<T>* node)
{
	if (node->getLeft() == NULL)
		return;

	Node<T>* lNode = node->getLeft();
	Node<T>* correctParent = node->getParent();

	if (correctParent != NULL)
	{
		if (node == correctParent->getLeft())
			correctParent->setLeft(lNode);
		else
			correctParent->setRight(lNode);
	}
	node->setLeft(lNode->getRight());
	lNode->setRight(node);
	lNode->setParent(node->getParent());
	node->setParent(lNode);

	if (root == node)
	{
		root = lNode;
		lNode->setParent(NULL);
	}
}

template<class T>
void Tree<T>::rotateLeft(Node<T>* node)
{
	if (node->getRight() == NULL)
		return;

	Node<T>* rNode = node->getRight();
	Node<T>* correctParent = node->getParent();

	if (correctParent != NULL)
	{
		if (node == correctParent->getLeft())
			correctParent->setLeft(rNode);
		else
			correctParent->setRight(rNode);

	}
	node->setRight(rNode->getLeft());
	rNode->setLeft(node);
	rNode->setParent(node->getParent());
	node->setParent(rNode);
	if (root == node)
	{
		root = rNode;
		rNode->setParent(NULL);
	}
}

#endif /* TREE_H_ */
