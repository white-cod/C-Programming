#pragma once
#pragma once
#include <iostream>
using namespace std;

template<class T>
class Deque {
	struct node {
		node* prev, * next;
		T     val;
		node(void) noexcept : prev(nullptr), next(nullptr) {}
		node(const T& v) : prev(nullptr), next(nullptr), val(v) {}
	};
private:
	node* _head, * _tail;
public:
	Deque(void) noexcept : _head(nullptr), _tail(nullptr) {}
	~Deque() { clear(); }

	Deque(const Deque&) = delete;
	Deque& operator = (const Deque&) = delete;

	// clone operation
	Deque* clone() const {
		Deque* newDeque = new Deque();
		for (node* p = _head; p != nullptr; p = p->next)
			newDeque->addEnd(p->val);
		return newDeque;
	}

	// + operator
	Deque* operator + (const Deque& other) const {
		Deque* newDeque = clone();
		for (node* p = other._head; p != nullptr; p = p->next)
			newDeque->addEnd(p->val);
		return newDeque;
	}

	// * operator
	Deque* operator * (const Deque& other) const {
		Deque* newDeque = new Deque();
		for (node* p = _head; p != nullptr; p = p->next) {
			for (node* q = other._head; q != nullptr; q = q->next) {
				if (p->val == q->val) {
					newDeque->addEnd(p->val);
					break;
				}
			}
		}
		return newDeque;
	}

public:
	void addBegin(const T& v) { add_beg(new node(v)); }

	void addBegin(T&& v)
	{
		node* p = new node();
		p->val = std::forward<T>(v);
		add_beg(p);
	}

	void addEnd(const T& v) { add_end(new node(v)); }

	void addEnd(T&& v)
	{
		node* p = new node();
		p->val = std::forward<T>(v);
		add_end(p);
	}

	T outBegin(void)
	{
		T v = _head->val;
		pop_beg();
		return v;
	}

	void popBegin(void) { pop_beg(); }

	T outEnd(void)
	{
		T v = _tail->val;
		pop_end();
		return v;
	}

	void popEnd(void) { pop_end(); }

	void clear(void)
	{
		node* p;
		while (_head != nullptr)
		{
			p = _head;
			_head = _head->next;
			delete p;
		}
		_tail = nullptr;
		cout << "Clear" << endl;
	}

	size_t getCount(void) const noexcept
	{
		size_t i = 0;
		for (const node* p = _head; p != nullptr; p = p->next)
			++i;
		return i;
	}

	T& Begin(void) { return _head->val; }
	const T& Begin(void) const { return _head->val; }

	T& End(void) { return _tail->val; }
	const T& End(void) const { return _tail->val; }

	bool isEmpty(void) const noexcept { return (_head == nullptr); }
private:
	void add_beg(node* p) noexcept
	{
		if (_head == nullptr)
			_head = _tail = p;
		else
		{
			_head->prev = p;
			p->next = _head;
			_head = p;
		}
	}

	void add_end(node* p) noexcept
	{
		if (_head == nullptr)
			_head = _tail = p;
		else
		{
			p->prev = _tail;
			_tail->next = p;
			_tail = p;
		}
	}

	void pop_beg(void)
	{
		node* p = _head;
		if ((_head = _head->next) != nullptr)
			_head->prev = nullptr;
		else
			_tail = nullptr;
		delete p;
	}

	void pop_end(void)
	{
		node* p = _tail;
		if ((_tail = _tail->prev) != nullptr)
			_tail->next = nullptr;
		else
			_head = nullptr;
		delete p;
	}
};