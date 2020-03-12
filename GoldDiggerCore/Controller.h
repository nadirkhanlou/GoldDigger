#pragma once

#include <utility>
#include <algorithm>

#include "Map.h"
#include "Agent.h"

namespace GoldDiggerCore {

	class Controller {
	private:
		Map _map;
		Agent _agent;
	public:
		Controller(const char* path);
		AgentAction* ValueIteration();
		AgentAction* PolicyIteration();
		AgentAction QLearningAct();
		std::pair<int, int> Size();
	};

} //GoldDiggerSolver
