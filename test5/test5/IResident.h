#pragma once

#ifndef IRESIDENT_H
#define IRESIDENT_H

class IResident
{
public:
//	IResident() = default;

	virtual void Init() = 0;
	virtual void Print() = 0;

	virtual ~IResident()
	{
	}
};

#endif