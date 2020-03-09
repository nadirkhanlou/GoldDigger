#include "Agent.h"

namespace GoldDiggerCore {

	Agent::Agent(Map* map)
		: _map(map),
		_options(Options(*map))
	{
		_currentPos = _options.agentStartPos;
	}

	AgentAction* Agent::ValueIteration() {
		// Initialize the Values and Policy arrays
		double* prevValues = new double[_options.n * _options.m]{};
		bool converged = false;
		unsigned int epoch = 0;
		//extern const AgentAction AgentActions[(int)AgentAction::Left + 1];
		const AgentAction AgentActions[] = 
				{ AgentAction::Dig, AgentAction::Up, AgentAction::Right,
					AgentAction::Down, AgentAction::Left };
		while (!converged) {
			double* newValues = new double[_options.n * _options.m]{};
			++epoch;
			converged = true;
			double max = INT64_MIN;
			for (unsigned int i = 0; i < _options.n * _options.m; ++i) {
				for (auto action : AgentActions) {
					if (_map->IsActionPossible(i, action))
						max = std::max(max, _map->ActionReward(i, action) + prevValues[_map->NextPosition(i, action)]);
				}
				newValues[i] = max;
				if (std::abs(newValues[i] - prevValues[i]) > EPSILON) {
					converged = false;
				}
			}
			delete[] prevValues;
			prevValues = newValues;
		}
		std::cout << "Value Iteration converged after " << epoch << " epochs\n";

		// Now derrive the policy from the values obtained above
		AgentAction* policy = new AgentAction[_options.n * _options.m];
		double max;
		double tmp;
		AgentAction argmax;
		for (unsigned int i = 0; i < _options.n * _options.m; ++i)
		{
			max = -1;
			for (auto action : AgentActions) {
				if (_map->IsActionPossible(i, action)) {
					tmp = prevValues[_map->NextPosition(i, action)];
					if (tmp > max) {
						max = tmp;
						argmax = action;
					}
				}
			}
			policy[i] = argmax;
		}

		return policy;

	}
} // namespace GoldDiggerAgent