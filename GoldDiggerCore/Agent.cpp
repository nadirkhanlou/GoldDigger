#include "Agent.h"

namespace GoldDiggerCore {

	const AgentAction AgentActions[] = {AgentAction::Up, AgentAction::Right,
										AgentAction::Down, AgentAction::Left };

	Agent::Agent(Map* map)
		: _map(map),
		_options(Options(*map)) {
		_currentPos = _options.agentStartPos;
	}

	Agent::Agent(const Agent& other)
		: _currentPos(other._currentPos),
		_map(other._map),
		_options(other._options) {
		if (other._Q == nullptr) {
			_Q = nullptr;
			return;
		}
		_Q = new double* [_options.n * _options.m];
		for (unsigned int i = 0; i < _options.n * _options.m; ++i) {
			_Q[i] = new double[NUM_OF_ACTIONS];
			for (auto action : AgentActions)
				_Q[i][action] = other._Q[i][action];
		}
	}

	Agent::Agent(Agent&& other)
		: _currentPos(other._currentPos), 
		_map(other._map),
		_options(other._options),
		_Q(other._Q) {
		other._Q = nullptr;
	}

	Agent& Agent::operator=(const Agent& other)
	{
		_currentPos = other._currentPos;
		_map = other._map;
		_options = other._options;
		if (other._Q == nullptr) {
			_Q = nullptr;
			return *this;
		}
		_Q = new double* [_options.n * _options.m];
		for (unsigned int i = 0; i < _options.n * _options.m; ++i) {
			_Q[i] = new double[NUM_OF_ACTIONS];
			for (auto action : AgentActions)
				_Q[i][action] = other._Q[i][action];
		}
		return *this;
	}
	Agent& Agent::operator=(Agent&& other) {
		_currentPos = other._currentPos;
		_map = other._map;
		_options = other._options;
		_Q = other._Q;
		other._Q = nullptr;
		return *this;
	}
	Agent::~Agent() {
		for (unsigned int i = 0; i < _options.n * _options.m; ++i)
			delete[] _Q[i];
		delete[] _Q;
	}

	void Agent::PrintQ() {
		if (_Q == nullptr)
			return;
		for (unsigned int i = 0; i < _options.n * _options.m; ++i) {
			std::cout << i << ": ";
			for (auto action : AgentActions)
				std::cout << _Q[i][action] << '\t';
			std::cout << '\n';
		}
	}

	void Agent::SetCurrentPos(unsigned int pos) {
		assert(pos < _options.n * _options._m);
		_currentPos = pos;
	}

	double* Agent::GetActionProbabilityDistribution(double* QRow) {
		double* probDist = new double[NUM_OF_ACTIONS] {};

		double sum = 0;
		double temp;
		for (auto action : AgentActions) {
			temp = std::exp(QRow[action]);
			probDist[action] = temp;
			sum += temp;
		}
		for (auto action : AgentActions)
			probDist[action] /= sum;

		return probDist;
	}

	AgentAction Agent::SelectAction(double* probDist) {
		// Get a random number in range [0,1]
		double randomNumber = RANDOM;
		AgentAction selectedAction;
		double low = 0;
		for (auto action : AgentActions) {
			if (randomNumber >= low && randomNumber < low + probDist[action]) {
				selectedAction = action;
				break;
			}
			low += probDist[action];
		}
		return selectedAction;
	}

	AgentAction* Agent::ValueIteration(double gamma) {
		// Initialize the Values and Policy arrays
		double* prevValues = new double[_options.n * _options.m]{};
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
		srand(time(0));
		AgentAction* prevPolicy = new AgentAction[_options.n * _options.m];
		for (unsigned int i = 0; i < _options.n * _options.m; ++i)
			prevPolicy[i] = AgentAction(rand() % 4);

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

	unsigned int Agent::QLearningAct(double gamma) {
		// If _Q is not initialized, initialize it first
		if (_Q == nullptr) {
			_Q = new double* [_options.n * _options.m];
			for (unsigned int i = 0; i < _options.n * _options.m; ++i)
				_Q[i] = new double[NUM_OF_ACTIONS] {};
		}

		// Get the probability distribution of actions for each block
		double* probDist = GetActionProbabilityDistribution(_Q[_currentPos]);

		// Select an action and execute it
		AgentAction selectedAction = SelectAction(probDist);

		// Execute the action, receive the immediate award and observe the 
		// resulting position
		int reward = _map->ActionReward(_currentPos, selectedAction);
		unsigned int nextPos = _map->NextPosition(_currentPos, selectedAction);

		// Update the Q entry for currentPos
		double max = -1;
		for (auto action : AgentActions)
			max = std::max(max, reward + gamma * _Q[nextPos][action]);
		_Q[_currentPos][selectedAction] = max;

		_currentPos = nextPos;

		delete[] probDist;
		return _currentPos;
	}
} // namespace GoldDiggerAgent
