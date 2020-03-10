#pragma once

#include "Map.h"

namespace GoldDiggerCore {
	struct Options {
		unsigned int n, m;
		unsigned int agentStartPos;

		Options()
			: n(0), m(0), agentStartPos(0)
		{ }

		Options(Map& map)
			: n(map._n), m(map._m),
			agentStartPos(map._startPos)
		{ }
	};
} // namespace GoldDiggerCore
