#pragma once

#include <math.h>
#include <utility>
#include <algorithm>
#include <time.h>

#include "Map.h"
#include "..//GoldDiggerGUI/AgentAction.cs"
#include "Options.h"

#define EPSILON 0.001
#define NUM_OF_ACTIONS 4
#define RANDOM static_cast<double>(std::rand()) / static_cast<double>(RAND_MAX)

namespace GoldDiggerCore {

	class Agent {
	private:
		unsigned int _currentPos;
		Options _options;
		Map* _map;
		double** _Q;

	public:
		Agent() : _currentPos(0), _map(nullptr), _Q(nullptr) { }
		Agent(Map* map);
		Agent(const Agent& other);
		Agent(Agent&& other);
		Agent& operator=(const Agent& other);
		Agent& operator=(Agent&& other);
		~Agent();

		void PrintQ();
		unsigned int GetCurrentPos() { return _currentPos; }
		Options GetOptions() { return _options; };
		void SetCurrentPos(unsigned int pos);
		Block Sense() { return _map->Sense(_currentPos); }
		static double* GetActionProbabilityDistribution(double* QRow);
		static AgentAction SelectAction(double* probDist);
		//unsigned int NextPosition(AgentAction action) { return _map->NextPosition(_currentPos, action); }
		AgentAction* ValueIteration(double gamma = 0.9);
		AgentAction* PolicyIteration(double gamma = 0.9);
		AgentAction QLearningAct(double gamma = 0.9);
		int RandomPosition();
		double** GetQ() { return _Q; };

	};
} // namespace goldDiggerAgent
