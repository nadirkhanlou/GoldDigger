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
		AgentAction* ValueIteration(double gamma);
		AgentAction* PolicyIteration(double gamma);
		AgentAction QLearningAct(double gamma);
		int AgentRandomPosition();
		std::pair<int, int> Size();
		double** GetQTable();
		void PrintQTable();
	};

} //GoldDiggerSolver
