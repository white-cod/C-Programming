#pragma once
#include "PassQueue.h"

class BusStop
{
	struct StopParametrs
	{
		int passAppearTime;
		int busAppearTime;
	};

	const bool mLastStop;
	StopParametrs mStopParametrs[2];
	PassQueue passengers;
public:
	BusStop();
	BusStop(const int dayPassAppearTime, const int dayBusAppearTime,
		const int nightPassAppearTime, const int nightBusAppearTime, const bool lastStop = false);

	void CalculateTime(const time_t calcTime, const int maxQueue);
	void PrintTime(const int time) const;
};