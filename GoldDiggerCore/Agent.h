#pragma once

#include <math.h>
#include <utility>
#include <algorithm>

#include "Map.h"
#include "..//GoldDiggerGUI/AgentAction.cs"
#include "Options.h"

#define EPSILON 0.001

namespace GoldDiggerCore {
	/*enum class AgentAction { Dig, Up, Right, Down, Left };*/

	class Agent {
	private:
		unsigned int _currentPos;
		Options _options;
		Map* _map;

	public:
		Agent() : _map(nullptr) { }
		Agent(Map* map);

		unsigned int GetCurrentPos() { return _currentPos; }
		Block Sense() { return _map->Sense(_currentPos); }
		std::pair<unsigned int, int> Act(AgentAction action) { return _map->ActionResult(_currentPos, action); }
		//bool IsActionPossible(AgentAction action) { return _map->IsActionPossible(_currentPos, action); }
		//unsigned int NextPosition(AgentAction action) { return _map->NextPosition(_currentPos, action); }
		AgentAction* ValueIteration(double gamma = 0.9);
		AgentAction* PolicyIteration(double gamma = 0.9);
		Options GetOption() { return _options; };

	};
} // namespace goldDiggerAgent
