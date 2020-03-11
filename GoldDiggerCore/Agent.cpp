#include "Agent.h"

namespace GoldDiggerCore {

	Agent::Agent(Map* map)
		: _map(map),
		_options(Options(*map))
	{
		_currentPos = _options.agentStartPos;
	}

	AgentAction* Agent::ValueIteration(double gamma) {
		// Initialize the Values and Policy arrays
		double* prevValues = new double[_options.n * _options.m]{};
		const AgentAction AgentActions[] = 
				{ AgentAction::Dig, AgentAction::Up, AgentAction::Right,
					AgentAction::Down, AgentAction::Left };
		bool converged = false;
		unsigned int epoch = 0;
		while (!converged) {
			converged = true;
			++epoch;

			double* newValues = new double[_options.n * _options.m]{};
			double max;
			for (unsigned int i = 0; i < _options.n * _options.m; ++i) {
				max = -1;
				for (auto action : AgentActions) {
					max = std::max(max, _map->ActionReward(i, action) + gamma * prevValues[_map->NextPosition(i, action)]);
				}
				if (max == -1)
					continue;	// No possible actions
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
		for (unsigned int i = 0; i < _options.n * _options.m; ++i) {
			max = -1;
			for (auto action : AgentActions) {
				tmp = prevValues[_map->NextPosition(i, action)];
				if (tmp > max) {
					max = tmp;
					argmax = action;
				}
			}
			if (max = -1)
			policy[i] = argmax;
		}

		delete[] prevValues;
		return policy;

	}

	AgentAction* Agent::PolicyIteration(double gamma) {
		// Initialize the policy randomly
		AgentAction* prevPolicy = new AgentAction[_options.n * _options.m];
		for (unsigned int i = 0; i < _options.n * _options.m; ++i) {
			auto action = AgentAction(rand() % 5);
			prevPolicy[i] = action;
			/*while (!_map->IsActionPossible(i, action)) {
				action = AgentAction(rand() % 5);
				prevPolicy[i] = action;
			}*/
		}

		// Initialize the values according to the policy
		double* prevValues = new double[_options.n * _options.m]{};
		for (unsigned int i = 0; i < _options.n * _options.m; ++i)
			prevValues[i] = _map->ActionReward(i, prevPolicy[i])
			+ gamma * prevValues[_map->NextPosition(i, prevPolicy[i])];

		bool policyConverged = false;
		unsigned int epoch = 0;
		while (!policyConverged) {
			++epoch;
			policyConverged = true;

			// Calculate the value function for the current policy (Policy Evaluation)
			bool valuesConverged = false;
			while (!valuesConverged) {
				valuesConverged = true;
				double* newValues = new double[_options.n * _options.m]{};
				for (unsigned int i = 0; i < _options.n * _options.m; ++i) {
					newValues[i] = _map->ActionReward(i, prevPolicy[i])
						+ gamma * prevValues[_map->NextPosition(i, prevPolicy[i])];
					if (std::abs(newValues[i] - prevValues[i]) > EPSILON)
						valuesConverged = false;
				}
				delete[] prevValues;
				prevValues = newValues;
			}
			
			// Improve the current policy (Policy Improvement)
			AgentAction* newPolicy = new AgentAction[_options.n * _options.m];
			const AgentAction AgentActions[] =
			{ AgentAction::Dig, AgentAction::Up, AgentAction::Right,
				AgentAction::Down, AgentAction::Left };
			double max;
			double temp;
			AgentAction argmax;
			for (unsigned int i = 0; i < _options.n * _options.m; ++i) {
				max = -1;
				for (auto action : AgentActions) {
					temp = _map->ActionReward(i, action)
						+ gamma * prevValues[_map->NextPosition(i, action)];
					if (temp > max) {
						max = temp;
						argmax = action;
					}
				}
				
				if (prevPolicy[i] != argmax)
					policyConverged = false;
				newPolicy[i] = argmax;
			}
			delete[] prevPolicy;
			prevPolicy = newPolicy;

		}
		std::cout << "Policy Iteration converged after " << epoch << " epochs\n";

		delete[] prevValues;
		return prevPolicy;
	}
} // namespace GoldDiggerAgent
